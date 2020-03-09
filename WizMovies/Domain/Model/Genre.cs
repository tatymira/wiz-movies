using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WizMovies.Domain.Model
{
    public class Genre
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
