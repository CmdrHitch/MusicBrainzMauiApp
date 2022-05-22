using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;


using MusicBrainzMauiApp.Model;
using MusicBrainzMauiApp.Services;

namespace MusicBrainzMauiApp.ViewModel
{
    [QueryProperty(nameof(Artist), nameof(Artist))]
    public partial class ArtistViewModel :BaseViewModel
    {
        [ObservableProperty]
        Artist artist;

        public ObservableCollection<Release> Releases { get; set; } = new();
        
        private MusicBrainzClientService client;
        private SearchQuery searchQuery;

        private static int limit = 5;
        public ArtistViewModel(MusicBrainzClientService client)
        {
            this.client = client;
            searchQuery = new SearchQuery();
        }

        [ObservableProperty]
        bool isRefreshing;
        public async Task LoadRealeases()
        {
            if (IsBusy)
                return;
           
            try
            {
                IsBusy = true;
                var releases = await client.GetReleases(Artist);

                foreach(var release in releases )
                {
                    Releases.Add(release);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Unable to get Releases: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                isRefreshing = false; 
            }
        }
    }
}
