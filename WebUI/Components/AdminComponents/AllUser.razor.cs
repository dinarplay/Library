using Microsoft.AspNetCore.Components;
using WebUI.Interfaces;
using WebUI.Services;

namespace WebUI.Components.AdminComponents
{
    public class AllUserModel : ComponentBase
    {
        [Inject]
        public IUserManager UserManagerService { get; set; }
        [Inject]
        public IUserDisplay UserDisplayService { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await UserDisplayService.GetGrid();
        }
    }
}
