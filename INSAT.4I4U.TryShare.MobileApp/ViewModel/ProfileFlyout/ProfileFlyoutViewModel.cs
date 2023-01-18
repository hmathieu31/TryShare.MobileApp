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
        public ProfileFlyoutViewModel()
        {
            ConnectionButtonText = "Connexion";
        }
        
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string connectionButtonText;

        [RelayCommand]
        Task LogInOut()
        {
            throw new NotImplementedException();
        }
    }
}
