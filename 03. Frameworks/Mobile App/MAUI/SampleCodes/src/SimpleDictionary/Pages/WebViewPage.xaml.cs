using CommunityToolkit.Mvvm.ComponentModel;

namespace SimpleDictionary.Pages;
[QueryProperty("Url", "Param1")]
public partial class WebViewPage : ContentPage
{

    public string Url
    {
        set
        {
            wv.Source = value;
        }
    }

    public WebViewPage()
    {
        InitializeComponent();
    }

}