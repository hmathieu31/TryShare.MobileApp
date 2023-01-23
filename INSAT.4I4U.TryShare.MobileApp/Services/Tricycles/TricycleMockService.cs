using INSAT._4I4U.TryShare.MobileApp.Model;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Tricycles
{
    /// <summary>
    /// TODO
    /// This is a mock service for the selectedTricycle service.
    /// </summary>
    public class TricycleMockService : ITricycleService
    {

        private readonly List<Model.Tricycle> tricycleList = new();

        public TricycleMockService()
        {
            tricycleList.Add(new Model.Tricycle { Id = 000001, Location = new Location(43.56, 1.46), BatteryPercentage = 56 });
            tricycleList.Add(new Model.Tricycle { Id = 000002, Location = new Location(43.53, 1.52), BatteryPercentage = 12 });
        }

        public Task<List<Model.Tricycle>> GetTricyclesAsync()
        {
            return Task.FromResult(tricycleList);
        }

    }
}
