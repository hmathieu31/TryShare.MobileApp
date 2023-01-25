using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Tricycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Preference
{
    public class PreferenceService
    {
        private readonly ITricycleService _tricycleService;

        public PreferenceService(ITricycleService tricycleService)
        {
            this._tricycleService = tricycleService;
        }
        public void StoreBookedTricycle(UserIdentity userIdentity, Tricycle tricycle)
        {
            Preferences.Default.Set(userIdentity.Email, tricycle.Id);
        }

        public async Task<Tricycle> GetBookedTricycleAsync(UserIdentity userIdentity)
        {
            var id = Preferences.Default.Get(userIdentity.Email, -1);
            var tricycle = await _tricycleService.GetTricycleByIdAsync(id);
            return tricycle;
        }

        public void RemoveBookedTricycle(UserIdentity userIdentity)
        {
            var id = Preferences.Default.Get(userIdentity.Email, -1);
            if (id is -1)
                throw new InvalidOperationException("No tricycle registered in preferences");
            Preferences.Default.Remove(userIdentity.Email);
        }
    }
}
