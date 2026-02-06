using Lab6.Services.Interfaces;

namespace Lab6_Bai1.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;

        public ReservationService(AppDbContext context)
        {
            _context = context;
        }

        public List<Reservation> GetAll() =>
            _context.Reservations.ToList();

        public Reservation? GetById(int id) =>
            _context.Reservations.Find(id);

        public void Add(Reservation r)
        {
            _context.Reservations.Add(r);
            _context.SaveChanges();
        }

        public void Update(Reservation r)
        {
            _context.Reservations.Update(r);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var r = _context.Reservations.Find(id);
            if (r != null)
            {
                _context.Reservations.Remove(r);
                _context.SaveChanges();
            }
        }
    }
}
