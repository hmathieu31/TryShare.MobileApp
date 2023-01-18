using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    public partial class TricycleUnlockingViewModel : BaseViewModel
    {
        [RelayCommand]
        async static Task GoBackToHome()
        {
            // TODO: Debugging return
            Debug.WriteLine("Returning to main page default");
            await Shell.Current.Navigation.PopToRootAsync();
        }
    }
}
