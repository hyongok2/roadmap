using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Helper;
using RMDesktopUI.Library.Models;
using System;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RMDesktopUI.ViewModels
{
    public class SignUpViewModel : Screen
    {
        private readonly IAPIHelper _apiHelper;
        private readonly IEventAggregator _events;
        private readonly IUserEndPoint _userEndPoint;
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _windowManager;

        public SignUpViewModel(IAPIHelper aPIHelper, IEventAggregator events,
            StatusInfoViewModel status, IUserEndPoint userEndPoint, IWindowManager windowManager)
        {
            _apiHelper = aPIHelper;
            _events = events;
            _userEndPoint = userEndPoint;
            _status = status;
            _windowManager = windowManager;
        }

        private string _emailAddress = string.Empty;

        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                _emailAddress = value;
                NotifyOfPropertyChange(() => EmailAddress);
                NotifyOfPropertyChange(() => CanSignUp);
            }
        }

        private string _firstName = string.Empty;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanSignUp);
            }
        }

        private string _lastName = string.Empty;

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanSignUp);
            }
        }

        private string _password = string.Empty;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanSignUp);
            }
        }

        public void OnPasswordChanged(PasswordBox source)
        {
            if (source.Name == "Password")
                Password = source.Password;
            else if (source.Name == "PasswordConfirm")
                PasswordConfirm = source.Password;
        }

        private string _passwordConfirm = string.Empty;

        public string PasswordConfirm
        {
            get { return _passwordConfirm; }
            set
            {
                _passwordConfirm = value;
                NotifyOfPropertyChange(() => PasswordConfirm);
                NotifyOfPropertyChange(() => CanSignUp);
            }
        }



        public bool IsErrorVisible
        {
            get
            {
                bool output = false;
                if (ErrorMessage?.Length > 0)
                {
                    output = true;

                }
                return output;
            }

        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }


        public bool CanSignUp
        {
            get
            {
                if (Password != PasswordConfirm) return false;
                if (ValidChecker.IsValidPassword(Password) == false) return false;
                if (ValidChecker.IsValidEmail(EmailAddress) == false) return false;
                if (FirstName == string.Empty) return false;
                if (LastName == string.Empty) return false;

                return true;
            }
        }

        public async Task SignUp()
        {

            ErrorMessage = string.Empty;
            try
            {
                UserRegisterModel userRegister = new()
                {
                    EmailAddress = EmailAddress,
                    FirstName = FirstName,
                    LastName = LastName,
                    Password = Password
                };

                await _userEndPoint.UserRegister(userRegister);

                Password = string.Empty;
                PasswordConfirm = string.Empty;

                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "Inform";

                _status.UpdateMessage("Register Succeed!!", "You can Login after confirmation of Admin.");
                await _windowManager.ShowDialogAsync(_status, null, settings);
                await TryCloseAsync();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }




    }
}
