using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Tricycle;
using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
	[QueryProperty(nameof(Tricycle), "Tricycle")]
	public partial class TricycleDetailsViewModel : BaseViewModel
	{
		public TricycleDetailsViewModel()
		{
		}
		[ObservableProperty]
		Tricycle tricycle;
		[RelayCommand]
		async Task GoToDetails(Tricycle tricycle)
		{
			if (tricycle == null)
			return;
			await Shell.Current.GoToAsync($"nameof(TricycleDetailsPage)?Tricycle={tricycle}");
		}
	}
}