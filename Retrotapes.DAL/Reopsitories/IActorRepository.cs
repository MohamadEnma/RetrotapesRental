using Retrotapes.DAL.Models;

namespace Retrotapes.DAL.Repositories
{
    public interface IActorRepository : IGenericRepository<Actor>
    {
        IEnumerable<Actor> GetActorsByLastName(string lastName);
    }
}
