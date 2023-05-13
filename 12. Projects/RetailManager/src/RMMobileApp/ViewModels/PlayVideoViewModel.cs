namespace RMMobileApp.ViewModels;

public partial class PlayVideoViewModel : BaseViewModel
{
    [ObservableProperty]
    string videoUrl;

    public PlayVideoViewModel()
    {
        VideoUrl = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";
    }
}
