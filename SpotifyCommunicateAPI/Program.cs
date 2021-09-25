using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace SpotifyCommunicateAPI
{
    class Program
    {
        public static async Task Main()
        {
            var config = SpotifyClientConfig
              .CreateDefault()
              .WithAuthenticator(new ClientCredentialsAuthenticator("7b26a90c1afd40888df7b75ab49e9bec", "e542781aa60e454a806ba7db9782df81"));
            //                                                       Client_ID ,                          Client_Secret
            var spotify = new SpotifyClient(config);

            var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");

            Console.WriteLine(track.Name);
            Console.ReadKey();

            var album = await spotify.Albums.Get("3stAuEL0tvebSy4njtAL7X");
            Console.WriteLine(album.Name);
            Console.ReadKey();

            var playlist = await spotify.Playlists.Get("64HbtsiOXQnOfJHM8Ce0nC");
            Console.WriteLine(playlist.Name);
            Console.ReadKey();

            var artist = await spotify.Artists.Get("75U40yZLLPglFgXbDVnmVs");
            Console.WriteLine(artist.Name);
            Console.ReadKey();
        }
    }
}

