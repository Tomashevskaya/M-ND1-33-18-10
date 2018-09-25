using System;

namespace Player.Domain
{
    [Flags]
    public enum Genre
    {
        None = 0,
        Blues = 1,
        Comedy = 2,
        Country = 4,
        Electronic = 8,
        Folk = 16,
        Jazz = 32,
        Latin = 64,
        Pop = 128,
        Rock = 256
    }
}
