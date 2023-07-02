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


namespace AvaloniaLoudnessMeter.ViewModels
{
    public partial class MainViewModel : ObservableObject /*: INotifyPropertyChanged*/
    {
        IAudioCaptureService _audioCaptureService;

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
        private double _volumeContainerSize;
        
        [ObservableProperty]
        private ObservableGroupedCollection<string, ChannelConfigurationItem> _channelConfigurations = default!;
        
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ChannelConfigurationButtonText))]
        private ChannelConfigurationItem? _selectedChannelConfiguration;

        public string ChannelConfigurationButtonText => SelectedChannelConfiguration?.ShortText ?? "Select Channel";

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

            _audioCaptureService.AudioChunkAvailable += audioChuckData =>
            {
                ProcessAudioChunk(audioChuckData);
            };
            
            _audioCaptureService.Start();
        }

        private void ProcessAudioChunk(AudioChunkData audioChuckData)
        {
            // Counter between 0-1-2
           // mUpdatecounter = (mUpdatecounter+ 1) % 3;
        
            // Every time counter is at 0...
           // if (mUpdatecounter == 0)
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
                 //   MainChartValues.RemoveAt(0);
                 //   MainChartValues.Add( new (Math.Max(0, 60 + audioChuckData.ShortTermLUFS)));
                });
            }

            // Set volume bar height
           // VolumeBarMaskHeight = Math.Min(_volumeBarHeight, _volumeBarHeight / 60 * -audioChuckData.Loudness);
        
            // Set Volume Arrow height
            VolumePercentPosition = Math.Min(VolumeContainerSize, VolumeContainerSize / 60 * -audioChuckData.ShortTermLUFS);
        }

        public MainViewModel(IAudioCaptureService audioCaptureService)
        {
            _audioCaptureService = audioCaptureService;

            //Initialize();
        }

        public MainViewModel()
        {
            _audioCaptureService = new BassAudioCaptureService(1, 44100);
            
            //Initialize();
        }
        
        // private void Initialize()
        // {
        //     // temp code to move volume position
        //     
        //     var tick = 0;
        //     var input = 0.0;
        //
        //     var tempTimer = new DispatcherTimer
        //     {
        //         Interval = TimeSpan.FromSeconds(1/60.0)
        //     };
        //
        //     tempTimer.Tick += (sender, args) =>
        //     {
        //         tick++;
        //
        //         input = (double)tick / 20;
        //
         //        var scale = VolumeContainerSize;
        //
        //         VolumePercentPosition = (Math.Sin(input) + 1) / 2 * scale;
        //     };
        //     
        //
        //     tempTimer.Start();
        // }
    }
}
