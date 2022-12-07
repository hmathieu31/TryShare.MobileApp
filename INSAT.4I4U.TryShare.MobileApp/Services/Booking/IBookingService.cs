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
    /// The booking consists only in the reservation of the tricycle for the user
    /// and not the unlocking.
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Book a tricycle
        /// </summary>
        /// <param name="tricycle">The tricycle to book</param>
        /// <returns>False if the booking order was not allowed</returns>
        /// <exception cref="NotImplementedException">Offline functionality not implemented</exception>
        public Task<bool> BookTricycleAsync(Tricycle tricycle);

        /// <summary>
        /// Determines whether the tricycle can be booked the specified tricycle.
        /// </summary>
        /// <param name="tricycle">The tricycle.</param>
        /// <returns>true if the tricycle can be booked</returns>
        public Task<bool> CanTricycleBeBooked(Tricycle tricycle);
    }
}
