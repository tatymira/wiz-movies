using System;
using System.Collections.Generic;

namespace WizMovies.Domain.Model
{
    public class Movie
    {

        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public List<Genre> Genres { get; private set; }

        public Movie() {}

        public Movie(int id, string title, DateTime releaseDate)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
        }

        public void AddGenres(List<Genre> genres)
        {
            Genres = genres;
        }

    }
}
