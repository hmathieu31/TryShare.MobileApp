using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSAT._4I4U.TryShare.MobileApp.Model;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Tricycles
{
    /// <summary>
    /// TODO Define the interface
    /// </summary>
    public interface ITricycleService
    {

        public Task<List<Tricycle>> GetTricyclesAsync();

    }
}
