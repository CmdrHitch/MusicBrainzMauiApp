//using Microsoft.Toolkit.Mvvm.ComponentModel;
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

        [ObservableProperty]
        string test = "I am Test!";

        public ObservableCollection<Recording> Recordings { get; set; } = new();
        
        private MusicBrainzClientService client;
        private SearchQuery searchQuery;

        private static int limit = 5;
        public ArtistViewModel(MusicBrainzClientService client)
        {
            this.client = client;
            searchQuery = new SearchQuery();
            Task.Run(() => LoadRecordings()); // Would do on page on load. But property_change event is processed by page.
        }

        [ObservableProperty]
        bool isRefreshing;
        public async Task LoadRecordings()
        {
            if (IsBusy)
                return;
           
            try
            {
                IsBusy = true;
                var recordings = await client.GetRecordings(artist);

                foreach(var recording in recordings)
                {
                    Recordings.Add(recording);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Unable to get Recordings: {ex.Message}");
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
