using INSAT._4I4U.TryShare.MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Locking
{
    public class MockLockingService
        : ILockingService
    {
        public Task LockTricycleAsync(Tricycle tricycle)
        {
            throw new NotImplementedException();
        }

        public Task UnlockTricycleAsync(Tricycle tricycle)
        {
            throw new NotImplementedException();
        }
    }
}
