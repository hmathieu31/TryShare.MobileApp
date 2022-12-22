using INSAT._4I4U.TryShare.MobileApp.Model;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.User
{
    public class UserLocationService : IUserLocationService
    {

        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;
        bool _AreLocationPermissionActivated;
        private Location _userLocation;

        public UserLocationService()
        {
        }

        public async Task GetCurrentLocationAsync()
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                _userLocation= location;
            }
            // Catch one of the following exceptions:
            //   FeatureNotSupportedException
            //   FeatureNotEnabledException
            //   PermissionException
            catch (PermissionException ex)
            {
                // Unable to get location
                _AreLocationPermissionActivated = false;
            }
            finally
            {
                _isCheckingLocation = false;
            }
        }

        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }

        public async Task<double> CalculateDistanceFromTricyle(Tricycle tricycle)
        {
            await GetCurrentLocation();
            return Location.CalculateDistance(_userLocation, tricycle.Location, DistanceUnits.Kilometers);
        }

        public double CalculateDistanceFromTricycle(Tricycle tricycle)
        {
            throw new NotImplementedException();
        }
    }
}
