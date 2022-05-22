using Hqub.MusicBrainz.API;
using MusicBrainzMauiApp.Model;

namespace MusicBrainzMauiApp.Services
{
    public class MusicBrainzClientService // Make Static ?
    {
        private static bool testmode = false;

        private MusicBrainzClient musicBrainzClient;

        public MusicBrainzClientService MusicBrainzClient
        {
            get;
        }

        public MusicBrainzClientService()
        {
            musicBrainzClient = new MusicBrainzClient();
        }

        
        public async Task<List<Artist>> GetArtists(string searchExpr, int limit)
        {
            List<Artist> artistList = new();

            if (testmode)
            {
                var testData = await TestClientService.GetAritistsAsync();
                return testData;
            }

            var response = await musicBrainzClient.Artists.SearchAsync(searchExpr,limit);

            foreach(var item in response)
            {
                Artist artist = new Artist();
                artist.Name = item.Name;
                artist.MBID = item.Id;

                artistList.Add(artist);
            }

            return artistList;
        }
        
        
        public async Task<List<Release>> GetReleases(Artist artist)
        {
            List<Release> releaseList = new();

            var query = new QueryParameters<Hqub.MusicBrainz.API.Entities.Release>()
            {
                { "arid", artist.MBID },
                //{   "release" album},
                { "type", "album" },
                { "status", "official" }
            };


            if (releaseList?.Count > 0)
                return releaseList;

            if (testmode)
            {
                var testData = await TestClientService.GetReleasesAsync(artist);
                return testData;
            }

            var response = await musicBrainzClient.Releases.SearchAsync(query);

            foreach(var item in response)
            {
                Release release = new();
                release.Title = item.Title;
                release.MBID = item.Id;

                releaseList.Add(release);
            }

            return releaseList;
        }
    }
}
