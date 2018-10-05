using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new AudioPlayer();

            Console.WriteLine(player.Volume);

            //player.Volume = 300;

            player.VolumeUp();
            player.VolumeUp();
            player.VolumeUp();

            player.VolumeChange(int.Parse(Console.ReadLine()));

            Console.WriteLine(player.Volume);

            //Console.WriteLine(player.Volume);

            Console.ReadLine();
        }
    }
}
