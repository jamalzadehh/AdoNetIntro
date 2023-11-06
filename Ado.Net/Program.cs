using Ado.Net.Models;
using Ado.Net.Services;
using System.Data.SqlClient;

namespace Ado.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArtistService artistService = new ArtistService();
            MusicService musicService = new MusicService();

            Artist artist = new Artist
            {
                Name = "Nicat",
                Surname="Xelilli",
                Birthday=DateTime.Now,
                Gender="Male"
            };                        
            artistService.CreateArtist(artist);

            Music music = new Music
            {
                Name = "Lacin",
                Duration = 180,
                CategoryId = 1,
                ArtistId = 1
            };
            musicService.CreateMusic(music);
            artistService.DeleteArtist(1);
            musicService.DeleteMusic(1);

            List<Artist> artists = artistService.GetAllArtists();
            Console.WriteLine("Artist:");
            foreach (Artist item in artists)
            {
                Console.WriteLine($"{item.Name} {item.Surname}");
            }

            List<Music> musics = musicService.GetAllMusics();
            Console.WriteLine("Musics");
            foreach (Music item in musics)
            {
                Console.WriteLine($"{item.Name}");
            }

            Music idmusic = musicService.GetMusicById(1);
            Console.WriteLine(idmusic.Name);

            Artist idartist = artistService.GetArtistById(1);
            Console.WriteLine($"{idartist.Name} {idartist.Surname}");
        }
    }
}