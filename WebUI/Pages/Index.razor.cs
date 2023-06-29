using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Components;

namespace WebUI.Pages
{
    public class IndexModel : ComponentBase
    {
        [Inject]
        public IAuthProvider AuthProvider { get; set; }

        public User Admin { get; set; }
        public User Libr { get; set; }
        public User Client { get; set; }
        public User NewUser { get; set; }

        protected override Task OnInitializedAsync()
        {
            Admin = new() { Email = "admin@mail.com", Password = "jhon" };
            Libr = new() { Email = "libr@mail.com", Password = "susan" };
            Client = new() { Email = "user@mail.com", Password = "smit" };
            NewUser = new();
            return base.OnInitializedAsync();
        }
        public void Login(User user)
        {
            AuthProvider.LoginAsync(user.Email, user.Password);
        }
    }
}
