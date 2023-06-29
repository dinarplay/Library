using Domain;

namespace WebUI.Interfaces
{
    public interface IBookManager
    {
        Book NewBook {  get; set; }
        Genre NewGenre {  get; set; }
        Author NewAuthor {  get; set; }
        Publisher NewPublisher {  get; set; }
        Task DeleteBookAsync(Book book); 
        Task AddBookAsync(Book book); 
        Task AddGenreAsync(Genre genre); 
        Task AddPublisherAsync(Publisher publisher); 
        Task AddAuthorAsync(Author author); 
        bool IsShowAddMenu { get; set; }
        void CallAddMenu();
    }
}
