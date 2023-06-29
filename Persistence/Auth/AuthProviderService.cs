using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Persistence.Auth
{
    public class AuthProviderService : AuthenticationStateProvider, IAuthProvider, IDisposable 
    {
        public User CurrentUser { get; set; } = new();

        //DI
        private readonly IDataManager DataManagerService;
        public AuthProviderService(IDataManager dataManagerService)
        {
            this.DataManagerService = dataManagerService;
            AuthenticationStateChanged += OnAuthenticationStateChangedAsync;
        }

        public void Dispose()
        {
            AuthenticationStateChanged -= OnAuthenticationStateChangedAsync;
        }
        private async void OnAuthenticationStateChangedAsync(Task<AuthenticationState> task)
        {
            var authenticationState = await task;
            if (authenticationState is not null)
            {
                CurrentUser = User.FromClaimsPrincipal(authenticationState.User);
            }
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var principal = new ClaimsPrincipal();
            var user = await DataManagerService.FindUserInBrowserAsync();
            if (user != null)
            {
                var userInDataBase = await DataManagerService.FindUserInDatabaseAsync(user.Email);
                if (userInDataBase != null && user.Password == userInDataBase.Password)
                {
                    principal = userInDataBase.ToClaimsPrincipal();
                    CurrentUser = userInDataBase;
                }
            }
            var authState = new AuthenticationState(principal);
            return authState;
        }
        public async Task LoginAsync(string email, string password)
        {
            var principal = new ClaimsPrincipal();
            var user = await DataManagerService.FindUserInDatabaseAsync(email);
            if (user != null && user.CheckPassword(password))
            {
                await DataManagerService.AddUserToBrowserAsync(user);
                principal = user.ToClaimsPrincipal();
                CurrentUser = user;
            }
            var authState = new AuthenticationState(principal);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }
        public async Task SignupAsync(User user)
        {
            var principal = new ClaimsPrincipal();
            var foundUser = await DataManagerService.FindUserInDatabaseAsync(user.Email);
            if (foundUser is null)
            {
                user.RoleId = 2;
                user.Password = User.SetPassword(user.Password);
                await DataManagerService.AddUserToDatabaseAsync(user);
                await DataManagerService.AddUserToBrowserAsync(user);
                principal = user.ToClaimsPrincipal();
                CurrentUser = user;
            }
            var authState = new AuthenticationState(principal);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }
        public async Task LogoutAsync()
        {
            await DataManagerService.ClearBrowserUserDataAsync();
            var principal = new ClaimsPrincipal();
            var authState = new AuthenticationState(principal);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }
    }
}
