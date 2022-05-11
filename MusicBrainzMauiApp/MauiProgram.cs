using MusicBrainzMauiApp.ViewModel;
using MusicBrainzMauiApp.View;
using MusicBrainzMauiApp.Services;

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

		//Is order important ?? 
		builder.Services.AddSingleton<MusicBrainzClientService>();
		builder.Services.AddSingleton<ArtistsViewModel>();
		builder.Services.AddSingleton<ArtistsPageView>();
		builder.Services.AddSingleton<MainPageView>(); // Do not Forget!! 

		return builder.Build();
	}
}
