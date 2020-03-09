using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizMovies.Domain.Model;

namespace WizMovies.Domain.Interface
{
    public interface ITheMovieDBService
    {
        Task<IEnumerable<Movie>> GetMovies();
    }
}
