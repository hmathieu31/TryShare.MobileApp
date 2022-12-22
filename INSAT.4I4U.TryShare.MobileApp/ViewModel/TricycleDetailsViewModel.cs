using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Tricycles;
using INSAT._4I4U.TryShare.MobileApp.Services.User;
using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;
using System.Windows.Input;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    [QueryProperty(nameof(Tricycle), "Tricycle")]
    public partial class TricycleDetailsViewModel : BaseViewModel
    {

        readonly IUserLocationService userLocation;
        public TricycleDetailsViewModel(IUserLocationService userLocationService)
        {
            this.userLocation = userLocationService;
        }

        [ObservableProperty]
        Tricycle tricycle;

        [ObservableProperty]
        private bool isPopupVisible = false;

        /// <summary>
        /// Postal address of the tricycle following the format "street, city"
        /// </summary>
        [ObservableProperty]
        string tricycleAddress = "";

        [ObservableProperty]
        double distance;

        /// <summary>
        /// Sets the ObservableProperty of the postal address of the tricycle.
        /// Asynchronously uses the Geocoding Service to get the address from the tricycle's location.
        /// </summary>
        /// <remarks>
        /// The address set is follows the format : "Street, City"
        /// </remarks>
        public async Task SetTricycleAddressLabelAsync()
        {
            double latitude = Tricycle.Location.Latitude;
            double longitude = Tricycle.Location.Longitude;

            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(latitude, longitude);

            Placemark placemark = placemarks?.FirstOrDefault();

            if (placemark is not null)
                TricycleAddress = $"{placemark.Thoroughfare}, {placemark.Locality}";
        }

        [RelayCommand]
        public async Task GoToMoreCommentsAsync(Uri url) => await Launcher.OpenAsync(url);


        [RelayCommand]
        public async Task GoToTermsAndConditionsAsync()
        {
            await Shell.Current.GoToAsync(nameof(TermsAndConditionsPage), true);
            IsPopupVisible = false;
        }


        [RelayCommand]
        public void GoToRatingPage(Tricycle tricycle)
        { 
            Distance = userLocation.CalculateDistanceFromTricycle(tricycle);
        }

    }
}