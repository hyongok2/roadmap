using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Models;
using System;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RMDesktopUI.ViewModels
{
    public class UserDisplayViewModel : Screen
    {
        private readonly IUserEndPoint _userEndPoint;
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _windowManager;

        BindingList<UserModel> _users = new();

        public BindingList<UserModel> Users
        {
            get
            {
                return _users;
            }

            set
            {
                _users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }

        private UserModel _selectedUser;

        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                SelectedUserName = value.Email;
                SelectedUserRoles.Clear();
                SelectedUserRoles = new BindingList<string>(value.Roles.Select(x => x.Value).ToList());
                LoadRoles();//TODO : Turn this out into a method/event
                NotifyOfPropertyChange(() => SelectedUser);
            }
        }

        private string _selectedRoleToRemove;

        public string SelectedRoleToRemove
        {
            get { return _selectedRoleToRemove; }
            set
            {
                _selectedRoleToRemove = value;
                NotifyOfPropertyChange(() => SelectedRoleToRemove);
                NotifyOfPropertyChange(() => CanRemoveSelectedRole);
            }
        }

        private string _selectedRoleToAdd;

        public string SelectedRoleToAdd
        {
            get { return _selectedRoleToAdd; }
            set
            {
                _selectedRoleToAdd = value;
                NotifyOfPropertyChange(() => SelectedRoleToAdd);
                NotifyOfPropertyChange(() => CanAddSelectedRole);
            }
        }


        private string _selectedUserName;

        public string SelectedUserName
        {
            get { return _selectedUserName; }
            set
            {
                _selectedUserName = value;
                NotifyOfPropertyChange(() => SelectedUserName);
            }
        }

        private BindingList<string> _selectedUserRoles = new();

        public BindingList<string> SelectedUserRoles
        {
            get { return _selectedUserRoles; }
            set
            {
                _selectedUserRoles = value;
                NotifyOfPropertyChange(() => SelectedUserRoles);
            }
        }


        private BindingList<string> _availableRoles = new();

        public BindingList<string> AvailableRoles
        {
            get { return _availableRoles; }
            set
            {
                _availableRoles = value;
                NotifyOfPropertyChange(() => AvailableRoles);
            }
        }


        public UserDisplayViewModel(IUserEndPoint userEndPoint, StatusInfoViewModel status, IWindowManager windowManager)
        {
            _userEndPoint = userEndPoint;
            _status = status;
            _windowManager = windowManager;
        }

        protected override async Task OnInitializeAsync(CancellationToken cancellationToken)
        {
            try
            {
                await LoadUsers();
            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";

                if (ex.Message == "Unauthorized")
                {
                    _status.UpdateMessage("Unauthorized", "You do not have permission of interact with the User Display Form.");
                }
                else
                {
                    _status.UpdateMessage("Fatal exception", ex.Message);
                }

                await _windowManager.ShowDialogAsync(_status, null, settings);
                await TryCloseAsync();
            }
        }

        private async Task LoadUsers()
        {
            var users = await _userEndPoint.GetAll();

            Users = new BindingList<UserModel>(users);
        }

        private async Task LoadRoles()
        {
            var roles = await _userEndPoint.GetAllRoles();

            AvailableRoles.Clear();

            foreach (var role in roles)
            {
                if (SelectedUserRoles.Contains(role.Value)) continue;
                AvailableRoles.Add(role.Value);
            }
        }

        public bool CanAddSelectedRole
        {
            get
            {
                if (SelectedUser is null || SelectedRoleToAdd is null) return false;
                else return true;
            }
        }

        public bool CanRemoveSelectedRole
        {
            get
            {
                if (SelectedUser is null || SelectedRoleToRemove is null) return false;
                else return true;
            }
        }


        public async Task AddSelectedRole()
        {
            await _userEndPoint.AddUserToRole(SelectedUser.Id, SelectedRoleToAdd);

            SelectedUserRoles.Add(SelectedRoleToAdd);
            AvailableRoles.Remove(SelectedRoleToAdd);
        }

        public async Task RemoveSelectedRole()
        {
            await _userEndPoint.RemoveUserFromRole(SelectedUser.Id, SelectedRoleToRemove);

            AvailableRoles.Add(SelectedRoleToRemove);
            SelectedUserRoles.Remove(SelectedRoleToRemove);
        }
    }
}
