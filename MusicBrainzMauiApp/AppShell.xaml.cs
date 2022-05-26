using MusicBrainzMauiApp.View;

namespace MusicBrainzMauiApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ArtistsView), typeof(ArtistsView));
        Routing.RegisterRoute(nameof(ArtistView), typeof(ArtistView));
        Routing.RegisterRoute(nameof(AlbumView), typeof(AlbumView));
    }
}
