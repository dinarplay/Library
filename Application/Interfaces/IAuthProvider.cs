using Domain;

namespace Application.Interfaces
{
    public interface IAuthProvider
    {
        User CurrentUser { get; set; }
        Task LoginAsync(string email, string password);
        Task SignupAsync(User sendUser);
        Task LogoutAsync();
    }
}
