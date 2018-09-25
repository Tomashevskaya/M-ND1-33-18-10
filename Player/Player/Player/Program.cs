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
            var song = new Song()
            {
                Title = "Superstar",
                Duration = 300,                
                Lyrics = @"Для тебя не осталось слов и мыслей хороших,
                нет
                А я но..а я но..а я ночь превращаю в рассвет,
                но снова одна
                Я запуталась в глянце.Мы почти иностранцы в нём
                Ты хотел уходить и смотреть,
                как я буду потом
                Бежать за тобой босиком"
            };

            var artist = new Artist() { Name = "Loboda", Songs = new[] { song }, Albums = new Album[1]  };
            var album = new Album() { Artist = artist, Title = "Superstar", Songs = new[] { song } };

            artist.Albums[0] = album;
            song.Artist = artist;
            song.Album = album;

            var player = new PlayerInstance();

            player.Add(song);

            Song currentPlayingSong = null;
            Console.WriteLine(player.Play(out currentPlayingSong));

            Console.ReadLine();
 
        }
    }
}
