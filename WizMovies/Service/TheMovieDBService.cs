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

            while (currentPage <= pages) {
                string theMovieDbUrl = _config.GetValue<string>("Urls:TheMovieDb");

                HttpResponseMessage response = await client.GetAsync(theMovieDbUrl + currentPage);
                string responseBody = await response.Content.ReadAsStringAsync();
                dynamic data = JObject.Parse(responseBody);
                var results = data.results;

                Random rnd = new Random();
                List<Movie> currentList = new List<Movie>();
                foreach (var item in results)
                {
                    currentList.Add(
                        new Movie(
                          (int)item.id,
                          (string)item.title,
                          (DateTime)item.release_date,
                          rnd.Next(1, 29))
                        );
                }
                returnList.AddRange(currentList);
                currentPage++;
            }

            return returnList.Where(x => x.ReleaseDate > DateTime.Now).ToList();

        }
                
    }
}
