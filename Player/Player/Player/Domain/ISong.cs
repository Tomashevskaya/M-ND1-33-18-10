namespace Player.Domain
{
    public interface IPlayItem<T>
    {
        int Duration { get; set; }
        Genre Genre { get; set; }
        string Title { get; set; }
        T Content { get; set; }
    }
}