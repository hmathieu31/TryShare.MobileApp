using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel.Base
{
    /// <summary>
    /// A Base ViewModel class to be extended by subsequent ViewModels
    /// </summary>
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string? title;
        public bool IsNotBusy => !IsBusy;

        public Action? OnDetailsTryToNavigateWithoutConnectivity { get; set; }
        public Action? OnDetailsTryToNavigateWithoutLocationEnabled { get; set; }
        public Action? OnDetailsTryToNavigateWithoutLocationAuthorized { get; set; }
        public Action? OnDetailsTryToUnlockTooFarFromTheVehicule { get; set; }
    }
}
