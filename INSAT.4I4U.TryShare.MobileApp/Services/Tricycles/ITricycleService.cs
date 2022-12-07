using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSAT._4I4U.TryShare.MobileApp.Model;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Tricycles
{
    /// <summary>
    /// Service to access the data on Tricycles
    /// </summary>
    public interface ITricycleService
    {
        /// <summary>
        /// Gets the tricycles availables.
        /// </summary>
        /// <returns>A List of Tricycles if the client is connected to the Internet</returns>
        /// <exception cref="NotImplementedException">Offline functionality not implemented</exception>
        public Task<List<Tricycle>> GetTricyclesAsync();

    }
}
