using Domain;

namespace WebUI.Interfaces
{
    public interface IBookDisplay : IGrid<Book>
    {
        List<Book> Books { get; set; }
        List<Book> TempBooks { get; set; }
        List<Genre> Genres { get; set; }
        List<Author> Authors { get; set; }
        List<Publisher> Publishers { get; set; }
    }
}
