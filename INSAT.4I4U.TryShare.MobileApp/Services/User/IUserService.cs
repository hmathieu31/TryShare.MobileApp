﻿using INSAT._4I4U.TryShare.MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.User
{
    public interface IUserService
    {
        /// <exception cref="NotImplementedException">Offline functionality not implemented</exception>
        public bool IsConnected => Connectivity.Current.NetworkAccess == NetworkAccess.Internet;

        public bool IsAuthenticated();

        public Task<UserIdentity> GetUserIdentityAsync();

        public Task SignInUserAsync();

        public Task SignOutUserAsync();

        public Task EditUserProfile();

    }
}
