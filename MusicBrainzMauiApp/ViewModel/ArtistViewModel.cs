using CommunityToolkit.Mvvm.ComponentModel;

using MusicBrainzMauiApp.Model;

namespace MusicBrainzMauiApp.ViewModel
{
    [QueryProperty(nameof(Artist), nameof(Artist))]
    public partial class ArtistViewModel :BaseViewModel
    {
        public ArtistViewModel()
        {

        }

        [ObservableProperty]
        Artist artist;

    }
}
