using MusicBrainzMauiApp.ViewModel;
using MusicBrainzMauiApp.View;

namespace MusicBrainzMauiApp;

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

		builder.Services.AddSingleton<MBSearchViewModel>();
		builder.Services.AddSingleton<MainPage>(); // Do not Forget!! 

		return builder.Build();
	}
}
