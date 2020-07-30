using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repositories.Interfaces;

namespace MoviesAPI.Controllers
{
    // I am avoiding the regx 'api/[Controller]' because if for some reason I change the class name then I have to change the api url on every client that is using it. 
    [Route("api/genres")]
    // 1) There might be multiple benefits of using this attribute but at present I am using this for model state state validation.
    // It means, if the model property is marked as required or content length fixed or other similar validation then api will return json result with errors, without executing any code of api method. 
    // 2) If you are using this you don't have to write attribute like [FromBody] etc.
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IInMemoryRepository _inMemoryRepository;
        private readonly ILogger<GenresController> _logger;

        public GenresController(IInMemoryRepository inMemoryRepository, ILogger<GenresController> logger)
        {
            _inMemoryRepository = inMemoryRepository;
            _logger = logger;
        }

        // api/genres/1
        // In the template I have defined the type of the param id as int. This way routes like api/genres/test or api/genres/'1' will not be qualified route for this method. 
        [HttpGet("{id:int}", Name = "getGenre")]
        public async Task<ActionResult<Genre>> GetGenreById(int id)
        {
            var genre = await _inMemoryRepository.GetGenre(id);
            if (genre == null)
            {
                _logger.LogWarning($"Genre with id {id} not found");
                return NotFound();
            }
            return genre;
        }

        // api/genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return await _inMemoryRepository.GetAllGenres(); 
        } 

        // api/genres
        [HttpPost]
        public ActionResult AddGenre(Genre genre)
        {
            _inMemoryRepository.AddGenre(genre);
            
            return CreatedAtRoute("getGenre", new  {id=genre.Id},genre);
        }

        // api/genres/1
        [HttpPut]
        public ActionResult UpdateGenre()
        {
            return NoContent();
        }

        // api/genres/1
        [HttpDelete]
        public ActionResult DeleteGenre()
        {
            return NoContent();
        }
    } 
}
