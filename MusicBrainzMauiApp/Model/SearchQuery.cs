namespace MusicBrainzMauiApp.Model
{
    public class SearchQuery
    {
        public string Name { get; set; }
        public string SearchTermExpr { get; set; }
        public int limit { get; set; }
        public int Offset { get; set; }
    }

    /*
     * 
     *       [ObservableProperty]
        private SearchQuery searchQuery;

    [QueryProperty(nameof(SearchTerm), nameof(SearchTerm))] //The SearchTerm binds to backing field searchTerm and provided getters and setters
    [QueryProperty(nameof(SearchQuery),nameof(SearchQuery))]

    [ICommand]
    Task NavArtistsView() =>
    Shell.Current.GoToAsync($"{nameof(ArtistsPageView)}?",
        new Dictionary<string, object>
        {
            ["SearchQuery"] = searchQuery
        });
    */
}
