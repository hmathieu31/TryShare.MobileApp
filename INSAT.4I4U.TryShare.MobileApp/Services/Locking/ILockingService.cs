using INSAT._4I4U.TryShare.MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Locking
{
    public interface ILockingService
    {
        /// <summary>
        /// Locks the tricycle.
        /// </summary>
        /// <param name="tricycle">The tricycle.</param>
        /// <exception cref="NotImplementedException">Offline functionality not implemented</exception>
        public Task LockTricycleAsync(Tricycle tricycle);

        /// <summary>
        /// Unlocks the tricycle.
        /// </summary>
        /// <param name="tricycle">The tricycle.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">Offline functionality not implemented</exception>
        public Task UnlockTricycleAsync(Tricycle tricycle);
    }
}
