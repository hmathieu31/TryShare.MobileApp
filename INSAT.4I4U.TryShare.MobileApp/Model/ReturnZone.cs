using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Model
{
    public class ReturnZone
    {
        private const int toulouseRadius = 5000;
        private static readonly Location toulouseCenter = new(43.599498414198386, 1.4372202194252555);

        public Location Center { get; } = toulouseCenter;

        public double Radius => IsVisible ? toulouseRadius : 0;

        public required bool IsVisible { get; set; }
    }
}
