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
        IAudioInterfaceService _audioInterfaceService;

        [ObservableProperty]
        private string _boldTitle  = "AVALONIA";

        [ObservableProperty]
        private string _regularTitle = "LOUDNESS METER2";

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
        private async Task LoadSettingsAsync()
        {
            var channelConfigurations = await _audioInterfaceService.GetChannelConfigurationsAsync();

            ChannelConfigurations =
                new ObservableGroupedCollection<string, ChannelConfigurationItem>(
                    channelConfigurations.GroupBy(item => item.Group));
        }

        public MainViewModel(IAudioInterfaceService audioInterfaceService)
        {
            _audioInterfaceService = audioInterfaceService;

            Initialize();
        }

        public MainViewModel()
        {
            _audioInterfaceService = new DummyAudioInterfaceService();
            
            Initialize();
        }
        
        private void Initialize()
        {
            // temp code to move volume position
            
            var tick = 0;
            var input = 0.0;

            var tempTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1/60.0)
            };

            tempTimer.Tick += (sender, args) =>
            {
                tick++;

                input = (double)tick / 20;

                var scale = VolumeContainerSize;

                VolumePercentPosition = (Math.Sin(input) + 1) / 2 * scale;
            };
            

            tempTimer.Start();
        }
    }
}
