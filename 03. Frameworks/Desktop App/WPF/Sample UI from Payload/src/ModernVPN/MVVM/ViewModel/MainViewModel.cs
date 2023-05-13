using ModernVPN.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernVPN.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public string TitleBarString { get; set; }
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShutdownWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }

        public RelayCommand ShowProtectionViewCommand { get; set; }
        public RelayCommand ShowSettingsViewCommand { get; set; }

        Window _mainWindow = Application.Current.MainWindow;

        private object? _currentView;
        public object? CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ProtectionViewModel ProtectionVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }

        public MainViewModel()
        {
            TitleBarString = "Modern Style UI";

            ProtectionVM = new ProtectionViewModel();
            SettingsVM = new SettingsViewModel();
            CurrentView = ProtectionVM;

            _mainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            MoveWindowCommand = new RelayCommand(o => { _mainWindow.DragMove(); });
            ShutdownWindowCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            MaximizeWindowCommand = new RelayCommand(o => 
            {
                if (_mainWindow.WindowState == WindowState.Maximized)
                    _mainWindow.WindowState = WindowState.Normal;
                else
                    _mainWindow.WindowState = WindowState.Maximized;
            });
            MinimizeWindowCommand = new RelayCommand(o => { _mainWindow.WindowState = WindowState.Minimized; });

            ShowProtectionViewCommand = new RelayCommand(o => { CurrentView = ProtectionVM; });
            ShowSettingsViewCommand = new RelayCommand(o => { CurrentView = SettingsVM; });
        }
    }
}
