using INSAT._4I4U.TryShare.MobileApp.Infrastructure.Dto;
using INSAT._4I4U.TryShare.MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Infrastructure.Mappers
{
    public static class TricycleMapper
    {
        public static Tricycle ToModel(this TricycleDto tricycleDto)
        {
            return new Tricycle
            {
                Id = tricycleDto.Id,
                Location = new Location(tricycleDto.LastKnownLatitude, tricycleDto.LastKnownLongitude),
                BatteryPercentage = tricycleDto.BatteryPercentage,
            };
        }
    }
}
