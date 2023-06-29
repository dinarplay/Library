using Application.Features.Users.Commands.AddUser;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Commands.UpdateUser;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;
using WebUI.Interfaces;

namespace WebUI.Services
{
    public class UserManagerService : IUserManager
    {
        public User CurrentUser { get; set; }
        public User NewUser { get; set; }
        public string SearchText { get; set; }
        public string NewPass { get; set; }
        public bool IsShowChangeMenu { get; set; }
        public bool IsShowAddMenu { get; set; }

        //DI
        private IMediator Mediator { get; set; }
        private NavigationManager NavigationManager { get; set; }
        public UserManagerService(IMediator mediator, NavigationManager navigationManager)
        {
            this.Mediator = mediator;
            this.NavigationManager = navigationManager;
        }

        public void CallChangeMenu(User user)
        {
            CurrentUser = new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                RoleId = user.RoleId,                
            };
            IsShowChangeMenu = true;
        }
        public void CallAddMenu()
        {
            NewUser = new();
            IsShowAddMenu = true;
        }
        public async Task AddUserAsync(User user)
        {
            await Mediator.Send(new AddUserCommand() { User = user });
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }
        public async Task ChangeUserAsync(User user)
        {
            await Mediator.Send(new UpdateUserCommand() { User = user });
        }
        public async Task DeleteUserAsync(User user)
        {
            await Mediator.Send(new DeleteUserCommand() { User = user });
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }
        
    }
}
