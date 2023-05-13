namespace FiveLetters;

public partial class ColorPage : ContentPage
{
	public ColorPage()
	{
		InitializeComponent();
	}

	private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
	{
		//Shell.Current.DisplayAlert("Pan", "Pan Motion", "OK");
	}
}