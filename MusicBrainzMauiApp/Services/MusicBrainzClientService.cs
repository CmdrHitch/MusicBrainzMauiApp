using Hqub.MusicBrainz.API;
using MusicBrainzMauiApp.Model;

namespace MusicBrainzMauiApp.Services
{
    public class MusicBrainzClientService
    {
        private static bool testmode = true;

        private MusicBrainzClient musicBrainzClient;

        public MusicBrainzClientService MusicBrainzClient
        {
            get;
        }

        public MusicBrainzClientService()
        {
            musicBrainzClient = new MusicBrainzClient();
        }

        List<Artist> artistList;
        public async Task<List<Artist>> GetArtists(string searchExpr, int limit)
        {
            //Note Checking Null 
            if (artistList?.Count > 0)
                return artistList;

            if (testmode)
            {
                var testData = await TestClientService.GetAritistsAsync();
                return (List<Artist>) testData;
            }

            var response = await musicBrainzClient.Artists.SearchAsync(searchExpr,limit);
            artistList = new List<Artist>();

            foreach(var item in response)
            {
                Artist artist = new Artist();
                artist.Name = item.Name;
                artist.MBID = item.Id;

                artistList.Add(artist);
            }

            return artistList;
        }
    }
}
