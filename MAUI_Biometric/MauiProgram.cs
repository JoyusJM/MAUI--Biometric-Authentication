using Microsoft.Extensions.Logging;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace MAUI_Biometric;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		//Biometric authetication
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton(typeof(IFingerprint), CrossFingerprint.Current);


        return builder.Build();
	}
}

