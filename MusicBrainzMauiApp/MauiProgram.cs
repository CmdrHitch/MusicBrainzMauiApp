using Microsoft.Maui.LifecycleEvents;
#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif
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

        builder.Services.AddSingleton<MusicBrainzClientService>();

        builder.Services.AddSingleton<MainPageView>();
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddTransient<ArtistsViewModel>();
		builder.Services.AddTransient<ArtistsView>();
        builder.Services.AddTransient<ArtistViewModel>();
        builder.Services.AddTransient<ArtistView>();
        builder.Services.AddTransient<AlbumViewModel>();
        builder.Services.AddTransient<AlbumView>();
     

#if WINDOWS
            builder.ConfigureLifecycleEvents(events =>
            {
                events.AddWindows(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.OnWindowCreated(window =>
                    {
                        IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                        AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);

                        const int width = 1200;
                        const int height = 800;
                        winuiAppWindow.MoveAndResize(new RectInt32(1920 / 2 - width / 2, 1080 / 2 - height / 2, width, height));
                    });
                });
            });
#endif

        return builder.Build();
	}
}
