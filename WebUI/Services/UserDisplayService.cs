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
        private IMediator Mediator { get; set; }
        public UserDisplayService(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        public async Task GetGridAsync()
        {
            Roles = await Mediator.Send(new GetAllRolesQuery());
            Users = await Mediator.Send(new GetAllUsersQuery());
            TempUsers = Users;
        }
        public async Task ResetGridAsync()
        {
            Roles.ForEach(c => c.IsChoised = true);
            TempUsers = Users;
            await Grid.RefreshDataAsync();
        }
        public async Task UpdateGridAsync()
        {
            TempUsers = Users.Where(c => c.Role.IsChoised).ToList();
            await Grid.RefreshDataAsync();
        }
    }
}
