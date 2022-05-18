using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MusicBrainzMauiApp.Model;
using MusicBrainzMauiApp.View;
using MusicBrainzMauiApp.Services;

namespace MusicBrainzMauiApp.ViewModel;


public partial class ArtistsViewModel : BaseViewModel
{
    public ObservableCollection<Artist> Artists { get; set; } = new();
    MusicBrainzClientService client;

    SearchQuery searchQuery;
    private static int limit = 5;

    [ObservableProperty]
    private string searchName;

    private string lastSearchName;

    [ObservableProperty]
    bool isRefreshing;

    public ArtistsViewModel(MusicBrainzClientService client)
    {
        this.client = client;
        searchQuery = new SearchQuery();
    }

    [ICommand] // DON'T FORGET THE GOD DAMED 'I'
    Task Back() => Shell.Current.GoToAsync("..");

    [ICommand]
    private async Task ArtistSearch(string searchBarText)
    {
        if (IsBusy || (lastSearchName is not null && searchBarText == lastSearchName))
            return;

        try
        {
            IsBusy = true;
            searchQuery.Name = searchBarText;
            lastSearchName = searchBarText;

            Debug.WriteLine($"Search term is: {searchQuery.Name}");

            var artists = await client.GetArtists(searchQuery.Name, limit);

            foreach (var artist in artists)
            {
                Artists.Add(artist);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Artists: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [ICommand]
    private async Task NavToArtistCommandPage(Artist artist)
    {
        Debug.WriteLine("It fucking worked: ", artist.Name);

        //await Shell.Current.GoToAsync(nameof(Artist), true, new Dictionary<string, Object>
        //{
        //    {"Artist", artist }
        //});
    }
}
