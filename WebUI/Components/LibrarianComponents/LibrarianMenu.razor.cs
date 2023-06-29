using Domain;
using Microsoft.AspNetCore.Components;
using WebUI.Interfaces;

namespace WebUI.Components.LibrarianComponents
{
    public class LibrarianMenuModel : ComponentBase
    {
        [Inject]
        public IBookManager BookManagerService { get; set; }
        [Inject]
        public IBookDisplay BookDisplayService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await BookDisplayService.GetGridAsync();
        }
    }
}
