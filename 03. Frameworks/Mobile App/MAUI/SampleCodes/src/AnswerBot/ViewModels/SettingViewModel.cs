using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerBot.ViewModels;

public partial class SettingViewModel : ObservableObject
{
    [ObservableProperty]
    bool isDarkMode;

    public SettingViewModel()
    {
        IsDarkMode = Application.Current.UserAppTheme == AppTheme.Dark;
    }

    [RelayCommand]
    void ChangeMode()
    {
        if(IsDarkMode)
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
        }
        else
        {
            Application.Current.UserAppTheme = AppTheme.Light;
        }
    }
}
