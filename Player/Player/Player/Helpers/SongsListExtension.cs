using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Player.Domain;

namespace Player.Helpers
{
    public static class SongsListExtension
    {
        public static List<Song> Shuffle(this List<Song> songs)
        {
            List<Song> suffledSongs = new List<Song>();
            int step = 3;
            for (int i = 0; i < step; i++)
            {
                int index = i;

                while (index < songs.Count)
                {
                    suffledSongs.Add(songs[index]);
                    index += step;
                }
            }

            return suffledSongs;
        }

        public static List<Song> SortByTitle(this List<Song> songs)
        {
            List<string> names = new List<string>();
            List<Song> sorted = new List<Song>();

            foreach (var song in songs)
            {
                names.Add(song.Title);
            }

            names.Sort();

            foreach (var name in names)
            {
                foreach (var song in songs)
                {
                    if (song.Title == name)
                    {
                        sorted.Add(song);
                        continue;
                    }
                }
            }

            return sorted;
        }
    }
}
