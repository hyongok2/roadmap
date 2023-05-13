using ModernFlatUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernFlatUI.MVVM.ViewModels;

public class MainViewModel : ObservableObject
{
    public RelayCommand MoveWindowCommand { get; set; }
    public RelayCommand HomeViewCommand { get; set; }
	public RelayCommand DiscoveryViewCommand { get; set; }

    public HomeViewModel HomeVM { get; set; }

	public DiscoveryViewModel DiscoveryVM { get; set; }

	private object _currentView;

	public object CurrentView
	{
		get { return _currentView; }
		set
		{ 
			_currentView = value; 
			OnPropertyChanged();
		}
	}

    Window _mainWindow = Application.Current.MainWindow;

    public MainViewModel()
	{
		HomeVM = new HomeViewModel();
        DiscoveryVM = new DiscoveryViewModel();
        CurrentView = HomeVM;

		HomeViewCommand = new RelayCommand(o =>
		{
			CurrentView = HomeVM;
		});

        DiscoveryViewCommand = new RelayCommand(o =>
        {
            CurrentView = DiscoveryVM;
        });

        MoveWindowCommand = new RelayCommand(o => { _mainWindow.DragMove(); });
    }
}
