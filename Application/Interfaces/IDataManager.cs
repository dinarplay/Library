using Domain;

namespace Application.Interfaces
{
    public interface IDataManager
    {
        Task AddUserToBrowserAsync(User user);
        Task ClearBrowserUserDataAsync();
        Task AddUserToDatabaseAsync(User user);
        Task<User?> FindUserInBrowserAsync();
        Task<User?> FindUserInDatabaseAsync(string email);
    }
}
