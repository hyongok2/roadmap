using AnswerBot.ViewModels;

namespace AnswerBot.Views;

public partial class SettingPage : ContentPage
{
	public SettingPage(SettingViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}