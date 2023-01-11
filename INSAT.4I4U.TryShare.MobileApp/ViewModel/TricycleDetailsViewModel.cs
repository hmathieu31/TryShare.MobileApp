using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Booking;
using INSAT._4I4U.TryShare.MobileApp.Services.User;
using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    [QueryProperty(nameof(Tricycle), "Tricycle")]
    public partial class TricycleDetailsViewModel : BaseViewModel
    {
        readonly IUserLocationService _userLocationService;
        readonly IUserService _userService;
        readonly IUserSubscriptionService _userSubscriptionService;
        readonly IBookingService _bookingService;

        public bool IsConnectedAndSignedIn { get; set; }
        public Action OnDetailsTryToNavigateWithoutConnectivity { get; set; }
        public Action OnDetailsTryToNavigateWithoutLocationEnabled { get; set; }
        public Action OnDetailsTryToNavigateWithoutLocationAuthorized { get; set; }
        public TricycleDetailsViewModel(IUserLocationService userLocationService,
                                        IUserService userService,
                                        IUserSubscriptionService userSubscriptionService,
                                        IBookingService bookingService)
        {
            this._userLocationService = userLocationService;
            this._userService = userService;
            this._userSubscriptionService = userSubscriptionService;
            this._bookingService = bookingService;
        }

        [ObservableProperty]
        Tricycle tricycle;

        /// <summary>
        /// Postal address of the tricycle following the format "street, city"
        /// </summary>
        [ObservableProperty]
        string tricycleAddress = "";

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
        public async Task GoToMoreCommentsAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(CommentPage), true, new Dictionary<string, object>
            { {"tricycle", Tricycle}});
            IsBusy = false;
        }

        [RelayCommand]
        public async Task GoToTermsAndConditionsAsync()
        {

            await Shell.Current.GoToAsync(nameof(TermsAndConditionsPage), true);
        }


        [RelayCommand]
        public async Task GoToRatingPageAsync(Tricycle tricycle)
        {
            const int distanceMax = 10;
            if (_userService.IsConnected && _userService.IsAuthenticated())
            {
                IsConnectedAndSignedIn = true;
                try
                {
                    var distance = await _userLocationService.CalculateDistanceFromTricycleAsync(tricycle);
                    if (distance < distanceMax)
                    {
                        await Shell.Current.GoToAsync(nameof(TricycleUnlockingPage), true, new Dictionary<string, object>
                        { {"Tricycle", tricycle } });
                    }
                }
                catch (PermissionException)
                {
                    PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                    if (status is not PermissionStatus.Granted)
                    {
                        OnDetailsTryToNavigateWithoutLocationAuthorized.Invoke();
                    }
                }
                catch (FeatureNotEnabledException)
                {
                    OnDetailsTryToNavigateWithoutLocationEnabled.Invoke();
                }

            }
            else
            {
                IsConnectedAndSignedIn = false;
                OnDetailsTryToNavigateWithoutConnectivity.Invoke();
            }
        }
    }
}