using MusicBrainzMauiApp.View;

namespace MusicBrainzMauiApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ArtistsPageView), typeof(ArtistsPageView));
    }
}
