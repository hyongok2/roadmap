using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaLoudnessMeter.ViewModels
{
    public partial class MainViewModel : ObservableObject /*: INotifyPropertyChanged*/
    {
        //private string boldTitle = "AVALONIA";

        //public string BoldTitle
        //{
        //    get
        //    {
        //        return boldTitle;
        //    }
        //    set
        //    {
        //        if (value != boldTitle)
        //        {
        //            boldTitle = value;
        //            //OnPropertyChanged();
        //        }
        //    }
        //}

        [ObservableProperty]
        public string _boldTitle  = "AVALONIA";

        [ObservableProperty]
        public string _regularTitle = "LOUDNESS METER2";

        public MainViewModel()
        {
            //Task.Run(async () =>
            //{
            //    await Task.Delay(2000);
            //    BoldTitle = "NEW AVALONIA";
            //});
        }

        //public event PropertyChangedEventHandler? PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName]string? propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
