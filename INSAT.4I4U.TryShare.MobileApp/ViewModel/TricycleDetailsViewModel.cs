using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Tricycles;
using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    [QueryProperty(nameof(Tricycle), "Tricycle")]
    public partial class TricycleDetailsViewModel : BaseViewModel, IQueryAttributable
    {

        [ObservableProperty]
        Tricycle tricycle;

        public TricycleDetailsViewModel()
        {
            Console.WriteLine();
            ApplyQueryAttributes(new Dictionary<string, object>
                { {"Tricycle", tricycle } });
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Tricycle = query["Tricycle"] as Tricycle;
            OnPropertyChanged("Tricycle");
        }

        public async Task<string> GetTricycleAddress()
        {
            double latitude = Tricycle.Location.Latitude;
            double longitude = Tricycle.Location.Longitude;

            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(latitude, longitude);

            Placemark placemark = placemarks?.FirstOrDefault();

            if (placemark is not null)
            {
                return
                    $"AdminArea:       {placemark.AdminArea}\n" +
                    $"CountryCode:     {placemark.CountryCode}\n" +
                    $"CountryName:     {placemark.CountryName}\n" +
                    $"FeatureName:     {placemark.FeatureName}\n" +
                    $"Locality:        {placemark.Locality}\n" +
                    $"PostalCode:      {placemark.PostalCode}\n" +
                    $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                    $"SubLocality:     {placemark.SubLocality}\n" +
                    $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                    $"Thoroughfare:    {placemark.Thoroughfare}\n";

            }

            return "";
        }


    }
}