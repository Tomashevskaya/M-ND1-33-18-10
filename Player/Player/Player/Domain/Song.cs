using System.IO;

namespace Player.Domain
{
    public class Song : IPlayItem<string>
    {
        public Song(FileInfo file)
        {
            this.Title = file.Name;
            this.Path = file.FullName;
        }

        public string Title { get; set; }

        public string Path { get; set; }

        public string Lyrics { get; set; }

        public int Duration { get; set; }

        public bool? Like { get; set; }

        public Artist Artist { get; set; }

        public Album Album { get; set; }

        public Genre Genre { get; set; }

        public string Content { get { return Lyrics; } set { Lyrics = value;  } }

        public void LikeSong()
        {
            this.Like = true;
        }

        public void DislikeSong()
        {
            this.Like = false;
        }

        public void Deconstruct(out string title, out string lyrics, out string path, out int duration, out bool? like)
        {
            title = Title;
            lyrics = Lyrics;
            duration = Duration;
            like = Like;
            path = Path;
        }
    }
}
