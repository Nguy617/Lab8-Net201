namespace Lab6.Services.Interfaces
{
    public interface IReservationService
    {
        List<Reservation> GetAll();
        Reservation? GetById(int id);
        void Add(Reservation r);
        void Update(Reservation r);
        void Delete(int id);
    }
}
