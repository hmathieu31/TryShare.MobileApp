using INSAT._4I4U.TryShare.MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Booking
{
    public class MockBookingService : IBookingService
    {

        public Task<bool> RequestTricycleBookingAsync(Tricycle tricycle)
        {
            if (tricycle is null)
                throw new ArgumentNullException(nameof(tricycle));
            
            return RequestTricycleBookingInternalAsync(tricycle);
        }

        private async Task<bool> RequestTricycleBookingInternalAsync(Tricycle tricycle)
        {
            if (!await CanTricycleBeBookedAsync(tricycle))
                return false;

            Debug.WriteLine($"Booking selectedTricycle {tricycle.Id}");
            return true;
        }

        public Task<bool> CanTricycleBeBookedAsync(Tricycle tricycle)
        {
            Debug.WriteLine("Checking if the selectedTricycle can be booked");
            return Task.FromResult(true);
        }

        public Task<bool> RequestEndOfBookingAsync(Tricycle tricycle)
        {
            
            Debug.WriteLine("User requesting the end of its booking");
            return Task.FromResult(true);
        }
    }
}
