using Retrotapes.DAL.Models;

namespace Retrotapes.DAL.Repositories
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        IEnumerable<Booking> GetBookingsByCustomerId(int customerId);
    }
}
