using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class AudioPlayer
    {
        private int _volume;
        public int Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (value < 0) _volume = 0;
                else if (value > 100) _volume = 100;
                else _volume = value;
            }
        }

        public Song[] songs;

        public void VolumeUp()
        {
            //Volume++;
            Volume = Volume + 1;
        }

        public void VolumeDown()
        {
            //Volume--;
            Volume = Volume--;
        }

        public void VolumeChange(int step)
        {
            //Volume--;
            Volume += step;
        }

    }
}
