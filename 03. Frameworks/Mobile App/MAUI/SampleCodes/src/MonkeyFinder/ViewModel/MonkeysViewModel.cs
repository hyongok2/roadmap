using CommunityToolkit.Mvvm.Messaging;
using MediatR;
using Microsoft.Maui.Layouts;
using MonkeyFinder.Mediator;
using MonkeyFinder.Services;
namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel, IRecipient<TestMessage>
{
    //IMonkeyService monkeyService; //MediatR로 대체함.
    IMediator mediator;
    public ObservableCollection<Monkey> Monkeys { get; } = new();

    IConnectivity connectivity;

    IGeolocation geolocation;
    public MonkeysViewModel(IMediator mediator, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "Monkey Finder";
        //this.monkeyService = monkeyService;
        this.mediator = mediator;
        this.connectivity = connectivity;
        this.geolocation = geolocation;

        WeakReferenceMessenger.Default.Register<TestMessage>(this);

        //아래 방식은 매우 별로다.. 강한 결합...
        //MessagingCenter.Subscribe<MonkeyDetailsViewModel, string>(this, "Hi", async (sender, arg) =>
        //{
        //    await Task.Run(() => {
        //        var name = (sender as MonkeyDetailsViewModel).Monkey.Name;
        //        string result = arg;
        //    });
        //});
    }

    [ObservableProperty]
    int widthOfParent;

    [RelayCommand]
    void SizeChange(int width)
    {
        WidthOfParent = width;
    }

    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    async Task GetClosestMonkey()
    {
        if (IsBusy || Monkeys.Count == 0)
            return;

        try
        {
            var location = await geolocation.GetLastKnownLocationAsync();
            if(location is null)
            {
                location = await geolocation.GetLocationAsync(
                    new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30),

                    });
            }

            if (location is null) return;

            var first = Monkeys.OrderBy(m =>
            location.CalculateDistance(m.Latitude, m.Longitude, DistanceUnits.Kilometers)).FirstOrDefault();

            if (first is null) return;

            await Shell.Current.DisplayAlert("Closest Monkey", $"{first.Name} {first.Location}", "OK");

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", $"Unable to get closest monkeys: {ex.Message}", "OK");
        }

    }

    [RelayCommand]
    async Task GoToDetailsAsync(Monkey monkey)
    {
        if(monkey is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}",true, 
            new Dictionary<string,object>
            {
                {"Monkey",monkey }
            });
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy) return;

        try
        {
            if(connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Internet issue", 
                    $"Check your internet and try again!", "OK");
                return;
            }

            IsBusy = true;
             var monkeys = await mediator.Send(new GetMonkeyListQuery());

            if (Monkeys.Count != 0)
                Monkeys.Clear();

            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!",$"Unable to get monkeys: {ex.Message}","OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    void MonkeyDelete(Monkey monkey)
    {
        if (monkey is null) return;

        var mo = Monkeys.FirstOrDefault(m => m.Name.Equals(monkey.Name));

        if(mo != null)
            Monkeys.Remove(monkey);
    }

    public void Receive(TestMessage message)
    {
        var m = message.Value; //이렇게 받은 메세지를 처리할 수 있다..  https://youtu.be/vD17OetzGXc   < 이 동영상을 참고 할 것
    }
}