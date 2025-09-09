using Retrotapes.DAL.Data;
using Retrotapes.DAL.Models;

namespace Retrotapes.DAL.Repositories
{
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        public FilmRepository(SakilaDbContext context) : base(context) { }

        public IEnumerable<Film> GetFilmsByCategory(string category)
        {
            return _dbSet.Where(f => f.FilmCategories.Any(fc => fc.Category.Name == category)).ToList();
        }
    }
}
