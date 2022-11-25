using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSAT._4I4U.TryShare.MobileApp.Model;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Trycicle
{
    /// <summary>
    /// TODO
    /// This is a mock service for the tricycle service.
    /// </summary>
    public class TrycicleMockService : ITrycicleService
    {

        public List<Tricycle> tricycleList = new();

        //public List<Tricycle> getMockTricycleList()
        public async Task<List<Tricycle>> GetMockTrycicleList()
        {
            tricycleList.Add(new Tricycle { Id = 000001, Location = new Location(43.56, 1.46), BatteryPercentage = 12 });
            tricycleList.Add(new Tricycle { Id = 000002, Location = new Location(43.53, 1.52), BatteryPercentage = 12 });
            return tricycleList;
        }


    }
}
