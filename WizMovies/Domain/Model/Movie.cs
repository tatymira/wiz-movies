using System;
using WizMovies.Domain.Enum;

namespace WizMovies.Domain.Model
{
    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public GenderEnum Gender { get; set; }

        public Movie() {}

        public Movie(int id, string title, DateTime releaseDate, int gender)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            Gender = (GenderEnum)gender;
        }

    }
}
