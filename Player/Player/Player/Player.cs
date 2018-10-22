using System;
using System.Collections.Generic;
using System.Linq;
using Player.Helpers;
using Player.Domain;
using Player.Exceptions;
using System.Threading.Tasks;

namespace Player
{
    public class Player : IPlayer<Song, String>
    {
        public event Action PlayerStarted;
        public event Action PlayerStopped;
        public event Action<Song> SongStarted;

        public bool Locked { get; set; }

        public bool Playing { get; set; }

        public Song PlayingItem { get; set; }

        public List<Song> Items { get; set; }   
        
        public void Add(params Song[] items)
        {
            Items = items.ToList();
        }

        public void Add(Playlist playlist)
        {
            Items = playlist.Songs;
        }

        public void Add(Album album)
        {
            Items = album.Songs;
        }

        public void Add(Artist artist)
        {
            Items = artist.Songs;
        }

        public async Task<bool> Play(bool loop = false)
        {
            if (PlayingItem == null)
            {
                PlayingItem = Items[0];
            }            

            if (Locked == false)
            {
                Playing = true;
            }

            if (Playing)
            {
                PlayerStarted?.Invoke();

                int cycles = loop ? 5 : 1;

                using (System.Media.SoundPlayer player = new System.Media.SoundPlayer())
                {
                    for (int i = 0; i < cycles; i++)
                    {
                        foreach (var song in Items)
                        {
                            try
                            {
                                PlayingItem = song;
                                SongStarted?.Invoke(PlayingItem);
                                await PlaySong(player, song);      
                            }
                            catch (PlayerException ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                throw;
                            }
                        }
                    }

                    PlayerStopped?.Invoke();
                }
            }

            return Playing;
        }

        private async Task PlaySong(System.Media.SoundPlayer player, Song song)
        {
            if (!song.Path.EndsWith(".wav"))
            {
                throw new Exceptions.FileNotPlayableException($"Failed to play file '{song.Title}'") { Path = song.Path };
            }


            var (title, lyrics, path, duration, _) = song;

            try
            {
                await Task.Run(() =>
                {
                    player.SoundLocation = path;
                    player.PlaySync();
                });
            }
            catch (Exception ex)
            {
                throw new Exceptions.FailedToPlayException($"Failed to play song '{song.Title}'", ex) { Song = song };
            }
        }

        public bool Stop(out Song playingSong)
        {
            playingSong = PlayingItem;

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
            Items = Items.Shuffle();
        }

        public void SortByTitle()
        {
            Items = Items.SortByTitle();
        }

    }
}
