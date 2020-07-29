using System;
using System.Collections.Generic;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;

namespace MoviesAPI.Controllers
{
    // I am avoiding the regx 'api/[Controller]' because if for some reason I change the class name then I have to change the api url on every client that is using it. 
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly IInMemoryRepository _inMemoryRepository;

        public GenresController(IInMemoryRepository inMemoryRepository)
        {
            _inMemoryRepository = inMemoryRepository;
        }

        // api/genres/1
        // In the template I have defined the type of the param id as int. This way routes like api/genres/test or api/genres/'1' will not be qualified route for this method. 
        [HttpGet("{id:int}")]
        public Genre GetGenreById(int id)
        {
            return _inMemoryRepository.GetGenre(id);
        }

        // api/genres
        [HttpGet]
        public IEnumerable<Genre> GetGenres()
        {
            return _inMemoryRepository.GetAllGenres();
        }

        // api/genres
        [HttpPost]
        public void AddGenre()
        {
            Console.Out.WriteLine("Post");
        }

        // api/genres/1
        [HttpPut]
        public void UpdateGenre()
        {
            Console.Out.WriteLine("Update");
        }

        // api/genres/1
        [HttpDelete]
        public void DeleteGenre()
        {
            Console.Out.WriteLine("Delete");
        }
    } 
}
