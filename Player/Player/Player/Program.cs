using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            Song currentPlayingSong = null;
            Song[] songs = null;
            Album album = null;
            Artist artist = null;

            CreatePlayerItems(out songs, out artist, out album);

            songs[0].Like = true;
            songs[3].Like = false;
            songs[4].Like = true;           

            var player = new PlayerInstance();            

            Console.WriteLine("-- Playing Songs --");
            System.Threading.Thread.Sleep(3000);
            player.Add(songs);
            player.Play(out currentPlayingSong);

            Console.WriteLine("-- Suffle Songs --");
            System.Threading.Thread.Sleep(3000);
            player.Shuffle();
            player.Play(out currentPlayingSong);

            Console.WriteLine("-- Sort Songs --");
            System.Threading.Thread.Sleep(3000);
            player.SortByTitle();
            player.Play(out currentPlayingSong);

            /*
            Console.WriteLine("-- Playing Album --");
            player.Add(album);
            Console.WriteLine(player.Play(out currentPlayingSong));

            Console.WriteLine("-- Playing Artist --");
            player.Add(artist);
            Console.WriteLine(player.Play(out currentPlayingSong));*/

            Console.ReadLine();
 
        }

        private static void CreatePlayerItems(out Song[] songs, out Artist artist, out Album album)
        {
            artist = new Artist() { Name = "Loboda", Songs = new List<Song>(), Albums = new Album[1] };
            album = new Album() { Artist = artist, Title = "Superstar", Songs = new List<Song>() };
            songs = CreateSongs(artist, album);

            artist.Albums[0] = album;

            artist.Songs = new List<Song>() { songs[0], songs[2], songs[4] };
            album.Songs = new List<Song>() { songs[1], songs[3], songs[4] };
        }

        private static Song[] CreateSongs(Artist artist, Album album)
        {
            return new Song[] {
                new Song()
                {
                    Title = "Superstar(1)",
                    Duration = 300,
                    Lyrics = @"Для тебя не осталось слов и мыслей хороших...",
                    Album = album,
                    Artist = artist
                },
                new Song()
                {
                    Title = "Твои глаза(5)",
                    Duration = 300,
                    Lyrics = @"Твои глаза... останови планету...",
                     Album = album,
                    Artist = artist
                },
                new Song()
                {
                    Title = "К черту любовь(2)",
                    Duration = 300,
                    Lyrics = @"А может к черту любовь... все понимаю но я опять влюбляюсь в тебя",
 Album = album,
                    Artist = artist
                },
                new Song()
                {
                    Title = "Парень(3)",
                    Duration = 300,
                    Lyrics = @"Парень, ты меня так сильно ранил...",
 Album = album,
                    Artist = artist
                },
                new Song()    {
                    Title = "Случайная(4)",
                    Duration = 300,
                    Lyrics = @"Ты пишешь мне письма такие печальные...",
 Album = album,
                    Artist = artist
                }
            };
        }
    }
}
