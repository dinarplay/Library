using MediatR;
using Microsoft.AspNetCore.Components;
using WebUI.Interfaces;

namespace WebUI.Components.UserComponents
{
    public class AllBooksModel : ComponentBase
    {
        [Inject]
        public IReserveManager ReserveManagerService { get; set; }
        [Inject]
        public IBookDisplay BookDisplayService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await BookDisplayService.GetGridAsync();
        }
    }
}
