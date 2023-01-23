using INSAT._4I4U.TryShare.MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Booking
{
    /// <summary>
    /// A service to allow the booking of tricycles.
    /// The booking consists only in the reservation of the selectedTricycle for the user
    /// and not the unlocking.
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Request the booking of the selectedTricycle.
        /// </summary>
        /// <param name="tricycle">The selectedTricycle to book</param>
        /// <returns>False if the booking order was not allowed</returns>
        /// <exception cref="NotImplementedException">Offline functionality not implemented</exception>
        public Task<bool> RequestTricycleBookingAsync(Tricycle tricycle);

        /// <summary>
        /// Request the end of the current selectedTricycle booking for the user.
        /// </summary>
        /// <returns>False if the end of the booking was not allowed</returns>
        public Task<bool> RequestEndOfBookingAsync(Tricycle tricycle);

        /// <summary>
        /// Determines whether the selectedTricycle can be booked the specified selectedTricycle.
        /// </summary>
        /// <param name="tricycle">The selectedTricycle.</param>
        /// <returns>true if the selectedTricycle can be booked</returns>
        public Task<bool> CanTricycleBeBookedAsync(Tricycle tricycle);
    }
}
