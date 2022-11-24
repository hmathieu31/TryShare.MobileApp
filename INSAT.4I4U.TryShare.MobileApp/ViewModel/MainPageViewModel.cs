using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;
using INSAT._4I4U.TryShare.MobileApp.Model;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {

        readonly ObservableCollection<Tricycle> _tricycle;
        public IEnumerable Tricycle => _tricycle;
        public ICommand GetTricycleCommand { get; }

        public MainPageViewModel()
        {
            _tricycle = new ObservableCollection<Tricycle>();
            _tricycle.Add(new Tricycle { Id = 1, Location = new Location(43.56, 1.46), BatteryPercentage = 12 });
            _tricycle.Add(new Tricycle { Id = 2, Location = new Location(43.53, 1.52), BatteryPercentage = 12 });
        }


    }
}

