using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.WindowsAPICodePack.Shell;

namespace Player
{
    public class PlayerInstance
    {
        private int _volume;

        public bool Locked { get; set; }

        public bool Playing { get; set; }

        public string[] SupportedExtentions => new string[] { ".mp3", ".wav" };

        public Song PlayingSong { get; set; }

        public List<Song> Songs { get; } = new List<Song>();

        public int Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (value < 0) _volume = 0;
                else if (value > 100) _volume = 100;
                else _volume = value;
            }
        }        

        public void VolumeUp()
        {
            //Volume++;
            Volume = Volume + 1;
        }

        public void VolumeDown()
        {
            //Volume--;
            Volume = Volume - 1;
        }

        public void VolumeChange(int step)
        {
            //Volume--;
            Volume += step;
        }

        public void Load(string source)
        {
            var dirInfo = new DirectoryInfo(source);
            var fileInfo = new FileInfo(source);

            if (fileInfo.Exists)
            {
                LoadFiles(new FileInfo[] { fileInfo });
            }
            else if (dirInfo.Exists)
            {
                var files = dirInfo.GetFiles();
                LoadFiles(files);
            }
        }

        private void LoadFiles(FileInfo[] files)
        {
            foreach (var file in files)
            {
                if (SupportedExtentions.Length == 0 || SupportedExtentions.Contains(file.Extension))
                {
                    var fileMetadata = ShellFile.FromFilePath(file.FullName);

                    var song = new Song()
                    {
                        Path = file.FullName,

                        Title =
                            fileMetadata.Properties.System.Title?.Value
                            ?? fileMetadata.Name,

                        Duration = (int)
                            (fileMetadata.Properties.System.Media.Duration?.Value ?? 0) / 10_000_000,

                        Album = new Album()
                        {
                            Title = fileMetadata.Properties.System.Music.AlbumTitle?.Value,
                            Year = (int)(fileMetadata.Properties.System.Media.Year?.Value ?? 0),
                        },

                        Artist = new Artist()
                        {
                            Name = fileMetadata.Properties.System.Music.Artist?.Value?.FirstOrDefault()
                        }
                    };

                    Songs.Add(song);
                }
            }
        }        

        public void Filter(Genres genre)
        {
            var filteredSongs = new List<Song>();

            foreach (var song in this.Songs)
            {
                if ((song.Genre & genre) == genre)
                {
                    filteredSongs.Add(song);
                }
            }

            this.Songs.Clear();
            this.Songs.AddRange(filteredSongs);
        }

        public bool Play(bool loop = false)
        {
            PlayingSong = PlayingSong ?? Songs[0];

            if (!Locked)
            {
                Playing = true;
            }

            if (Playing)
            {
                int cycles = loop ? 5 : 1;
                for (int i = 0; i < cycles; i++)
                {
                    foreach (var song in Songs)
                    {
                        PlayingSong = song;

                        Console.Clear();

                        ListSongs();
                        Console.WriteLine(PlayingSong.Title + ": " + PlayingSong.Lyrics);

                        System.Threading.Thread.Sleep(2000);
                    }
                }
            }

            return Playing;
        }

        public bool Stop()
        {
            if (Locked == false)
            {
                Playing = false;
            }

            return Playing;
        }

        public bool Lock()
        {
            return Locked = true;
        }

        public bool Unlock()
        {
            return Locked = false;
        }

        public void Shuffle()
        {
            List<Song> suffledSongs = new List<Song>();
            int step = 3;
            for (int i = 0; i < step; i++)
            {
                int index = i;

                while(index < Songs.Count)
                {
                    suffledSongs.Add(Songs[index]);
                    index += step;
                }
            }

            Songs.Clear();
            Songs.AddRange(suffledSongs);
        }

        public void SortByTitle()
        {
            List<string> names = new List<string>();
            List<Song> sorted = new List<Song>();

            foreach (var song in Songs)
            {
                names.Add(song.Title);
            }

            names.Sort();

            foreach (var name in names)
            {
                foreach (var song in Songs)
                {
                    if (song.Title == name)
                    {
                        sorted.Add(song);
                        continue;
                    }
                }
            }

            Songs.Clear();
            Songs.AddRange(sorted);
        }

        private void ListSongs()
        {
            foreach (var song in Songs)
            {
                var data = GetSongData(song);
                var songInfo = $"{data.title} ({data.author}) - {data.duration.min}:{data.duration.sec}";
                if (data.isPlayingNow)
                {
                    songInfo = $"***{songInfo}***";
                }

                if (data.like.HasValue)
                {
                    if (data.like.Value)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(songInfo);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(songInfo);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine(songInfo);
                }
            }
        }

        private (string title, (int min, int sec) duration, bool isPlayingNow, bool? like, string author) GetSongData(Song song)
        {
            var title = song.Title;
            var isPlayingNow = song == PlayingSong;
            var min = song.Duration / 60;
            var sec = song.Duration % 60;
            var author = song.Artist?.Name;

            return (title, (min, sec), isPlayingNow, song.Like, author);
        }
    }
}
