using INSAT._4I4U.TryShare.MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Booking
{
    public class MockBookingService
        : IBookingService
    {

        public async Task<bool> BookTricycleAsync(Tricycle tricycle)
        {
            if (tricycle is null)
                throw new ArgumentNullException(nameof(tricycle));

            if (!await CanTricycleBeBooked(tricycle))
                return false;

            Debug.WriteLine($"Booking tricycle {tricycle.Id}");
            return true;
        }

        public Task<bool> CanTricycleBeBooked(Tricycle tricycle)
        {
            // TODO: Implement cient-side booking validation
            return Task.FromResult(true);
        }
    }
}
