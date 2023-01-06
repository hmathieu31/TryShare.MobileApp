using INSAT._4I4U.TryShare.MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.User
{
    public class UserLocationMockService : IUserLocationService
    {
        public UserLocationMockService()
        {
        }

        public Task<double> CalculateDistanceFromTricycleAsync(Tricycle tricycle)
        {
            return Task.FromResult(Location.CalculateDistance(new Location(43.56, 1.47), tricycle.Location, DistanceUnits.Kilometers));
        }
    }
}
