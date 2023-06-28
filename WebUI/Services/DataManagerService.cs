using Application.Features.Users.Commands.AddUser;
using Application.Features.Users.Queries.GetAllUsers;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;

namespace WebUI.Services
{
    public class DataManagerService : IDataManager
    {
        private readonly ProtectedLocalStorage ProtectedLocalStorage;
        private readonly IMediator Mediator;
        public DataManagerService(ProtectedLocalStorage protectedLocalStorage, IMediator Mediator)
        {
            this.ProtectedLocalStorage = protectedLocalStorage;
            this.Mediator = Mediator;
        }
        async public Task AddUserToBrowser(User user) //Сохранение текущего пользоваетеля в хранилище браузера
        {
            string userJson = JsonConvert.SerializeObject(user);
            await ProtectedLocalStorage.SetAsync("AuthUser", userJson);
        }
        async public Task AddUserToDatabase(User user) //Регистрация нового пользователя
        {
            await Mediator.Send(new AddUserCommand() { User = user });
        }
        async public Task<User?> FindUserInBrowser() //Получение данных пользователя из хранилища браузера
        {
            try
            {
                var storedUser = await ProtectedLocalStorage.GetAsync<string>("AuthUser");
                if (storedUser.Success && !string.IsNullOrEmpty(storedUser.Value))
                {
                    var user = JsonConvert.DeserializeObject<User>(storedUser.Value);
                    return user;
                }
            }
            catch (Exception) { }
            return null;
        }
        async public Task<User?> FindUserInDatabase(string email, string password   ) //Поиск пользователя в БД
        {
            var allUsers = await Mediator.Send(new GetAllUsersQuery());
            var foundedUser = allUsers.FirstOrDefault(c => c.Password == password && c.Email == email);
            return foundedUser;
        }
        async public Task ClearBrowserUserData() //Удаление данных пользователя из хранилища браузера
        {
            await ProtectedLocalStorage.DeleteAsync("AuthUser");
        }
    }
}
