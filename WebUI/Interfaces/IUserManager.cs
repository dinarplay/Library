using Domain;

namespace WebUI.Interfaces
{
    public interface IUserManager
    {
        User CurrentUser { get; set; }
        User NewUser { get; set; }
        Task ChangeUserAsync(User user);
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        void CallChangeMenu(User user);
        void CallAddMenu();
        string SearchText { get; set; }
        string NewPass { get; set; }
        bool IsShowChangeMenu { get; set; }
        bool IsShowAddMenu { get; set; }
    }   
}
