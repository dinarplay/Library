using Microsoft.AspNetCore.Components;
using WebUI.Interfaces;

namespace WebUI.Components.LibrarianComponents
{
    public class AllReservesModel : ComponentBase
    {
        [Inject]
        public IReserveManager ReserveManagerService { get; set; }
        [Inject]
        public IReserveDisplay ReserveDisplayService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await ReserveDisplayService.GetGridAsync();
        }
    }
}
