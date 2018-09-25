namespace Player
{
    public class Song
    {
        public string Title { get; set; }

        public string Lyrics { get; set; }

        public int Duration { get; set; }

        public bool? Like { get; set; }

        public Artist Artist { get; set; }

        public Album Album { get; set; }

        public void LikeSong()
        {
            this.Like = true;
        }

        public void DislikeSong()
        {
            this.Like = false;
        }
    }
}
