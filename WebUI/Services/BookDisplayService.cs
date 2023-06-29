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
        private IMediator Mediator { get; set; }
        public BookDisplayService(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        public async Task GetGridAsync()
        {
            Genres = await Mediator.Send(new GetAllGenresQuery());
            Authors = await Mediator.Send(new GetAllAuthorsQuery());
            Publishers = await Mediator.Send(new GetAllPublishersQuery());
            Books = await Mediator.Send(new GetAllBooksQuery());
            TempBooks = Books;
        }

        public async Task ResetGridAsync()
        {
            Genres.ForEach(c => c.IsChoised = true);
            Publishers.ForEach(c => c.IsChoised = true);
            Authors.ForEach(c => c.IsChoised = true);
            TempBooks = Books;
            await Grid.RefreshDataAsync();
        }

        public async Task UpdateGridAsync()
        {
            TempBooks = Books.Where(c => c.Author.IsChoised).ToList();
            TempBooks = TempBooks.Where(c => c.Genre.IsChoised).ToList();
            TempBooks = TempBooks.Where(c => c.Publisher.IsChoised).ToList();
            await Grid.RefreshDataAsync();
        }
    }
}
