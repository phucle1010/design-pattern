
using System;
using System.Collections.Generic;
using System.Text;
using MementoPattern;

namespace MementoPattern
{
    public class Song
    {
        string Name { get; set; }
        string Type { get; set; }
        string Artist { get; set; }
        DateTime PublishedDate { get; set; }
        public Song()
        {
            this.Name = "";
            this.Type = "";
            this.Artist = "";
            this.PublishedDate = new DateTime();
        }
        public void setState(string name, string type, string artist, DateTime publishedDate)
        {
            this.Name = name;
            this.Type = type;
            this.Artist = artist;
            this.PublishedDate = publishedDate;
        }
        public Song getState()
        {
            return this;
        }
        public string getName()
        {
            return this.Name;
        }
        public string getType()
        {
            return this.Type;
        }
        public string getArtist()
        {
            return this.Artist;
        }
        public DateTime getPublishedDate()
        {
            return this.PublishedDate;
        }
        public void play()
        {
            Console.WriteLine("Song Name: " + this.Name);
            Console.WriteLine("Song Type: " + this.Type);
            Console.WriteLine("Artist: " + this.Artist);
            Console.WriteLine("Published Date: " + this.PublishedDate);
        }
        public SongMemento save()
        {
            return new SongMemento(
                this,
                this.Name,
                this.Type,
                this.Artist,
                this.PublishedDate
            );
        }
    }

    public class SongMemento
    {
        Song _originalSong = new Song();
        Song _songState = new Song();
        public SongMemento(Song orginalSong, string name, string type, string artist, DateTime publishedDate)
        {
            this._originalSong = orginalSong;
            this._songState.setState(name, type, artist, publishedDate);
        }

        public void restore()
        {
            this._originalSong.setState(
                _songState.getName(),
                _songState.getType(),
                _songState.getArtist(),
                _songState.getPublishedDate()
            );
        }

        public Song getCurrentSongState()
        {
            return this._originalSong;
        }
    }

    public class SongCareTaker
    {
        public List<SongMemento> backups;

        public SongCareTaker()
        {
            this.backups = new List<SongMemento>();
        }

        public Song undo()
        {
            if (backups.Count == 0)
            {
                return new Song();
            }
            SongMemento snapshot = backups[backups.Count - 1];
            snapshot.restore();
            return snapshot.getCurrentSongState();
        }
    }
}

class Program
{
    const int NEXT_CHOICE = 1;
    const int PREV_CHOICE = 0;
    const int EXIT_ACCEPT = 2;

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        List<Song> songs = new List<Song>();

        Song song1 = new Song();
        song1.setState("Ánh nắng của anh", "Ballad", "Đức Phúc", new DateTime(2016, 12, 31));

        Song song2 = new Song();
        song2.setState("Happy Ending", "Ballad", "Erik", new DateTime(2017, 12, 05));

        Song song3 = new Song();
        song3.setState("Thuận theo ý trời", "Ballad", "Bùi Anh Tuấn", new DateTime(2016, 12, 10));

        Song song4 = new Song();
        song4.setState("Beautiful In White", "Ballad", "Weslife", new DateTime(2017, 10, 20));

        songs.Add(song1.getState());
        songs.Add(song2.getState());
        songs.Add(song3.getState());
        songs.Add(song4.getState());

        SongCareTaker playSongHistory = new SongCareTaker();

        int currentSongIndex = 0;

        Song currentSong = new Song();

        while (true)
        {
            SongMemento snapShot;
            if (playSongHistory.backups.Count > 0)
            {
                Console.Write("Which song do you want to play (next - 1 or previous - 0)?");
                int choice = Int32.Parse(Console.ReadLine());
                if (choice == NEXT_CHOICE)
                {
                    if (currentSongIndex < songs.Count - 1)
                    {
                        currentSongIndex++;
                        currentSong = songs[currentSongIndex];
                        snapShot = currentSong.save();
                        playSongHistory.backups.Add(snapShot);
                        currentSong.play();
                    }
                }
                else if (choice == PREV_CHOICE)
                {
                    if (playSongHistory.backups.Count == 1)
                    {
                        Console.WriteLine("You just play a song, so that there is no previous song!");
                    }
                    else
                    {
                        if (currentSongIndex > 0)
                        {
                            currentSongIndex--;
                            currentSong = playSongHistory.undo();
                            currentSong.play();
                            playSongHistory.backups.Remove(currentSong.save());
                        }
                    }
                }

                Console.Write("Do you want to stop playing (yes - 2)?");
                int exitChoice = Int32.Parse(Console.ReadLine());

                if (exitChoice == EXIT_ACCEPT)
                {
                    break;
                }
            }
            else
            {
                currentSong = songs[currentSongIndex];
                currentSong.play();
                snapShot = currentSong.save();
                playSongHistory.backups.Add(snapShot);
            }
        }
    }
}