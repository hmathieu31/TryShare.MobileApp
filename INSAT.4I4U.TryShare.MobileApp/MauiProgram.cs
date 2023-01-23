using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.Services.RequestProvider;
using INSAT._4I4U.TryShare.MobileApp.Services.Tricycles;
using INSAT._4I4U.TryShare.MobileApp.Services.Comments;
using INSAT._4I4U.TryShare.MobileApp.Services.User;
using INSAT._4I4U.TryShare.MobileApp.Services.Booking;
using Microsoft.Identity.Client;
using Microsoft.Maui.LifecycleEvents;
using INSAT._4I4U.TryShare.MobileApp.Helpers;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.ProfileFlyoutHeader;
using CommunityToolkit.Maui;
using INSAT._4I4U.TryShare.MobileApp.Services.Preference;
using INSAT._4I4U.TryShare.MobileApp.ViewModel;
using INSAT._4I4U.TryShare.MobileApp.Services.ReturnZones;

namespace INSAT._4I4U.TryShare.MobileApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureLifecycleEvents(events =>
            {
#if ANDROID
            events.AddAndroid(platform =>
            {
                platform.OnActivityResult((activity, rc, result, data) =>
                {
                    AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(rc, result, data);
                });
            });
#endif
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseMauiMaps();

        builder
            .RegisterViews()
            .RegisterServices()
            .RegisterViewModels();

        return builder.Build();
    }

	/// <summary>
	/// Register the Views.
	/// </summary>
	/// <param name="builder"></param>
	/// <returns></returns>
	private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
	{
		builder.Services
			.AddSingleton<MainPage>()
			.AddTransient<TricycleDetailsPage>()
		    .AddTransient<CommentPage>()
			.AddTransient<TermsAndConditionsPage>()
			.AddTransient<TricycleUnlockingPage>()
            .AddTransient<EndOfBookingPage>();
		return builder;
	}

    /// <summary>
	/// Register the ViewModels.
	/// </summary>
	/// <param name="builder"></param>
	/// <returns></returns>
    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services
			.AddSingleton<MainPageViewModel>()
		    .AddTransient<TricycleDetailsViewModel>()
            .AddTransient<ProfileFlyoutViewModel>()
		    .AddSingleton<CommentViewModel>()
            .AddTransient<EndOfBookingViewModel>()
			.AddTransient<TricycleUnlockingViewModel>();
        return builder;
    }

    /// <summary>
	/// Register the Services.
	/// </summary>
	/// <param name="builder"></param>
	/// <returns></returns>
    private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services
            .AddSingleton<ITricycleService, TricycleService>()
            .AddSingleton<IRequestProvider, RequestProvider>()
            .AddSingleton<ICommentService, CommentMockService>()
            .AddSingleton<IRequestProvider, RequestProvider>()
            .AddSingleton<IUserLocationService, UserLocationService>()
            .AddSingleton<IUserSubscriptionService, UserSubscriptionMockService>()
            .AddSingleton<IUserService, UserService>()
            .AddSingleton<IBookingService, BookingService>()
            .AddSingleton<PreferenceService>();
            .AddSingleton<IReturnZonesService, ReturnZonesService>()
            .AddSingleton<MsalHelper>();
        return builder;
    }
}
