using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Infrastructure.Dto
{
    /// <summary>
    /// A DTO for the Tricycle in the API
    /// </summary>
    /// <remarks>
    /// Could be changed into an automatic implementation with connected services.
    /// </remarks>
    public class TricycleDto
    {
        public int Id { get; set; }
        public double LastKnownLatitude { get; set; }
        public double LastKnownLongitude { get; set; }
        public int BatteryPercentage { get; set; }
        public bool IsAvailable { get; set; }
    }
}
