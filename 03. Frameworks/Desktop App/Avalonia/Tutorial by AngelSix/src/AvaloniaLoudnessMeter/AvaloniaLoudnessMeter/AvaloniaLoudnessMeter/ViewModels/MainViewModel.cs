using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AvaloniaLoudnessMeter.DataModels;
using AvaloniaLoudnessMeter.Sevices;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.Input;


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
        }
        
        public MainViewModel()
        {
            _audioInterfaceService = new DummyAudioInterfaceService();
        } 
    }
}
