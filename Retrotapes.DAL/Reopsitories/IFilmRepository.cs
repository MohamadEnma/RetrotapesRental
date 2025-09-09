using Retrotapes.DAL.Models;
using Retrotapes.DAL.Repositories;

namespace Retrotapes.DAL.Data
{
    public interface IFilmRepository : IGenericRepository<Film>
    {
        IEnumerable<Film> GetFilmsByCategory(string category);
    }
}
