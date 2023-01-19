using INSAT._4I4U.TryShare.MobileApp.Exceptions;
using INSAT._4I4U.TryShare.MobileApp.Helpers;
using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.RequestProvider;
using INSAT._4I4U.TryShare.MobileApp.Services.User;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Booking
{
    public class BookingService : IBookingService
    {
        readonly IRequestProvider _requestProvider;
        readonly IUserService _userService;
        private const string _apiUrlTricycle = "api/Tricycles/";
        private static bool IsConnectedInternet => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public BookingService(IRequestProvider requestProvider, IUserService userService)
        {
            this._requestProvider = requestProvider;
            this._userService = userService;
        }

        public Task<bool> CanTricycleBeBookedAsync(Tricycle tricycle)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RequestTricycleBookingAsync(Tricycle tricycle)
        {
            int id = tricycle.Id;
            var user = await _userService.GetUserIdentityAsync();
            var token = user.AccessToken;

            if (IsConnectedInternet)
            {
                var uri = UriHelper.CombineUri(GlobalSettings.DefaultEndpoint, $"{_apiUrlTricycle}", $"{id}/requestBooking");

                try
                {
                    await _requestProvider.PostAsync(uri, "", shouldReturnContent: false);
                    return true;
                }
                catch (ServiceAuthentificationException)
                {
                    return false;
                }
                
            }
            else
            {
                throw new NotImplementedException("Offline functionality not implemented");
            }
        }

        public async Task<bool> RequestEndOfBookingAsync(Tricycle tricycle)
        {
            int id = tricycle.Id;
            var user = await _userService.GetUserIdentityAsync();
            var token = user.AccessToken;

            if (IsConnectedInternet)
            {
                var uri = UriHelper.CombineUri(GlobalSettings.DefaultEndpoint, $"{_apiUrlTricycle}", $"{id}/requestEndOfBooking");

                try
                {
                    await _requestProvider.PostAsync(uri, "", token, shouldReturnContent: false);
                    return true;
                }
                catch (ServiceAuthentificationException)
                {
                    return false;
                }

            }
            else
            {
                throw new NotImplementedException("Offline functionality not implemented");
            }
        }
    }
}
