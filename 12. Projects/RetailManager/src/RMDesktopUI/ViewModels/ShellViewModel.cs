using Caliburn.Micro;
using RMDesktopUI.EventModels;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private readonly ILoggedInUserModel _user;
        private readonly IAPIHelper _apiHelper;

        public ShellViewModel(IEventAggregator events, ILoggedInUserModel user, IAPIHelper apiHelper)
        {
            _events = events;
            _user = user;
            _apiHelper = apiHelper;

            _events.SubscribeOnUIThread(this);

            //ActivateItemAsync(IoC.Get<LoginViewModel>());
        }

        public void ExitApplication()
        {
            TryCloseAsync();
        }

        public void UserManagement()
        {
            ActivateItemAsync(IoC.Get<UserDisplayViewModel>());
        }


        public bool IsLoggedIn
        {
            get
            {
                return string.IsNullOrEmpty(_user.Token) == false;
            }
        }

        public bool IsLoggedOut
        {
            get
            {
                return !IsLoggedIn;
            }
        }

        public async Task LogOut()
        {
            _user.ResetUserModel();
            _apiHelper.LogOffUser();
            await ActivateItemAsync(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }

        public async Task LogIn()
        {
            //_user.ResetUserModel();
            //_apiHelper.LogOffUser();
            await ActivateItemAsync(IoC.Get<LoginViewModel>());
            //NotifyOfPropertyChange(() => IsLoggedIn);
            //NotifyOfPropertyChange(() => IsLoggedOut);
        }

        public async Task SignUp()
        {
            await ActivateItemAsync(IoC.Get<SignUpViewModel>());
        }

        public Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            ActivateItemAsync(IoC.Get<SalesViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);

            return Task.CompletedTask;
        }


    }
}
