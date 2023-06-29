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
        private IMediator Mediator { get; set; }
        private NavigationManager NavigationManager { get; set; }
        public BookManagerService(IMediator mediator, NavigationManager navigationManager)
        {
            this.Mediator = mediator;
            this.NavigationManager = navigationManager;
        }        

        public async Task DeleteBookAsync(Book book)
        {
            await Mediator.Send(new DeleteBookCommand() { Id = book.Id });
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }
        public async Task AddBookAsync(Book book)
        {
            await Mediator.Send(new AddBookCommand() { Book = book });
        }
        public async Task AddGenreAsync(Genre genre)
        {
            await Mediator.Send(new AddGenreCommand() { Genre = genre });
        }
        public async Task AddAuthorAsync(Author author)
        {
            await Mediator.Send(new AddAuthorCommand() { Author = author });
        }
        public async Task AddPublisherAsync(Publisher publisher)
        {
            await Mediator.Send(new AddPublisherCommand() { Publisher = publisher });
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
