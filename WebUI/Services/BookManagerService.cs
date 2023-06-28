using Application.Features.Books.Commands.AddAuthor;
using Application.Features.Books.Commands.AddBook;
using Application.Features.Books.Commands.AddGenre;
using Application.Features.Books.Commands.AddPublisher;
using Application.Features.Books.Commands.DeleteBook;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;
using WebUI.Interfaces;

namespace WebUI.Services
{
    public class BookManagerService : IBookManager
    {        
        public Book NewBook { get; set; }
        public Genre NewGenre { get; set; }
        public Author NewAuthor { get; set; }
        public Publisher NewPublisher { get; set; }
        public bool IsShowAddMenu { get; set; }

        //DI
        public IMediator Mediator { get; set; }
        public NavigationManager NavigationManager { get; set; }
        public BookManagerService(IMediator Mediator, NavigationManager NavigationManager)
        {
            this.Mediator = Mediator;
            this.NavigationManager = NavigationManager;
        }        
        public async Task DeleteBook(Book book)
        {
            await Mediator.Send(new DeleteBookCommand() { Id = book.Id });
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }
        public async Task AddBook(Book book)
        {
            await Mediator.Send(new AddBookCommand() { Book = book });
        }
        public async Task AddGenre(Genre Genre)
        {
            await Mediator.Send(new AddGenreCommand() { Genre = Genre });
        }
        public async Task AddAuthor(Author Author)
        {
            await Mediator.Send(new AddAuthorCommand() { Author = Author });
        }
        public async Task AddPublisher(Publisher Publisher)
        {
            await Mediator.Send(new AddPublisherCommand() { Publisher = Publisher });
        }

        public void CallAddMenu()
        {
            IsShowAddMenu = true;
            NewBook = new(); 
            NewAuthor = new();
            NewPublisher = new();
            NewGenre = new();
        }
    }
}
