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
        }
        
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string connectionButtonText = "Connection";

        [RelayCommand]
        Task LogInOut()
        {
            ConnectionButtonText = "Connection";
            return Task.CompletedTask;
        }
    }
}
