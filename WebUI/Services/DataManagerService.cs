using Application.Features.Users.Commands.AddUser;
using Application.Features.Users.Queries.GetUserByEmail;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;

namespace WebUI.Services
{
    public class DataManagerService : IDataManager
    {
        //DI
        private readonly ProtectedLocalStorage ProtectedLocalStorage;
        private readonly IMediator Mediator;
        public DataManagerService(ProtectedLocalStorage protectedLocalStorage, IMediator mediator)
        {
            this.ProtectedLocalStorage = protectedLocalStorage;
            this.Mediator = mediator;
        }

        public async Task AddUserToBrowserAsync(User user) //Сохранение текущего пользоваетеля в хранилище браузера
        {
            string userJson = JsonConvert.SerializeObject(user);
            await ProtectedLocalStorage.SetAsync("AuthUser", userJson);
        }
        public async Task AddUserToDatabaseAsync(User user) //Регистрация нового пользователя
        {
            await Mediator.Send(new AddUserCommand() { User = user });
        }
        public async Task<User?> FindUserInBrowserAsync() //Получение данных пользователя из хранилища браузера
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
        public async Task<User?> FindUserInDatabaseAsync(string email) //Поиск пользователя в БД
        {
            var foundedUser = await Mediator.Send(new GetUserByEmailQuery() { Email = email });
            return foundedUser;
        }
        public async Task ClearBrowserUserDataAsync() //Удаление данных пользователя из хранилища браузера
        {
            await ProtectedLocalStorage.DeleteAsync("AuthUser");
        }
    }
}
