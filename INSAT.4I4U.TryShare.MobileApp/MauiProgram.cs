using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.Services.RequestProvider;
using INSAT._4I4U.TryShare.MobileApp.Services.Tricycles;
using INSAT._4I4U.TryShare.MobileApp.Services.Comments;
using INSAT._4I4U.TryShare.MobileApp.Services.User;
using INSAT._4I4U.TryShare.MobileApp.Services.Booking;
using CommunityToolkit.Maui;
using Microsoft.Identity.Client;
using Microsoft.Maui.LifecycleEvents;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace INSAT._4I4U.TryShare.MobileApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();


		// Import configuration from appsettings
		var a = Assembly.GetExecutingAssembly();
		using var stream = a.GetManifestResourceStream("INSAT._4I4U.TryShare.MobileApp.appsettings.json");

		var config = new ConfigurationBuilder()
			.AddJsonStream(stream)
			.Build();

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

		builder.Configuration.AddConfiguration(config);

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
		    .AddSingleton<CommentPage>()
			.AddTransient<TricycleDetailsPage>()
			.AddTransient<TermsAndConditionsPage>();
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
		    .AddSingleton<CommentViewModel>();
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
			.AddSingleton<ITricycleService, TricycleMockService>()
			.AddSingleton<IRequestProvider, RequestProvider>()
		    .AddSingleton<ICommentService, CommentMockService>()
			.AddSingleton<IRequestProvider, RequestProvider>()
			.AddSingleton<IUserLocationService, UserLocationService>()
			.AddSingleton<IUserSubscriptionService, UserSubscriptionMockService>()
			.AddSingleton<IUserService, UserMockService>()
			.AddSingleton<IBookingService, MockBookingService>();
        return builder;
    }
}
