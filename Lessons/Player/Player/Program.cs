using System;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new PlayerInstance();

            player.Load(@"d:\Dropbox\HrueSpace\IT Academy\C#\Resources\mp3\");
            player.Play();

            Console.ReadLine();
        }
    }
}
