using INSAT._4I4U.TryShare.MobileApp.Helpers;
using INSAT._4I4U.TryShare.MobileApp.Infrastructure.Mappers;
using INSAT._4I4U.TryShare.MobileApp.Model;

namespace INSAT._4I4U.TryShare.MobileApp.Services.User
{
    public class UserService : IUserService
    {
        private readonly MsalHelper _msalHelper;

        public UserService(MsalHelper msalHelper)
        {
                this._msalHelper = msalHelper;
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
        }

        public Task SignOutUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}
