using AnswerBot.ViewModels;
using Newtonsoft.Json;

namespace AnswerBot;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }

}

