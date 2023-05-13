namespace MonkeyFinder.View;

public partial class Sample : ContentView
{

	public Sample()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(Sample), string.Empty);

    public static readonly BindableProperty MonkeyTempProperty = BindableProperty.Create(nameof(MonkeyTemp), typeof(Monkey), typeof(Sample), null);

    public string CardTitle
    {
        get => (string)GetValue(Sample.CardTitleProperty);
        set => SetValue(Sample.CardTitleProperty, value);
    }

    public Monkey MonkeyTemp
    {
        get => (Monkey)GetValue(Sample.MonkeyTempProperty);
        set => SetValue(Sample.MonkeyTempProperty, (Monkey)value);
    }

}