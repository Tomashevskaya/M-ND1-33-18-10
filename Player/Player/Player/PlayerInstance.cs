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

        public Song[] Songs { get; set; }   
        
        public void Add(params Song[] songs)
        {
            Songs = songs;
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

        public bool Play(out Song playingSong)
        {                     
            playingSong = PlayingSong = PlayingSong ?? Songs[0];

            if (!Locked)
            {
                Playing = true;
            }

            if (Playing)
            {
                for (int i = 0; i < 5; i++)
                {
                    foreach (var song in Songs)
                    {
                        PlayingSong = song;

                        Console.Clear();
                        Console.WriteLine(PlayingSong.Lyrics);

                        System.Threading.Thread.Sleep(2000);
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
    }
}
