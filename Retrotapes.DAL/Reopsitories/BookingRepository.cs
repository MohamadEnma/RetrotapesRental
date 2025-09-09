using Retrotapes.DAL.Data;
using Retrotapes.DAL.Models;

namespace Retrotapes.DAL.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(Retrotapes.DAL.Data.SakilaDbContext context) : base(context) { }

        public IEnumerable<Booking> GetBookingsByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
