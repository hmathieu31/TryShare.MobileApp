using INSAT._4I4U.TryShare.MobileApp.Helpers;
using INSAT._4I4U.TryShare.MobileApp.Infrastructure.Mappers;
using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Preference;

namespace INSAT._4I4U.TryShare.MobileApp.Services.User
{
    public class UserService : IUserService
    {
        private readonly MsalHelper _msalHelper;
        private readonly PreferenceService _preferenceService;

        public UserService(MsalHelper msalHelper, PreferenceService preferenceService)
        {
            this._msalHelper = msalHelper;
            this._preferenceService = preferenceService;
        }

        public Task EditUserProfile()
        {
            throw new NotImplementedException();
        }

        public async Task<UserIdentity> GetUserIdentityAsync()
        {
            var authResult = await _msalHelper.SignInUserAndAcquireAccessTokenAsync(GlobalSettings.Scopes);
            return authResult.ToModel();
        }

        public bool IsAuthenticated()
        {
            // TODO: Implement IsAuthenticated
            if (_msalHelper.AuthResult is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
            Debug.WriteLine("IsAuthenticated not implemented returns true");
            return true;
        }

        public void MapTricycleToUser(Tricycle tricycle, UserIdentity userIdentity)
        {
            userIdentity.BookedTricycle = tricycle;
            _preferenceService.StoreBookedTricycle(userIdentity, tricycle);
        }

        public Task SignInUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task SignOutUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}
