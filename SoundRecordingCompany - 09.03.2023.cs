using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvukozapisnaKompaniq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RecordingCompany company = new RecordingCompany("TheCompany", "Sofia, j.k. Mladost", "Georgi Georgiev");

            Artist artist = new Artist("Pencho", "Penata");

            Album album = new Album("TheFirstAlbum", "Rock", 2012, 135);

            Song song1 = new Song("FirstSong", new Duration(0, 3, 20));

            Song song2 = new Song("SecondSong", 0, 2, 53);

            Song song3 = new Song("Thirdsong", 1, 20, 32);

            album.AddSong(song1);

            album.AddSong(song2);

            album.AddSong(song3);

            artist.AddAlbum(album);

            company.AddArtist(artist);
            company.AddArtist(artist);


            Console.WriteLine(company);



        }
    }
    
    class RecordingCompany
    {
        public RecordingCompany(string name, string address, string owner)
        {
            this.Name = name;
            this.Address = address;
            this.Owner = owner;
        }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Owner { get; private set; }
        public List<Artist> Artists { get; private set; } = new List<Artist>();
        public void AddArtist(Artist artist) => Artists.Add(artist);
        public void RemoveArtist(Artist artist) => Artists.Remove(artist);

        public override string ToString()
        {
            string str = $"--[{Name}]--\nOwner:{Owner}\nAddress:{Address}";
            foreach (var artist in Artists)
            {
                str+="\n\t"+artist;
                foreach (var album in artist.Albums)
                {
                    str+="\n\t\t"+album;
                    foreach (var song in album.Songs)
                    {
                        str+="\n\t\t\t"+ song;
                    }
                }
            }
            return str;
        }
    }

    class Artist
    {
        public Artist(string name, string nickname)
        {
            this.Name = name;
            this.Nickname = nickname;
        }

        public string Name { get; private set; }
        public string Nickname { get; private set; }
        public List<Album> Albums { get; private set; } = new List<Album>();
        public void AddAlbum(Album album) => Albums.Add(album);
        public void RemoveAlbum(Album album) => Albums.Remove(album);

        public override string ToString()
        {
            string r = $"{Nickname}({Name})";
            return r;
        }
    }
    class Album
    {
        public Album(string name, string genre, int releaseYear, int soldCopies)
        {
            this.Name = name;
            this.Genre = genre;
            this.ReleaseYear = releaseYear;
            this.SoldCopies = soldCopies;
        }
        public string Name { get; private set; }
        public string Genre { get; private set; }
        public int ReleaseYear { get; private set; }
        public int SoldCopies { get; private set; }
        public List<Song> Songs { get; private set; } = new List<Song>();
        public void AddSong(Song song) => Songs.Add(song);
        public void RemoveSong(Song song) => Songs.Remove(song);
        public override string ToString()
        {
            string r = $"+{Name}+  {ReleaseYear}  ____  genre:{Genre}  ____  copies:{SoldCopies}";
            return r;
        }
    }

    class Song
    {
        public Song(string name, Duration duration)
        {
            this.Name = name;
            this.Duration = duration;
        }
        public Song(string name, int hours, int minutes, int seconds) :this(name, new Duration(hours, minutes, seconds)) { }

        public string Name { get; private set; }
        public Duration Duration { get; private set; }
        public override string ToString()
        {
            string r = $"{Name} ({Duration})";
            return r;
        }
    }
 
    class Duration
    {
        int hours;
        int minutes;
        int seconds;
        
        public Duration(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }
        public override string ToString()
        {
            string beginning = hours != 0 ? hours + ":" : "";

            return beginning + minutes + ":" + seconds;
        }
    }
}
