using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Avalonia.Threading;
using AvaloniaLoudnessMeter.DataModels;
using AvaloniaLoudnessMeter.Sevices;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.Input;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using System.Collections.ObjectModel;
using LiveChartsCore.Defaults;

namespace AvaloniaLoudnessMeter.ViewModels
{
    public partial class MainViewModel : ObservableObject /*: INotifyPropertyChanged*/
    {
        IAudioCaptureService _audioCaptureService;

        private int _updateCounter;

        [ObservableProperty]
        private string _boldTitle  = "AVALONIA";

        [ObservableProperty]
        private string _regularTitle = "LOUDNESS METER";
        
        [ObservableProperty] private string _shortTermLoudness = "0 LUFS";

        [ObservableProperty] private string _integratedLoudness = "0 LUFS";

        [ObservableProperty] private string _loudnessRange = "0 LU";

        [ObservableProperty] private string _realtimeDynamics = "0 LU";

        [ObservableProperty] private string _averageDynamics = "0 LU";

        [ObservableProperty] private string _momentaryMaxLoudness = "0 LUFS";

        [ObservableProperty] private string _shortTermMaxLoudness = "0 LUFS";

        [ObservableProperty] private string _truePeakMax = "0 dB";

        [ObservableProperty]
        private bool _channelConfigurationListIsOpen = false;
        
        [ObservableProperty]
        private double _volumePercentPosition;
        
        [ObservableProperty]
        private double _volumeContainerHeight;

        [ObservableProperty]
        private double _volumeBarHeight;

        [ObservableProperty]
        private double _volumeBarMaskHeight;

        [ObservableProperty]
        private ObservableGroupedCollection<string, ChannelConfigurationItem> _channelConfigurations = default!;
        
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ChannelConfigurationButtonText))]
        private ChannelConfigurationItem? _selectedChannelConfiguration;

        public string ChannelConfigurationButtonText => SelectedChannelConfiguration?.ShortText ?? "Select Channel";

        public ObservableCollection<ObservableValue> MainChartValues = new ObservableCollection<ObservableValue>();

        public ISeries[] Series { get; set; }

        public List<Axis> YAxis { get; set; } = new List<Axis>
        {
            new Axis
            {
                //IsInverted = true
                MinStep = 1,
                ForceStepToMin= true,
                MinLimit= 0,
                MaxLimit= 60,
                Labeler = (val) => (val-60).ToString(),
                IsVisible = false,
            }
        };

        [RelayCommand]
        private void ChannelConfigurationButtonPressed() => ChannelConfigurationListIsOpen ^= true;
        
        [RelayCommand]
        private void ChannelConfigurationItemPressed(ChannelConfigurationItem item)
        {
            SelectedChannelConfiguration = item;

            ChannelConfigurationListIsOpen = false;

        }
        
        [RelayCommand]
        private async Task LoadAsync()
        {
            var channelConfigurations = await _audioCaptureService.GetChannelConfigurationsAsync();

            ChannelConfigurations =
                new ObservableGroupedCollection<string, ChannelConfigurationItem>(
                    channelConfigurations.GroupBy(item => item.Group));

            StartCapture(1);
        }

        private void StartCapture(int deviceId)
        {
            _audioCaptureService.InitCapture(deviceId);

            _audioCaptureService.AudioChunkAvailable += audioChuckData =>
            {
                ProcessAudioChunk(audioChuckData);
            };

            _audioCaptureService.Start();
        }

        private void ProcessAudioChunk(AudioChunkData audioChuckData)
        {
            // Counter between 0-1-2
            _updateCounter = (_updateCounter+ 1) % 3;

            // Every time counter is at 0...
            if (_updateCounter == 0)
            {
               ShortTermLoudness = $"{Math.Max(-60, audioChuckData.ShortTermLUFS):0.0} LUFS";
               IntegratedLoudness = $"{Math.Max(-60, audioChuckData.IntegratedLUFS):0.0} LUFS";
               LoudnessRange = $"{Math.Max(-60, audioChuckData.LoudnessRange):0.0} LU";
               RealtimeDynamics = $"{Math.Max(-60, audioChuckData.RealtimeDynamics):0.0} LU";
               AverageDynamics = $"{Math.Max(-60, audioChuckData.AverageRealtimeDynamics):0.0} LU";
               MomentaryMaxLoudness = $"{Math.Max(-60, audioChuckData.MomentaryMaxLUFS):0.0} LUFS";
               ShortTermMaxLoudness = $"{Math.Max(-60, audioChuckData.ShortTermMaxLUFS):0.0} LUFS";
               TruePeakMax = $"{Math.Max(-60, audioChuckData.TruePeakMax):0.0} dB";
            
                // Update charge on UI thread
                Dispatcher.UIThread.Invoke(() =>
                {
                    if(MainChartValues.Count> 170)
                        MainChartValues.RemoveAt(0);
                    MainChartValues.Add(new(Math.Max(0, 60 + audioChuckData.ShortTermLUFS)));
                });
            }

            // Set volume bar height
            VolumeBarMaskHeight = Math.Min(VolumeBarHeight, VolumeBarHeight / 60 * -audioChuckData.Loudness);

            // Set Volume Arrow height
            VolumePercentPosition = Math.Min(VolumeContainerHeight, VolumeContainerHeight / 60 * -audioChuckData.ShortTermLUFS);
        }

        public MainViewModel(IAudioCaptureService audioCaptureService)
        {
            _audioCaptureService = audioCaptureService;

            Initialize();
        }

        public MainViewModel()
        {
            _audioCaptureService = new BassAudioCaptureService();
            
            Initialize();
        }

        private void Initialize()
        {
            Series  = new ISeries[]
             {
                 new LineSeries<ObservableValue>
                 {
                     Values = MainChartValues,
                     GeometrySize = 0,
                     GeometryStroke = null,
                     Fill = new SolidColorPaint(new SkiaSharp.SKColor(63,77,99)),
                     Stroke = new SolidColorPaint(new SkiaSharp.SKColor(120,152,203)){ StrokeThickness = 3}
                 }
             };
        }
    }
}
