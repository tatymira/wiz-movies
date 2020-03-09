using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WizMovies.Domain.Enum;
using WizMovies.Domain.Interface;
using WizMovies.Domain.Model;

namespace WizMovies.Service
{
    public class TheMovieDBService : ITheMovieDBService
    {
        static readonly HttpClient client = new HttpClient();

        private readonly IConfiguration _config;

        public TheMovieDBService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            List<Movie> returnList = new List<Movie>();
            int pages = 5;
            int currentPage = 1;

            while (currentPage <= pages)
            {
                string theMovieDbUrl = _config.GetValue<string>("Urls:TheMovieDb:Movies");

                HttpResponseMessage response = await client.GetAsync(theMovieDbUrl + currentPage);
                string responseBody = await response.Content.ReadAsStringAsync();
                dynamic data = JObject.Parse(responseBody);
                var results = data.results;

                var genres = GetGenres().Result;
                List<Movie> currentList = new List<Movie>();
                foreach (var item in results)
                {
                    var movie = new Movie(
                          (int)item.id,
                          (string)item.title,
                          (DateTime)item.release_date);

                    foreach (var genre in item.genre_ids)
                    {
                        movie.AddGenres(genres.Where(x => x.Id == (int)genre).ToList()); 
                    }
                    currentList.Add(movie);
                }
                returnList.AddRange(currentList);
                currentPage++;
            }

            return returnList.Where(x => x.ReleaseDate > DateTime.Now).ToList();

        }


        public async Task<IEnumerable<Genre>> GetGenres()
        {
            string theMovieDbUrlGenre = _config.GetValue<string>("Urls:TheMovieDb:Genres");
            HttpResponseMessage responseGenre = await client.GetAsync(theMovieDbUrlGenre);
            string responseBodyGenre = await responseGenre.Content.ReadAsStringAsync();
            dynamic dataGenre = JObject.Parse(responseBodyGenre);
            var resultsGenre = dataGenre.genres;

            var genres = new List<Genre>();

            foreach (var genre in resultsGenre)
            {
                genres.Add(new Genre((int)genre.id, (string)genre.name));
            }

            return genres;

        }

    }
}
