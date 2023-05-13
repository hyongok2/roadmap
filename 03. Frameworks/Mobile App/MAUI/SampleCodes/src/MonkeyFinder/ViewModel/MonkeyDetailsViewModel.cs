using CommunityToolkit.Mvvm.Messaging;
using MonkeyFinder.View;

namespace MonkeyFinder.ViewModel;

[QueryProperty("Monkey", "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
	IMap map;
	public MonkeyDetailsViewModel(IMap map)
	{
		this.map = map;
	}

	[ObservableProperty]
	Monkey monkey;

	[RelayCommand]
	async Task GoBackAsync()
	{
		await Shell.Current.GoToAsync("..");
	}

    [RelayCommand]
    void Test()
    {
		WeakReferenceMessenger.Default.Send(new TestMessage("Oh~~~!"));

        //MessagingCenter.Send<MonkeyDetailsViewModel, string>(this, "Hi", "Test~~~!");  //=>  이런 방식은 매우 강력한 결합이므로 사용하지 않는게 좋다.
        //await Shell.Current.GoToAsync($"{nameof(GridsPage)}");
    }


    [RelayCommand]
    async Task OpenMapAsync()
	{
		try
		{
			await map.OpenAsync(Monkey.Latitude,Monkey.Longitude,
				new MapLaunchOptions
				{
					Name = Monkey.Name,
					NavigationMode = NavigationMode.None
				});
		}
		catch (Exception ex)
		{
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", $"Unable to open map: {ex.Message}", "OK");
        }

	}
    [RelayCommand]
    async Task GoToImage(string uri)
    {
        await Shell.Current.GoToAsync($"{nameof(MonkeyImagePage)}", true,
		new Dictionary<string, object>
		{
					{"MonkeyImage",uri }
		});
    }


}