using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class InMemoryRepository: IInMemoryRepository
    {
        private readonly List<Genre> _genres;

        public InMemoryRepository()
        {
            _genres= new List<Genre>()
            {
                new Genre(){Id = 1, Name =  "Drama"},
                new Genre(){Id = 2, Name =  "Comedy"},
                new Genre(){Id = 3, Name =  "Action"},
                new Genre(){Id = 4, Name =  "Horror"},
            };
        }

        public void AddGenre(Genre genre)
        {
            genre.Id = _genres.Max(g => g.Id)+1;
            _genres.Add(genre);
        }

        public async Task<List<Genre>> GetAllGenres()
        {

            await Task.Delay(1);// Will remove this later when data will be fetched from DB
            return _genres;
        }

        public async Task<Genre> GetGenre(int id)
        {

            await Task.Delay(1);// Will remove this later when data will be fetched from DB
            return _genres.FirstOrDefault(g => g.Id == id);
        }
    }
}
