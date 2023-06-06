using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaLoudnessMeter.ViewModels
{
    public partial class MainViewModel : ObservableObject /*: INotifyPropertyChanged*/
    {

        [ObservableProperty]
        private string _boldTitle  = "AVALONIA";

        [ObservableProperty]
        private string _regularTitle = "LOUDNESS METER2";

        [ObservableProperty]
        private bool _channelConfigurationListIsOpen = false;

        [RelayCommand]
        private void ChannelConfigurationButtonPressed() => ChannelConfigurationListIsOpen ^= true;
       
        
        

    }
}
