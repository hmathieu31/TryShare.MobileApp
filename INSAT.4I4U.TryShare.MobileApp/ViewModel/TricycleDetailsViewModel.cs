using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Booking;
using INSAT._4I4U.TryShare.MobileApp.Services.User;
using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    [QueryProperty(nameof(SelectedTricycle), "Tricycle")]
    public partial class TricycleDetailsViewModel : BaseViewModel
    {
        readonly IUserLocationService _userLocationService;
        readonly IUserService _userService;

        public TricycleDetailsViewModel(IUserLocationService userLocationService,
                                        IUserService userService,
                                        IUserSubscriptionService userSubscriptionService,
                                        IBookingService bookingService)
        {
            this._userLocationService = userLocationService;
            this._userService = userService;
        }

        [ObservableProperty]
        private Tricycle selectedTricycle;

        [ObservableProperty]
        bool isActivityIndicatorRunning = false;

        /// <summary>
        /// Postal address of the selectedTricycle following the format "street, city"
        /// </summary>
        [ObservableProperty]
        string tricycleAddress = "";

        /// <summary>
        /// Sets the ObservableProperty of the postal address of the selectedTricycle.
        /// Asynchronously uses the Geocoding Service to get the address from the selectedTricycle's toulouseCenter.
        /// </summary>
        /// <remarks>
        /// The address set is follows the format : "Street, City"
        /// </remarks>
        public async Task SetTricycleAddressLabelAsync()
        {
            double latitude = SelectedTricycle.Location.Latitude;
            double longitude = SelectedTricycle.Location.Longitude;

            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(latitude, longitude);

            var placemark = placemarks?.FirstOrDefault();

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
            { {"selectedTricycle", SelectedTricycle} });
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
            IsActivityIndicatorRunning = true;
            const int distanceMax = 10;
            if (_userService.IsConnected && _userService.IsAuthenticated())
            {
                try
                {
                    var distance = await _userLocationService.CalculateDistanceFromTricycleAsync(tricycle);
                    if (distance < distanceMax)
                    {
                        
                        await Shell.Current.GoToAsync(nameof(TricycleUnlockingPage), true, new Dictionary<string, object>
                        { {"Tricycle", tricycle } });
                        
                    }
                    else
                    {
                        OnDetailsTryToUnlockTooFarFromTheVehicule.Invoke();
                    }
                    IsActivityIndicatorRunning = false;
                }
                catch (PermissionException)
                {
                    PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                    if (status is not PermissionStatus.Granted)
                    {
                        OnDetailsTryToNavigateWithoutLocationAuthorized?.Invoke();
                    }
                }
                catch (FeatureNotEnabledException)
                {
                    OnDetailsTryToNavigateWithoutLocationEnabled?.Invoke();
                }

            }
            if (!_userService.IsConnected)
            {
                OnDetailsTryToNavigateWithoutConnectivity?.Invoke();
            }
            else
            {
                await _userService.GetUserIdentityAsync();
            }
        }
    }
}