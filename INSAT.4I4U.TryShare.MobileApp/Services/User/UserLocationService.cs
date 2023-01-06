using INSAT._4I4U.TryShare.MobileApp.Model;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.User
{
    public class UserLocationService : IUserLocationService
    {

        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        public UserLocationService()
        {
        }

        private async Task<Location> GetCurrentLocationAsync()
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new (GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                return location;
            }
            // Catch one of the following exceptions:
            //   FeatureNotSupportedException
            //   FeatureNotEnabledException
            //   PermissionException
            finally
            {
                _isCheckingLocation = false;
            }
        }

        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource is not null && !_cancelTokenSource.IsCancellationRequested)
                _cancelTokenSource.Cancel();
        }

        public async Task<double> CalculateDistanceFromTricycleAsync(Tricycle tricycle)
        {
            var location = await GetCurrentLocationAsync();
            return Location.CalculateDistance(location, tricycle.Location, DistanceUnits.Kilometers);
        }

    }
}
