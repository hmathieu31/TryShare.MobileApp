using INSAT._4I4U.TryShare.MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.User
{
    public class UserMockService : IUserService
    {
        public Task EditUserProfile()
        {
            throw new NotImplementedException();
        }

        public Task<Tricycle> GetTricycleFromUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserIdentity> GetUserIdentityAsync()
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated()
        {
            return true;
        }

        public void RemoveTricycleToUser(UserIdentity userIdentity)
        {
            throw new NotImplementedException();
        }

        public void SetTricycleToUser(Tricycle tricycle, UserIdentity userIdentity)
        {
            throw new NotImplementedException();
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
