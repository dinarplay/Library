using Microsoft.AspNetCore.Components;
using WebUI.Interfaces;

namespace WebUI.Components.UserComponents
{
    public class ReservedBooksModel : ComponentBase
    {
        [Inject]
        public IReserveManager ReserveManagerService { get; set; }
        [Inject]
        public IReserveDisplay ReserveDisplayService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await ReserveDisplayService.GetGridAtUserAsync();
        }
    }
}
