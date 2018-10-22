using Player.Domain;
using Player.Helpers;
using System;
using System.Collections.Generic;

namespace Player
{
    public class Visualizer 
    {
        public Player Player { get; }
        public ISkin Skin { get; }

        public Visualizer(Player player, ISkin skin)
        {
            Player = player;
            Skin = skin;

            player.SongStarted += ((Song song) =>
             {
                 skin.Clear();
                 RenderSongs();
             });
            
        }    
        
        
        public void RenderSongs()
        {
            foreach (var song in Player.Items)
            {
                var (title, duration, playing, like) = GetItemData(song);
                var color = like.HasValue ?
                    (like.Value ? ConsoleColor.Green : ConsoleColor.Red)
                    : (ConsoleColor?)null;
                var startingMark = playing ? ">>>" : "";
                var endingMark = playing ? "<<<" : "";
                title = playing ? $"{startingMark}{title}{endingMark}" : title;
                Skin.Render(title);
            }
        }

        public (string title, (int hours, int minutes, int seconds) duration, bool playing, bool? like) GetItemData(Song song)
        {
            var hours = (int)(song.Duration / (60 * 60));
            var minutes = (song.Duration / 60) - hours * 60;
            var second = song.Duration - hours * 60 * 60 - minutes * 60;

            return (song.Title, (hours, minutes, second), song == Player.PlayingItem, song.Like);
        }
    }
}
