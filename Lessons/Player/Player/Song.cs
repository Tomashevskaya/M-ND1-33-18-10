namespace Player
{
    public class Song
    {
        public string Title { get; set; }

        public string Path { get; set; }

        public string Lyrics { get; set; }

        public int Duration { get; set; }

        public Artist Artist { get; set; }

        public Album Album { get; set; }

        public bool? Like { get; set; }

        public Genres Genre { get; set; }

        public void LikeSong()
        {
            Like = true;
        }

        public void DislikeSong()
        {
            Like = false;
        }
    }
}
