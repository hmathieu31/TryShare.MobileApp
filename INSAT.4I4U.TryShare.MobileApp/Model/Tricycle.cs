using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Model
{
    /// <summary>
    /// The connected Tricycle.
    /// </summary>
    public class Tricycle
    {
        [Key]
        public required int Id { get; set; }
        
        public required Location Location { get; set; }

        [Range(0, 100, ErrorMessage = "The value must be a whole percentage")]
        public required int BatteryPercentage { get; set; }

        public double BatteryPercentageBetween0and1 => BatteryPercentage / 100.0;

        public float Rating { get; set; }

    }
}
