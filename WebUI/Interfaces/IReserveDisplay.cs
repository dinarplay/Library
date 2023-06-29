using Domain;

namespace WebUI.Interfaces
{
    public interface IReserveDisplay : IGrid<Reserve>
    {
        List<Reserve> Reserves { get; set; }
        List<Reserve> TempReserves { get; set; }
        List<User> Users { get; set; }
        List<Book> Books { get; set; }
        List<Genre> Genres { get; set; }
        List<Author> Authors { get; set; }
        List<Publisher> Publishers { get; set; }
        Task GetGridAtUserAsync();
    }
}
