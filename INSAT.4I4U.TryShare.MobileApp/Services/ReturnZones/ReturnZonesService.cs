using INSAT._4I4U.TryShare.MobileApp.Model;
using Microsoft.Maui.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.ReturnZones
{
    public class ReturnZonesService : IReturnZonesService
    {
        readonly IEnumerable<ReturnZone> returnZones;
        
        public ReturnZonesService()
        {
            var toulouseRadius = new Distance(50000);
            var toulouseCenter = new Location(43.570565, 1.466504);//Toulouse
            //var norvegeCenter = new Location(59, 5.7);//Norvège
            var toulouseReturnZone = new ReturnZone
            {
                Center = toulouseCenter,
                Radius = toulouseRadius,
                FillColor = Color.FromRgba(0, 0, 255, 0.2),
                StrokeColor = Color.FromRgba(0, 0, 255, 0.5),
                StrokeWidth = 2,
                IsVisible = true,
            };
            returnZones = new List<ReturnZone> { toulouseReturnZone };
        }
        
        public IEnumerable<ReturnZone> GetAllReturnZones()
        {
            return returnZones;
        }
    }
}
