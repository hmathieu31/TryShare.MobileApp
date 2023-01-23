using INSAT._4I4U.TryShare.MobileApp.Infrastructure.Dto;
using INSAT._4I4U.TryShare.MobileApp.Model;

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
                Rating = tricycleDto.Rating,
            };
        }

        public static TricycleDto ToDto(this Tricycle tricycle)
        {
            return new TricycleDto
            {
                Id = tricycle.Id,
                LastKnownLatitude = tricycle.Location.Latitude,
                LastKnownLongitude = tricycle.Location.Longitude,
                BatteryPercentage = tricycle.BatteryPercentage,
                Rating = tricycle.Rating,
            };
        }
    }
}
