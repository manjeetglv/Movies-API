using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories.Interfaces
{
    public interface IInMemoryRepository
    {
        Task<List<Genre>> GetAllGenres();
        Task<Genre> GetGenre(int id);

        void AddGenre(Genre genre);
    }
}
