using Domain;

namespace Application.Interfaces
{
    public interface IAuthProvider
    {
        User CurrentUser { get; set; }
        Task Login(string email, string password);
        Task Signup(User sendUser);
        Task Logout();
    }
}
