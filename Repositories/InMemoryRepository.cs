using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Genre> GetAllGenres()
        {
            return _genres;
        }

        public Genre GetGenre(int id)
        {
            return _genres.FirstOrDefault(g => g.Id == id);
        }
    }
}
