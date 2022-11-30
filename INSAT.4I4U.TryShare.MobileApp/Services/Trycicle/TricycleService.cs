﻿using INSAT._4I4U.TryShare.MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Tricycle
{
    /// <summary>
    /// TODO
    /// Service to access the data on Tricycles
    /// </summary>
    public class TricycleService : ITricycleService
    {

        private List<Model.Tricycle> tricycleList = new();

        public Task<List<Model.Tricycle>> GetTricycleList()
        {
            return Task.FromResult(tricycleList);
        }

    }
}
