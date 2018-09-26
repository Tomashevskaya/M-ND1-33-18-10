using System.Collections.Generic;
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
        (string title, (int hours, int minutes, int seconds) duration, bool playing, bool? like) GetItemData(TPlayItem item);
        void ListItems();
        bool Lock();
        bool Play(out TPlayItem playingItem, bool loop = false);
        void Shuffle();
        void SortByTitle();
        bool Stop(out TPlayItem playingItem);
        bool Unlock();
    }
}