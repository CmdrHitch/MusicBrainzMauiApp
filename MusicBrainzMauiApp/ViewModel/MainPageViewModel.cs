using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using MusicBrainzMauiApp.Model;

namespace MusicBrainzMauiApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private SearchQuery searchQuery;
        public string SearchTerm;
        public MainPageViewModel()
        {
            var searchQuery = new SearchQuery();
        }

        [ICommand]
        public async Task GoToArtistsView()
        {
            searchQuery.SearchTermExpr = SearchTerm;
            searchQuery.limit = 20; // To/Do
            
            await Shell.Current.GoToAsync("ArtistsPageView",);
            Debug.WriteLine("ArtistsPageView Returned");
        }
    }
}