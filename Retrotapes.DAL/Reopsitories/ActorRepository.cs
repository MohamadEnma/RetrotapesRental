using Retrotapes.DAL.Data;
using Retrotapes.DAL.Models;

namespace Retrotapes.DAL.Repositories
{
public class ActorRepository : GenericRepository<Actor>, IActorRepository
{
    public ActorRepository(SakilaDbContext context) : base(context) { }


    public IEnumerable<Actor> GetActorsByFirstName(string firstName)
    {
        return _dbSet.Where(a => a.FirstName == firstName).ToList();
    }

    public IEnumerable<Actor> GetActorsByLastName(string lastName)
    {
        return _dbSet.Where(a => a.LastName == lastName).ToList();
    }
}}
