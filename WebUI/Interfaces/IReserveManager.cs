using Domain;

namespace WebUI.Interfaces
{
    public interface IReserveManager
    {
        Task GiveReserveAsync(Reserve reserve);
        Task TakeReserveAsync(Reserve reserve);
        Task DoReserveAsync(Book book);
        Task DoUnreserveAsync(Reserve reserve);
    }
}
