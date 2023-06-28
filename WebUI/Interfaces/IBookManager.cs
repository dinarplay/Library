using Domain;

namespace WebUI.Interfaces
{
    public interface IBookManager
    {
        Book NewBook {  get; set; }
        Genre NewGenre {  get; set; }
        Author NewAuthor {  get; set; }
        Publisher NewPublisher {  get; set; }
        Task DeleteBook(Book book); 
        Task AddBook(Book book); 
        Task AddGenre(Genre genre); 
        Task AddPublisher(Publisher publisher); 
        Task AddAuthor(Author author); 
        bool IsShowAddMenu { get; set; }
        void CallAddMenu();
    }
}
