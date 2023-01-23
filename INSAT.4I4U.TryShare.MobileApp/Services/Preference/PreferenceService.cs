using INSAT._4I4U.TryShare.MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Preference
{
    public class PreferenceService
    {
        public void StoreBookedTricycle(UserIdentity userIdentity, Tricycle tricycle)
        {
            Preferences.Default.Set(userIdentity.Email, tricycle.Id);
        }
    }
}
