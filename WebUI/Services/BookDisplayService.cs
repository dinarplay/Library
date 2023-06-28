using Application.Features.Books.Queries.GetAllAuthors;
using Application.Features.Books.Queries.GetAllBooks;
using Application.Features.Books.Queries.GetAllGenres;
using Application.Features.Books.Queries.GetAllPublishers;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components.QuickGrid;
using WebUI.Interfaces;

namespace WebUI.Services
{
    public class BookDisplayService : IBookDisplay
    {
        public List<Book> Books { get; set; }
        public List<Book> TempBooks { get; set; } = new List<Book>();
        public List<Genre> Genres { get; set; }
        public List<Author> Authors { get; set; }
        public List<Publisher> Publishers { get; set; }
        public QuickGrid<Book> Grid { get; set; }
        public PaginationState Pagination { get; set; } = new PaginationState() { ItemsPerPage = 10 };

        //DI
        public IMediator Mediator { get; set; }
        public BookDisplayService(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }
        public async Task GetGrid()
        {
            Genres = await Mediator.Send(new GetAllGenresQuery());
            Authors = await Mediator.Send(new GetAllAuthorsQuery());
            Publishers = await Mediator.Send(new GetAllPublishersQuery());
            Books = await Mediator.Send(new GetAllBooksQuery());
            TempBooks = Books;
        }

        public async Task ResetGrid()
        {
            Genres.Select(c => c.IsChoised = true).ToList();
            Publishers.Select(c => c.IsChoised = true).ToList();
            Authors.Select(c => c.IsChoised = true).ToList();
            TempBooks = Books;
            await Grid.RefreshDataAsync();
        }

        public async Task UpdateGrid()
        {
            TempBooks = Books.Where(c => c.Author.IsChoised == true).ToList();
            TempBooks = TempBooks.Where(c => c.Genre.IsChoised == true).ToList();
            TempBooks = TempBooks.Where(c => c.Publisher.IsChoised == true).ToList();
            await Grid.RefreshDataAsync();
        }
    }
}
