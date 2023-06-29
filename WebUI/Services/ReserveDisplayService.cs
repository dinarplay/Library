using Application.Features.Books.Queries.GetAllAuthors;
using Application.Features.Books.Queries.GetAllBooks;
using Application.Features.Books.Queries.GetAllGenres;
using Application.Features.Books.Queries.GetAllPublishers;
using Application.Features.Reserves.Queries.GetAllReserves;
using Application.Features.Reserves.Queries.GetReservesAtUser;
using Application.Features.Users.Queries.GetAllUsers;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components.QuickGrid;
using WebUI.Interfaces;

namespace WebUI.Services
{
    public class ReserveDisplayService : IReserveDisplay
    {
        public List<Reserve> Reserves { get; set; }
        public List<Reserve> TempReserves { get; set; } = new List<Reserve>();
        public List<User> Users { get; set; }
        public List<Book> Books { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Author> Authors { get; set; }
        public List<Publisher> Publishers { get; set; }
        public QuickGrid<Reserve> Grid { get; set; }
        public PaginationState Pagination { get; set; } = new() { ItemsPerPage = 10 };

        //DI
        private IMediator Mediator { get; set; }
        private IAuthProvider AuthProvider { get; set; }
        public ReserveDisplayService(IMediator mediator, IAuthProvider authProvider)
        {
            this.Mediator = mediator;
            this.AuthProvider = authProvider;
        }

        public async Task GetGridAsync()
        {
            Books = await Mediator.Send(new GetAllBooksQuery());
            Genres = await Mediator.Send(new GetAllGenresQuery());
            Authors = await Mediator.Send(new GetAllAuthorsQuery());
            Publishers = await Mediator.Send(new GetAllPublishersQuery());
            Users = await Mediator.Send(new GetAllUsersQuery());
            Reserves = await Mediator.Send(new GetAllReservesQuery());
            TempReserves = Reserves;
        }
        public async Task ResetGridAsync()
        {
            Genres.ForEach(c => c.IsChoised = true);
            Publishers.ForEach(c => c.IsChoised = true);
            Authors.ForEach(c => c.IsChoised = true);
            await Grid.RefreshDataAsync();
        }
        public async Task UpdateGridAsync()
        {
            TempReserves = Reserves.Where(c => c.Book.Author.IsChoised).ToList();
            TempReserves = TempReserves.Where(c => c.Book.Genre.IsChoised).ToList();
            TempReserves = TempReserves.Where(c => c.Book.Publisher.IsChoised).ToList();
            await Grid.RefreshDataAsync();
        }
        public async Task GetGridAtUserAsync()
        {
            Books = await Mediator.Send(new GetAllBooksQuery());
            Genres = await Mediator.Send(new GetAllGenresQuery());
            Authors = await Mediator.Send(new GetAllAuthorsQuery());
            Publishers = await Mediator.Send(new GetAllPublishersQuery());
            Reserves = await Mediator.Send(new GetReservesAtUserQuery() { User = AuthProvider.CurrentUser });
            TempReserves = Reserves;
        }
    }
}
