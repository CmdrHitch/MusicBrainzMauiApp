using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        public ObservableCollection<string> Titles { get; set; } = new();
        
        private MusicBrainzClientService client;
        private SearchQuery searchQuery;

        //private static int limit = 5;
        public ArtistViewModel(MusicBrainzClientService client)
        {
            this.client = client;
            searchQuery = new SearchQuery();
        }

        [ICommand]
        Task Back() => Shell.Current.GoToAsync("..");

        [ICommand]
        private async Task NavToRealease(string title)
        {
            await Task.Run(() => Debug.WriteLine("Tapped Title", title));
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
                List<string> tmpTitles = new();
                var releases = await client.GetReleases(Artist);

                foreach (var release in releases)
                {
                    Releases.Add(release);
                    tmpTitles.Add(release.Title);
                }

                tmpTitles.Sort(); 

                foreach(var title in tmpTitles.Distinct())
                {
                    Titles.Add(title);
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
