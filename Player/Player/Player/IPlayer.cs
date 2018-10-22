using System.Collections.Generic;
using System.Threading.Tasks;
using Player.Domain;

namespace Player
{
    public interface IPlayer<TPlayItem, TPlayItemContent> where TPlayItem : IPlayItem<TPlayItemContent>
    {
        bool Locked { get; set; }
        bool Playing { get; set; }
        TPlayItem PlayingItem { get; set; }
        List<TPlayItem> Items { get; set; }

        void Add(params TPlayItem[] items);
         
        bool Lock();
        Task<bool> Play(bool loop = false);
        void Shuffle();
        void SortByTitle();
        bool Stop(out TPlayItem playingItem);
        bool Unlock();
    }
}