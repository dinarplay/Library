using Domain;

namespace WebUI.Interfaces
{
    public interface IUserDisplay : IGrid<User>
    {
        List<User> Users { get; set; }
        List<User> TempUsers { get; set; }
        List<Role> Roles { get; set; }
    }
}
