using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

using MusicBrainzMauiApp.Model;
using MusicBrainzMauiApp.Services;

namespace MusicBrainzMauiApp.ViewModel
{
    [QueryProperty(nameof(Artist), nameof(Artist))]
    public partial class ArtistViewModel :BaseViewModel
    {
        [ObservableProperty]
        Artist artist;

        [ObservableProperty]
        string test = "I am Test!";


        public ObservableCollection<Recording>Recordings { get; set; } = new();
        
        private MusicBrainzClientService client;
        private SearchQuery searchQuery;

        private static int limit = 5;
        public ArtistViewModel(MusicBrainzClientService client)
        {
            this.client = client;
            searchQuery = new SearchQuery();
        }

        public async void GetRecordings()
        {
            var Recordings = await client.GetRecordings(artist);
            test = "I have changed";
        }
    }
}
