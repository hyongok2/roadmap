namespace RMMobileApp.Views;

public partial class PlayVideoView : ContentPage
{
	public PlayVideoView(PlayVideoViewModel playVideoViewModel)
	{
		InitializeComponent();
        BindingContext = playVideoViewModel;
    }

    private void PlayButton_Clicked(object sender, EventArgs e)
    {
        VideoControl.Play();
    }

    private void PauseButton_Clicked(object sender, EventArgs e)
    {
        VideoControl.Pause();
    }

    private void StopButton_Clicked(object sender, EventArgs e)
    {
        VideoControl.Stop();
    }
}