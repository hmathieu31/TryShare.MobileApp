using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;
using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.Services.Tricycles;
using Microsoft.Maui.Maps;
using INSAT._4I4U.TryShare.MobileApp.Helpers;
using INSAT._4I4U.TryShare.MobileApp.Services.Booking;
using CommunityToolkit.Mvvm.Messaging;
using INSAT._4I4U.TryShare.MobileApp.Message;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using INSAT._4I4U.TryShare.MobileApp.Services.User;
using INSAT._4I4U.TryShare.MobileApp.Services.ReturnZones;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        readonly ITricycleService _tricycleService;
        private readonly IBookingService bookingService;
        private readonly IUserLocationService _userLocationService;
        private readonly IReturnZonesService _returnZonesService;

        public ObservableCollection<Tricycle> Tricycles { get; } = new();

        public ObservableCollection<ReturnZone> ReturnZones { get; } = new();

        [ObservableProperty]
        private bool isPopupVisible = false;

        [ObservableProperty]
        private Tricycle? selectedTricycle;

        [ObservableProperty]
        private bool isReturnable;

        [ObservableProperty]
        private bool isMapReady;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsReturnButtonVisible))]
        private Tricycle? bookedTricycle;

        public bool IsReturnButtonVisible => BookedTricycle is not null;

        public MainPageViewModel(ITricycleService tricycleService,
                                 IBookingService bookingService,
                                 IUserLocationService userLocationService,
                                 IReturnZonesService returnZonesService)
        {
            this._tricycleService = tricycleService;
            this.bookingService = bookingService;
            this._userLocationService = userLocationService;
            this._returnZonesService = returnZonesService;
        }


        static void ShowReturnZoneToast(string message)
        {

            CancellationTokenSource cancellationTokenSource = new();

            string text = message;
            ToastDuration duration = ToastDuration.Long;
            double fontSize = 20;

            var toast = Toast.Make(text, duration, fontSize);
            toast.Show(cancellationTokenSource.Token);
        }

        public void ShowReturnZoneCircle()
        {
            ReturnZones.First().IsVisible = true;
        }

        public async void OnNavigatedFrom(TricycleUnlockingPage tricycleUnlockingPage, EndOfBookingPage endOfBookingPage)
        {
            await GetTricyclesAsync();
            //TODO Instanciate bookedTricycle
        }
        public async void OnAppearing()
        {
            await GetTricyclesAsync();
            //TODO Instanciate bookedTricycle
            GetReturnZones();

            await JustBookedCheckAsync();
            try
            {
                WeakReferenceMessenger.Default.Register<MainPageViewModel, BookingCompletedMessage>(this, (r, m) =>
                {
                    ShowReturnZoneToast("La zone de retour du Tricyle apparait en rouge.");
                    ShowReturnZoneCircle();
                });
            }
            catch (InvalidOperationException ex)
            {

                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Displays the popup for the selected tricycle when a pin is clicked on the map.
        /// The popup is displayed only if the user has no ongoing booking.
        /// </summary>
        /// <param name="id">ID of the SelectedTricycle</param>
        public void DisplaySelectedTricyclePopup(int id)
        {
            if (BookedTricycle is not null)
                return;
            
            SelectedTricycle = Tricycles.First(x => x.Id == id);
            IsPopupVisible = true;
        }

        /// <summary>
        /// Hides the popup for the selected tricycle.
        /// </summary>
        public void HideSelectedTricyclePopup()
        {
            IsPopupVisible = false;
        }

        public async Task JustBookedCheckAsync()
        {
            if (BookedTricycle is null)
                throw new InvalidOperationException($"{nameof(BookedTricycle)} should not be null");

            if (await bookingService.CanTricycleBeBookedAsync(BookedTricycle))
                IsReturnable = false;
            else
                IsReturnable = true;
        }

        void GetReturnZones()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            var list = _returnZonesService.GetAllReturnZones();

            if (ReturnZones.Count != 0)
                ReturnZones.Clear();

            foreach (var returnZone in list)
                ReturnZones.Add(returnZone);
            IsBusy = false;
        }

        [RelayCommand]
        async Task GetTricyclesAsync()
        {

            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var list = await _tricycleService.GetTricyclesAsync();

                if (Tricycles.Count != 0)
                    Tricycles.Clear();

                foreach (var tricycle in list)
                    Tricycles.Add(tricycle);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get tricycles {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GoToEndOfBookingAsync(Tricycle tricycle)
        {
            if (await _userLocationService.IsUserInReturnZoneAsync(ReturnZones.First()))
            {
                await Shell.Current.GoToAsync(nameof(EndOfBookingPage), true, new Dictionary<string, object>
            { {"Tricycle", tricycle}});
                IsPopupVisible = false;
            }
            else
            {
                ShowReturnZoneToast("Veuillez retourner le tricyle dans la zone de retour !");
                ShowReturnZoneCircle();
            }

        }

        [RelayCommand]
        async Task GoToDetailsAsync(Tricycle tricycle)
        {
            await Shell.Current.GoToAsync(nameof(TricycleDetailsPage), true, new Dictionary<string, object>
                { {"Tricycle", tricycle } });
            IsPopupVisible = false;
        }
    }
}

