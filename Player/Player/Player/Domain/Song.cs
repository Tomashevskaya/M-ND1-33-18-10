namespace Player.Domain
{
    public class Song
    {
        public string Title { get; set; }

        public string Lyrics { get; set; }

        public int Duration { get; set; }

        public bool? Like { get; set; }

        public Artist Artist { get; set; }

        public Album Album { get; set; }

        public Genre Genre { get; set; }

        public void LikeSong()
        {
            this.Like = true;
        }

        public void DislikeSong()
        {
            this.Like = false;
        }

        public void Deconstruct(out string title, out string lyrics, out int duration, out bool? like)
        {
            title = Title;
            lyrics = Lyrics;
            duration = Duration;
            like = Like;
        }
    }
}
