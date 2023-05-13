using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDictionary.ViewModels
{
    public partial class ShellViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task HelpAsync(string url)
        {
            await Shell.Current.DisplayAlert("Help", url, "ok");
        }
    }
}
