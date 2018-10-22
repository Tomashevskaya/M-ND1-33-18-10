using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player.Domain;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            var artist = new Artist() { Name = "Loboda", Albums = new Album[1] };
            var album = new Album() { Artist = artist, Title = "Superstar" };

            //var directory = @"d:\Music\WAV\";
            var directory = @"d:\Music\WAV\short";
            var songs = CreateSongs(directory, artist, album);

            songs[0].LikeSong();
            songs[3].LikeSong();
            songs[2].DislikeSong();


            artist.Albums[0] = album;
            artist.Songs = new List<Song> { songs[0], songs[2], songs[4] };
            album.Songs = new List<Song> { songs[1], songs[3], songs[4] };

            var player = new Player();
            var skin = new Skin();
            player.Add(songs.ToArray());

            var visualizer = new Visualizer(player, skin);
            player.Play(false);
            //Console.WriteLine("-- Playing Songs --");

            //Console.WriteLine("-- Suffle Songs --");
            //player.Shuffle();
            //player.Play();
            //Console.WriteLine("-- Sort Songs --");
            //player.SortByTitle();
            //player.Play();
            /*
            Console.WriteLine("-- Playing Album --");
            player.Add(album);
            Console.WriteLine(player.Play(out currentPlayingSong));

            Console.WriteLine("-- Playing Artist --");
            player.Add(artist);
            Console.WriteLine(player.Play(out currentPlayingSong));*/

            Console.ReadLine();
 
        }


        private static List<Song> CreateSongs(string directory, Artist artist, Album album)
        {
            var result = new List<Song>();

            var songsPathes = Directory.GetFiles(directory);

            foreach (var songPath in songsPathes)
            {
                var songFile = new FileInfo(songPath);
                result.Add(new Song(songFile)
                {
                    Duration = 30,
                    Lyrics = @"1. Для тебя не осталось слов и мыслей хороших...",
                    Album = album,
                    Artist = artist,
                    Genre = Genre.Blues
                });          

            };

            return result;
        }
    }
}
