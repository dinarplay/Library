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
        public IMediator Mediator { get; set; }
        public NavigationManager NavigationManager { get; set; }
        public IAuthProvider AuthProvider { get; set; }

        public ReserveManagerService(IMediator Mediator, NavigationManager NavigationManager, IAuthProvider AuthProvider)
        {
            this.Mediator = Mediator;
            this.NavigationManager = NavigationManager;
            this.AuthProvider = AuthProvider;
        }
        public async Task GiveReserve(Reserve reserve)
        {
            await Mediator.Send(new GiveReserveCommand() { Reserve = reserve });
        }
        public async Task TakeReserve(Reserve reserve)
        {
            await Mediator.Send(new TakeReserveCommand() { Reserve = reserve });
        }
        public async Task DoReserve(Book book)
        {
            await Mediator.Send(new DoReserveCommand() { Reserve = new() { Book = book, User = AuthProvider.CurrentUser }});
        }
        public async Task DoUnreserve(Reserve reserve)
        {
            await Mediator.Send(new DoUnreserveCommand() { Reserve = reserve });
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }
    }
}
