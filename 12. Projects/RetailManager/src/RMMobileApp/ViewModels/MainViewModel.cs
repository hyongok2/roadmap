namespace RMMobileApp.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly IAPIHelper apiHelper;

    [ObservableProperty]
    string emailAddress;

    [ObservableProperty]
    string inputPassword;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsErrorVisible))]
    string errorMessage;

    public bool IsErrorVisible
    {
        get
        {
            return string.IsNullOrWhiteSpace(EmailAddress) == false;
        }
    }

    public MainViewModel(IAPIHelper apiHelper)
	{
        this.apiHelper = apiHelper;
    }

    [RelayCommand]
    async Task LogIn()
    {
        IsBusy= true;
        ErrorMessage= string.Empty;

        try
        {
            var result = await apiHelper.Authenticate(EmailAddress, InputPassword);

            await apiHelper.GetLoggedInUserInfo(result.Access_Token);

            await Shell.Current.GoToAsync(nameof(ProductsView));
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        finally
        {
            IsBusy = false;
        }
        
    }
}
