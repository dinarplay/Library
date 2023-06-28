using Domain;

namespace Application.Interfaces
{
    public interface IDataManager
    {
        Task AddUserToBrowser(User user);
        Task ClearBrowserUserData();
        Task AddUserToDatabase(User user);
        Task<User?> FindUserInBrowser();
        Task<User?> FindUserInDatabase(string password, string email);
    }
}
