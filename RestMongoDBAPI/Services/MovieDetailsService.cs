using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RestMongoDBAPI.Models;

namespace RestMongoDBAPI.Services
{
    public class MovieDetailsService
    {
        private readonly IMongoCollection<Movie> _movie;

        public MovieDetailsService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MoviestoreDb"));
            var database = client.GetDatabase("test");
            _movie = database.GetCollection<Movie>("moviesScratch");
        }

        public List<Movie> GetAll()
        {
            return _movie.Find(movie => true).ToList();
        }

        public Movie Get(string id)
        {
            return _movie.Find(movie => movie.Id == id).FirstOrDefault();
        }

        public Movie Create(Movie movie)
        {
            _movie.InsertOne(movie);
            return movie;
        }

        public void Update(string id, Movie movieIn)
        {
            _movie.ReplaceOne(movie => movie.Id == id, movieIn);
        }

        public void Remove(Movie movieIn)
        {
            _movie.DeleteOne(movie => movie.Id == movieIn.Id);
        }

        public void Remove(string id)
        {
            _movie.DeleteOne(movie => movie.Id == id);
        }
    }
}
