using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;
using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.Services.Tricycles;
using Microsoft.Maui.Maps;
using INSAT._4I4U.TryShare.MobileApp.Helpers;
using INSAT._4I4U.TryShare.MobileApp.Settings;
using INSAT._4I4U.TryShare.MobileApp.Services.User;
using INSAT._4I4U.TryShare.MobileApp.Services.Booking;
using CommunityToolkit.Mvvm.Messaging;
using INSAT._4I4U.TryShare.MobileApp.Message;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Threading.Tasks;
using System.Threading;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        readonly ITricycleService tricycleService;
        private readonly MsalHelper msal;
        private readonly IBookingService bookingService;

        [RelayCommand]
        async Task Authenticate()
        {
            var result = await msal.SignInUserAndAcquireAccessTokenAsync(GlobalSettings.Scopes);
            Debug.WriteLine(result);
        }

        public ObservableCollection<Tricycle> Tricycles { get; } = new();

        public ObservableCollection<CircleZone> ReturnZones { get; } = new();

        [ObservableProperty]
        private bool isPopupVisible = false;

        [ObservableProperty]
        private Tricycle selectedTricycle;

        [ObservableProperty]
        private bool isReturnable;

        [ObservableProperty]
        private Distance circleRadius = new(5000);

        [ObservableProperty]
        private bool isMapReady;
        public MainPageViewModel(ITricycleService tricycleService,
                                 MsalHelper msal,
                                 IBookingService bookingService)
        {
            this.tricycleService = tricycleService;
            this.msal = msal;
            this.bookingService = bookingService;
        }

        static void ShowReturnZoneToast()
        {

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string text = "La zone de retour du Tricyle apparait en rouge";
            ToastDuration duration = ToastDuration.Long;
            double fontSize = 20;

            var toast = Toast.Make(text, duration, fontSize);
            toast.Show(cancellationTokenSource.Token);
        }

        public void ShowReturnZoneCircle()
        {
            ReturnZones.First().IsVisible = true;
        }

        public void OnAppearing()
        {
            SetReturnZones();
            _ = JustBookedCheckAsync();
            try
            {
                WeakReferenceMessenger.Default.Register<MainPageViewModel, BookingCompletedMessage>(this, (r, m) =>
                {
                    ShowReturnZoneToast();
                    ShowReturnZoneCircle();
                });
            }
            catch (InvalidOperationException ex)
            {

                Debug.WriteLine(ex);
            }

        }

        private void SetReturnZones()
        {
            ReturnZones.Clear();

            // For current debug purposes
            var toulouseRadius = new Distance(5000);
            var toulouseCenter = new Location(43.599498414198386, 1.4372202194252555);

            var toulouseReturnZone = new CircleZone
            {
                Center = toulouseCenter,
                Radius = toulouseRadius,
                FillColor = Color.FromRgba(0, 0, 255, 0.2),
                StrokeColor = Color.FromRgba(0, 0, 255, 0.5),
                StrokeWidth = 2,
                IsVisible = true,
            };

            ReturnZones.Add(toulouseReturnZone);
            IsMapReady = true;
        }

        public void DisplayPopup(int id)
        {
            SelectedTricycle = Tricycles.First(x => x.Id == id);
            IsPopupVisible = true;
        }

        public void HidePopup()
        {
            IsPopupVisible = false;
        }

        public async Task JustBookedCheckAsync()
        {
            if (await bookingService.CanTricycleBeBookedAsync(SelectedTricycle))
                IsReturnable = false;
            else IsReturnable = true;
        }

        [RelayCommand]
        async Task GetTricyclesAsync()
        {

            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var list = await tricycleService.GetTricyclesAsync();

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
        async Task GoToPostBookingAsync(Tricycle tricycle)
        {
            await Shell.Current.GoToAsync(nameof(PostBookingPage), true, new Dictionary<string, object>
            { {"Tricycle", tricycle}});
            IsPopupVisible = false;
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

