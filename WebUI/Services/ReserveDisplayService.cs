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
        public IMediator Mediator { get; set; }
        public IAuthProvider AuthProvider { get; set; }

        public ReserveDisplayService(IMediator Mediator, IAuthProvider AuthProvider)
        {
            this.Mediator = Mediator;
            this.AuthProvider = AuthProvider;
        }
        public async Task GetGrid()
        {
            Books = await Mediator.Send(new GetAllBooksQuery());
            Genres = await Mediator.Send(new GetAllGenresQuery());
            Authors = await Mediator.Send(new GetAllAuthorsQuery());
            Publishers = await Mediator.Send(new GetAllPublishersQuery());
            Users = await Mediator.Send(new GetAllUsersQuery());
            Reserves = await Mediator.Send(new GetAllReservesQuery());
            TempReserves = Reserves;
        }
        public async Task ResetGrid()
        {
            Genres.Select(c => c.IsChoised = true).ToList();
            Publishers.Select(c => c.IsChoised = true).ToList();
            Authors.Select(c => c.IsChoised = true).ToList();
            await Grid.RefreshDataAsync();
        }
        public async Task UpdateGrid()
        {
            TempReserves = Reserves.Where(c => c.Book.Author.IsChoised == true).ToList();
            TempReserves = TempReserves.Where(c => c.Book.Genre.IsChoised == true).ToList();
            TempReserves = TempReserves.Where(c => c.Book.Publisher.IsChoised == true).ToList();
            await Grid.RefreshDataAsync();
        }
        public async Task GetGridAtUser()
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
