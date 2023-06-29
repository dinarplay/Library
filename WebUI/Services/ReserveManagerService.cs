using Application.Features.Reserves.Commands.DoReserve;
using Application.Features.Reserves.Commands.DoUnreserve;
using Application.Features.Reserves.Commands.GiveReserve;
using Application.Features.Reserves.Commands.TakeReserve;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;
using WebUI.Interfaces;

namespace WebUI.Services
{
    public class ReserveManagerService : IReserveManager
    {
        //DI
        private IMediator Mediator { get; set; }
        private IAuthProvider AuthProvider { get; set; }
        private NavigationManager NavigationManager { get; set; }
        public ReserveManagerService(IMediator mediator, NavigationManager navigationManager, IAuthProvider authProvider)
        {
            this.Mediator = mediator;
            this.NavigationManager = navigationManager;
            this.AuthProvider = authProvider;
        }

        public async Task GiveReserveAsync(Reserve reserve)
        {
            await Mediator.Send(new GiveReserveCommand() { Reserve = reserve });
        }
        public async Task TakeReserveAsync(Reserve reserve)
        {
            await Mediator.Send(new TakeReserveCommand() { Reserve = reserve });
        }
        public async Task DoReserveAsync(Book book)
        {
            await Mediator.Send(new DoReserveCommand() { Reserve = new() { Book = book, User = AuthProvider.CurrentUser }});
        }
        public async Task DoUnreserveAsync(Reserve reserve)
        {
            await Mediator.Send(new DoUnreserveCommand() { Reserve = reserve });
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }
    }
}
