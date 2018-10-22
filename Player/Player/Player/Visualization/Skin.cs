using Player.Domain;
using Player.Helpers;
using System;

namespace Player
{
    public class Skin : ISkin
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Render(string text = null)
        {
            Console.WriteLine(text);
        }
    }
}
