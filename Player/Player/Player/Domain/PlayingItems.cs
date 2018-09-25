using System.Collections.Generic;

namespace Player.Domain
{
    public abstract class PlayingItems
    {
        public abstract string Caption { get; protected set; }

        public abstract List<Song> Songs { get; protected set; }

        public abstract int Duration { get; protected set; }
    }
}
