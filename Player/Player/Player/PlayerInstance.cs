using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class PlayerInstance
    {

        public bool Locked { get; set; }

        public bool Playing { get; set; }

        public Song PlayingSong { get; set; }

        public List<Song> Songs { get; set; }   
        
        public void Add(params Song[] songs)
        {
            Songs = songs.ToList();
        }

        public void Add(Playlist playlist)
        {
            Songs = playlist.Songs;
        }

        public void Add(Album album)
        {
            Songs = album.Songs;
        }

        public void Add(Artist artist)
        {
            Songs = artist.Songs;
        }

        public bool Play(out Song playingSong, bool loop = false)
        {
            if (PlayingSong == null)
            {
                PlayingSong = Songs[0];
            }

            playingSong = PlayingSong;

            if (Locked == false)
            {
                Playing = true;
            }

            if (Playing)
            {
                int cycles = loop ? 5 : 1;
                for (int i = 0; i < cycles; i++)
                {
                    foreach (var song in Songs)
                    {                        
                        PlayingSong = song;
                        ListSongs();
                        Console.WriteLine(PlayingSong.Title + ": " + PlayingSong.Lyrics);
                        Console.WriteLine();
                    }
                }
            }

            return Playing;
        }

        public bool Stop(out Song playingSong)
        {
            playingSong = PlayingSong;

            if (Locked == false)
            {
                Playing = false;
            }

            return Playing;
        }

        public bool Lock()
        {
            return Locked = true;
        }

        public bool Unlock()
        {
            return Locked = false;
        }

        public void Shuffle()
        {
            Songs = Songs.Shuffle();
        }

        public void SortByTitle()
        {
            Songs = Songs.SortByTitle();
        }

        public void ListSongs()
        {
            foreach (var song in Songs)
            {
                //

                /*var songData = new
                {
                    Title = song.Title,
                    Playing = song == PlayingSong,
                    Hours = (int)(song.Duration / (60 * 60)),
                    Minutes = (song.Duration % (60 * 60)) / 60,
                    Seconds = (song.Duration % (60)) / 60,
                };


                Console.WriteLine($"{songData.Title} {songData.Hours}:{songData.Minutes}:{songData.Seconds}");*/

                var (title, duration, playing, like) = GetSongData(song);
                var color = like.HasValue ? 
                    (like.Value ? ConsoleColor.Green : ConsoleColor.Red) 
                    : (ConsoleColor?)null;
                WriteLine($"{title.Cut()} {duration.hours}:{duration.minutes}:{duration.seconds}", color);
            }
        }

        public (string title, (int hours, int minutes, int seconds) duration, bool playing, bool? like) GetSongData(Song song)
        {
            var hours = (int)(song.Duration / (60 * 60));
            var minutes = (song.Duration / 60) - hours * 60;
            var second = song.Duration - hours * 60 * 60 - minutes * 60;

            return (song.Title, (hours, minutes, second), song == PlayingSong, song.Like);
        }

        private void WriteLine(string text, ConsoleColor? color = null)
        { 
            if (color.HasValue)
            {
                Console.ForegroundColor = color.Value;
                Console.WriteLine(text);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(text);
            }
            
        }
    }
}
