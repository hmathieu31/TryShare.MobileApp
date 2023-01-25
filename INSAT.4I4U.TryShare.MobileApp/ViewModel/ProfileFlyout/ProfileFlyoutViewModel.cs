using INSAT._4I4U.TryShare.MobileApp.Services.User;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel.ProfileFlyoutHeader
{
    public partial class ProfileFlyoutViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        public ProfileFlyoutViewModel(IUserService userService)
        {
            this._userService = userService;
        }
        
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string connectionButtonText = "Connexion";

        private void SetConnectionButtonText(bool isAuthenticated)
        {
            if (isAuthenticated)
            {
                ConnectionButtonText = "Déconnexion";
            }
            else
            {
                ConnectionButtonText = "Connexion";
            }
        }

        [RelayCommand]
        Task LogInOutAsync()
        {
            var isAuthenticated = _userService.IsAuthenticated();
            if (isAuthenticated)
            {
                _userService.SignOutUserAsync();
            }
            else
            {
                _userService.GetUserIdentityAsync();
            }
            SetConnectionButtonText(isAuthenticated);
            return Task.CompletedTask;
        }
    }
}
