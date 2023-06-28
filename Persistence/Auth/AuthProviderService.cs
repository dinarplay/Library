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
        public readonly IDataManager DataManagerService;
        public readonly NavigationManager NavigationManager;
        public AuthProviderService(IDataManager DataManagerService, NavigationManager NavigationManager)
        {
            this.DataManagerService = DataManagerService;
            this.NavigationManager = NavigationManager;
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
            var user = await DataManagerService.FindUserInBrowser();
            if (user != null)
            {
                var userInDataBase = await DataManagerService.FindUserInDatabase(user.Email, user.Password);
                if (userInDataBase != null)
                {
                    CurrentUser = userInDataBase;
                    principal = userInDataBase.ToClaimsPrincipal();
                }
            }
            var authState = new AuthenticationState(principal);
            return authState;
            }
        async public Task Login(string email, string password)
        {
            var principal = new ClaimsPrincipal();
            var user = await DataManagerService.FindUserInDatabase(email, password);
            if (user != null)
            {
                CurrentUser = user;
                await DataManagerService.AddUserToBrowser(user);
                principal = user.ToClaimsPrincipal();
            }
            var authState = new AuthenticationState(principal);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }
        async public Task Signup(User sendUser)
        {
            var principal = new ClaimsPrincipal();
            var foundUser = await DataManagerService.FindUserInDatabase(sendUser.Email, sendUser.Password);
            if (foundUser is null)
            {
                CurrentUser = foundUser;
                await DataManagerService.AddUserToDatabase(sendUser);
                await DataManagerService.AddUserToBrowser(sendUser);
                principal = sendUser.ToClaimsPrincipal();
            }
            var authState = new AuthenticationState(principal);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }
        async public Task Logout()
        {
            await DataManagerService.ClearBrowserUserData();
            var principal = new ClaimsPrincipal();
            var authState = new AuthenticationState(principal);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }
    }
}
