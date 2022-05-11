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

		//Order is important or get that pesky debugger message.
		builder.Services.AddSingleton<MusicBrainzClientService>();
		builder.Services.AddSingleton<ArtistViewModel>();
		builder.Services.AddSingleton<MainPage>(); // Do not Forget!! 

		return builder.Build();
	}
}
