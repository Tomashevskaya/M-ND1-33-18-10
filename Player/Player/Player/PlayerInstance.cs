using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class PlayerInstance
    {
        public static Song[] Songs { get; set; }   
        
        public void Add(Song song)
        {

        }

        public void Add(Playlist playlist)
        {

        }

        public void Add(Album album)
        {

        }

        public void Add(Artist artist)
        {

        }

        public bool Play(out Song playingSong)
        {
            playingSong = null;
            return false;
        }

        public bool Stop(out Song playingSong)
        {
            playingSong = null;
            return false;
        }
    }
}
