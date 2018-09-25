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
            var artist = new Artist() { Name = "Loboda", Songs = new Song[3], Albums = new Album[1] };
            var album = new Album() { Artist = artist, Title = "Superstar", Songs = new Song[3] };

            var songs = CreateSongs(artist, album);

            
            artist.Albums[0] = album;
            artist.Songs = new Song[3] { songs[0], songs[2], songs[4] };
            album.Songs = new Song[3] { songs[1], songs[3], songs[4] };

            var player = new PlayerInstance();
            Song currentPlayingSong = null;

            Console.WriteLine("-- Playing Songs --");
            player.Add(songs);            
            Console.WriteLine(player.Play(out currentPlayingSong));

            Console.WriteLine("-- Playing Album --");
            player.Add(album);
            Console.WriteLine(player.Play(out currentPlayingSong));

            Console.WriteLine("-- Playing Artist --");
            player.Add(artist);
            Console.WriteLine(player.Play(out currentPlayingSong));

            Console.ReadLine();
 
        }


        private static Song[] CreateSongs(Artist artist, Album album)
        {
            return new Song[] {
                new Song()
                {
                    Title = "Superstar",
                    Duration = 300,
                    Lyrics = @"Для тебя не осталось слов и мыслей хороших...",
                    Album = album,
                    Artist = artist
                },
                new Song()
                {
                    Title = "Твои глаза",
                    Duration = 300,
                    Lyrics = @"Твои глаза... останови планету...",
                     Album = album,
                    Artist = artist
                },
                new Song()
                {
                    Title = "К черту любовь",
                    Duration = 300,
                    Lyrics = @"А может к черту любовь... все понимаю но я опять влюбляюсь в тебя",
 Album = album,
                    Artist = artist
                },
                new Song()
                {
                    Title = "Парень",
                    Duration = 300,
                    Lyrics = @"Парень, ты меня так сильно ранил...",
 Album = album,
                    Artist = artist
                },
                new Song()    {
                    Title = "Случайная",
                    Duration = 300,
                    Lyrics = @"Ты пишешь мне письма такие печальные...",
 Album = album,
                    Artist = artist
                }
            };
        }
    }
}
