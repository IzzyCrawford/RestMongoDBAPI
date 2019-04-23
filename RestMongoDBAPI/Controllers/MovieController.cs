using System.Collections.Generic;
using RestMongoDBAPI.Models;
using RestMongoDBAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RestMongoDBAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Movie/")]
    
    public class MovieController : ControllerBase
    {
        private readonly MovieDetailsService _movieDetailsService;
        
        public MovieController(MovieDetailsService movieDetailsService)
        {
            _movieDetailsService = movieDetailsService;
        }

        // GET: api/Movie
        [HttpGet]
        public IEnumerable<List<Movie>> GetAll()
        {
            yield return _movieDetailsService.GetAll();
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public IEnumerable<Movie> Get(string id)
        {
            yield return _movieDetailsService.Get(id);
        }
        
        // POST: api/Movie
        [HttpPost("{id}/{title}/{year}/{type}")]
        public void HttpPostAttribute(Movie value)
        {
             _movieDetailsService.Create(value);
        }
        
        // PUT: api/Movie/5
        [HttpPut("{id}/{title}/{year}/{type}")]
        public void Put(string id, Movie movieIn)
        {
            _movieDetailsService.Update(id, movieIn);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _movieDetailsService.Remove(id);
        }
    }
}
