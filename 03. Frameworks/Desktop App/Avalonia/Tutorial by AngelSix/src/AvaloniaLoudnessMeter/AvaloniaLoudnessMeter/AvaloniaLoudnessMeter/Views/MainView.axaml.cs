using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using AvaloniaLoudnessMeter.Sevices;
using AvaloniaLoudnessMeter.ViewModels;
using ManagedBass;
using NWaves.Signals;
using NWaves.Utils;

namespace AvaloniaLoudnessMeter.Views
{
    public partial class MainView : UserControl
    {
        #region Private Member

        private MainViewModel _viewModel => (MainViewModel)DataContext;
        
        private AudioCaptureService _captureDevice;

        private Queue<double> _Lufs = new Queue<double>();

        private int _capturedFrequency = 44100;

        private readonly Control _channelConfigPopUp;
        private readonly Control _channelConfigButton;
        private readonly Control _mainGrid;
        private readonly Control _volumeArrowContainer;

        private Timer _sizingTimer;

        #endregion
        public MainView()
        {
            InitializeComponent();
            // DataContext = new MainViewModel();
            
            _sizingTimer = new Timer(t =>
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    UpdateSizes();
                });
            });

            _channelConfigButton = this.FindControl<Control>("ChannelConfigurationButton") ?? throw new Exception("Cannot find Channel Configuration Button by name");
            _channelConfigPopUp = this.FindControl<Control>("ChannelConfigurationPopUp") ?? throw new Exception("Cannot find Channel Configuration Popup by name");
            _mainGrid = this.FindControl<Control>("MainGrid") ?? throw new Exception("Cannot find Main Grid by name");
            _volumeArrowContainer= this.FindControl<Control>("VolumeArrowContainer") ?? throw new Exception("Cannot find Volume Arrow Container by name");
        }

        private void UpdateSizes()
        {
            _viewModel.VolumeContainerSize = _volumeArrowContainer.Bounds.Height;
        }

        protected override async void OnLoaded()
        {
            await _viewModel.LoadSettingsCommand.ExecuteAsync(null);

            StartCapture(1,_capturedFrequency);
            
            base.OnLoaded();
        }

        private void StartCapture(int deviceId,int frequency)
        {
            _captureDevice = new AudioCaptureService(deviceId,frequency);
            
            // foreach(var device in RecordingDevice.Enumarate())
            //     Console.WriteLine($"{device.Index}: {device.Name}");

            // using var _captureDevice = new AudioCaptureService(1);

            // 사운드 파일을 저장하기 위한 방법, 여기에서는 일단 주석처리하지만, 나중에 참고할 수 있다.
            // var outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MBass");
            // Directory.CreateDirectory(outputPath);
            // var filePath = Path.Combine(outputPath, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".wav");
            // using var _writer = new WaveFileWriter(new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read),new WaveFormat());
            
            _captureDevice.DataAvailable += (buffer, length) =>
            {
                //_writer.Write(buffer, length);

                CalculateValues(buffer);
            };
            _captureDevice.Start();
        }

        private void CalculateValues(byte[] buffer)
        {
            //Get total PCM16 samples in this buffers
            var sampleCount = buffer.Length / 2;
            var signal = new DiscreteSignal(_capturedFrequency, sampleCount);

            using var reader = new BinaryReader(new MemoryStream(buffer));

            for (int i = 0; i < sampleCount; i++)
            {
                signal[i] = reader.ReadInt16() / 32768f;
            }
            
            _Lufs.Enqueue(Scale.ToDecibel(signal.Rms()));

            if(_Lufs.Count > 15) _Lufs.Dequeue();
            
            var lufs = _Lufs.Average();

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                _viewModel.ShortTermLoudness = $"{lufs:0.0} LUFS";
            });
        }


        public override void Render(DrawingContext context)
        {
            base.Render(context);

            _sizingTimer.Change(100, int.MaxValue);
          
            // Main Gird 기준 버튼의 상대 위치를 가져옴.
            var position = _channelConfigButton.TranslatePoint(new Point(), _mainGrid) ??
                           throw new Exception("Cannot get TranslatePoint from Configuration Button");

            Dispatcher.UIThread.InvokeAsync(()=>
            {
                _channelConfigPopUp.Margin = new Thickness(position.X, 0, 0,
                    _mainGrid.Bounds.Height - position.Y - _channelConfigButton.Bounds.Height);
                
            });
        }

    }
}