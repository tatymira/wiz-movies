using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WizMovies.Domain;
using WizMovies.Domain.Interface;
using WizMovies.Domain.Model;
using WizMovies.Service;

namespace WizMovies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly ITheMovieDBService _service;

        public MovieController(ITheMovieDBService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public Task<IEnumerable<Movie>> GetAll()
        {
            return _service.GetMovies();
        }
    }
}
