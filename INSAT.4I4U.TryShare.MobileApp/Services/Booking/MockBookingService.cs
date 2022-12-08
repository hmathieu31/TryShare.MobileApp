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

        public Task<bool> RequestTricycleBookingAsync(Tricycle tricycle)
        {
            if (tricycle is null)
                throw new ArgumentNullException(nameof(tricycle));
            
            return RequestTricycleBookingInternalAsync(tricycle);
        }

        private async Task<bool> RequestTricycleBookingInternalAsync(Tricycle tricycle)
        {
            if (!await CanTricycleBeBooked(tricycle))
                return false;

            Debug.WriteLine($"Booking tricycle {tricycle.Id}");
            return true;
        }

        public Task<bool> CanTricycleBeBooked(Tricycle tricycle)
        {
            Debug.WriteLine("Checking if the tricycle can be booked");
            return Task.FromResult(true);
        }

        public Task<bool> RequestTricycleBookingEndAsync()
        {
            
            Debug.WriteLine("User requesting the end of its booking");
            return Task.FromResult(true);
        }
    }
}
