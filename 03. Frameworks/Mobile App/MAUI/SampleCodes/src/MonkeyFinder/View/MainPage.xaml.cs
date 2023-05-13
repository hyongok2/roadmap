namespace MonkeyFinder.View;

public partial class MainPage : ContentPage
{
    public MainPage(MonkeysViewModel veiwModel)
    {
        InitializeComponent();
        BindingContext = veiwModel; 
    }

    private void OnDragStarting(object sender, DragStartingEventArgs e)
    {
       
    }

    private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {
        Shell.Current.DisplayAlert("Drop", "WOW", "End");
    }
}
