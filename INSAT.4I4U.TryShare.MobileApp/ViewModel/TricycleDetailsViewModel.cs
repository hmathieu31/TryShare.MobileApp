using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Tricycles;
using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;
using System.Windows.Input;

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

        [ObservableProperty]
        private bool isTermsAndConditionsPopupVisible = false;

        /// <summary>
        /// Postal address of the tricycle following the format "street, city"
        /// </summary>
        [ObservableProperty]
        string tricycleAddress = "";

        /// <summary>
        /// Sets the ObservableProperty of the postal address of the tricycle.
        /// Asynchronously uses the Geocoding Service to get the address from the tricycle's location.
        /// </summary>
        /// <remarks>
        /// The address set is follows the format : "Street, City"
        /// </remarks>
        public async Task SetTricycleAddressLabelAsync()
        {
            double latitude = Tricycle.Location.Latitude;
            double longitude = Tricycle.Location.Longitude;

            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(latitude, longitude);

            Placemark placemark = placemarks?.FirstOrDefault();

            if (placemark is not null)
                TricycleAddress = $"{placemark.Thoroughfare}, {placemark.Locality}";

            //return
            //    $"AdminArea:       {placemark.AdminArea}\n" +
            //    $"CountryCode:     {placemark.CountryCode}\n" +
            //    $"CountryName:     {placemark.CountryName}\n" +
            //    $"FeatureName:     {placemark.FeatureName}\n" +
            //    $"Locality:        {placemark.Locality}\n" +
            //    $"PostalCode:      {placemark.PostalCode}\n" +
            //    $"SubAdminArea:    {placemark.SubAdminArea}\n" +
            //    $"SubLocality:     {placemark.SubLocality}\n" +
            //    $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
            //    $"Thoroughfare:    {placemark.Thoroughfare}\n";
        }

        [RelayCommand]
        public async Task GoToMoreComments(Uri url) => await Launcher.OpenAsync(url);



        public void DisplayTermsAndConditionsPopup()
        {
            IsTermsAndConditionsPopupVisible = true;
        }

        [RelayCommand]
        public void GoBackToDetails()
        {
            IsTermsAndConditionsPopupVisible = false;
        }


    }
}