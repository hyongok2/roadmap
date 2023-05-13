namespace MonkeyFinder.View;

[QueryProperty("MonkeyImage", "MonkeyImage")]
public partial class MonkeyImagePage : ContentPage
{
	public MonkeyImagePage()
	{
		InitializeComponent();
        BindingContext = this;
	}

    public static readonly BindableProperty MonkeyImageProperty = BindableProperty.Create(nameof(MonkeyImage), typeof(string), typeof(MonkeyImagePage), string.Empty);

    public string MonkeyImage
    {
        get => (string)GetValue(MonkeyImagePage.MonkeyImageProperty);
        set => SetValue(MonkeyImagePage.MonkeyImageProperty, value);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}