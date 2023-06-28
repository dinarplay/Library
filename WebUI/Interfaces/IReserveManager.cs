using Domain;

namespace WebUI.Interfaces
{
    public interface IReserveManager
    {
        Task GiveReserve(Reserve reserve);
        Task TakeReserve(Reserve reserve);
        Task DoReserve(Book book);
        Task DoUnreserve(Reserve reserve);
    }
}
