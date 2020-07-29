using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Repositories.Interfaces
{
    public interface IInMemoryRepository
    {
        List<Genre> GetAllGenres();
        Genre GetGenre(int id);
    }
}
