using ModernFlatUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernFlatUI.MVVM.ViewModels;

public class HomeViewModel : ObservableObject
{
	public RelayCommand BorderClickCommand { get; set; }
	public HomeViewModel()
	{
		BorderClickCommand = new RelayCommand(o =>
		{
			MessageBox.Show("You click the sample border area!");
		});

    }
}
