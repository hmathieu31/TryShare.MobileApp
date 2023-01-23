using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Range(0, 100, ErrorMessage = "Battery percentage must be between 0 and 100")]
        public int BatteryPercentage { get; set; }
        public bool IsAvailable { get; set; }
        [Range(0, 5, ErrorMessage = "The rating must be between 0 and 5")]
        public int Rating { get; set; }
    }
}
