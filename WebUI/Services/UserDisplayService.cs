using Application.Features.Users.Queries.GetAllUsers;
using Application.Features.Users.Queries.GetAllRoles;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components.QuickGrid;
using WebUI.Interfaces;

namespace WebUI.Services
{
    public class UserDisplayService : IUserDisplay
    {
        public List<User> Users { get; set; }
        public List<User> TempUsers { get; set; } = new List<User>();
        public List<Role> Roles { get; set; }
        public QuickGrid<User> Grid { get; set; }
        public PaginationState Pagination { get; set; } = new() { ItemsPerPage = 10 };

        //DI
        public IMediator Mediator { get; set; }

        public UserDisplayService(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }
        public async Task GetGrid()
        {
            Roles = await Mediator.Send(new GetAllRolesQuery());
            Users = await Mediator.Send(new GetAllUsersQuery());
            TempUsers = Users;
        }
        public async Task ResetGrid()
        {
            Roles.Select(c => c.IsChoised = true).ToList();
            TempUsers = Users;
            await Grid.RefreshDataAsync();
        }
        public async Task UpdateGrid()
        {
            TempUsers = Users.Where(c => c.Role.IsChoised == true).ToList();
            await Grid.RefreshDataAsync();
        }
    }
}
