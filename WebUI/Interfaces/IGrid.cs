﻿using Domain;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace WebUI.Interfaces
{
    public interface IGrid<T> where T : class
    {
        QuickGrid<T> Grid { get; set; }
        PaginationState Pagination { get; set; }
        Task UpdateGridAsync();
        Task ResetGridAsync();
        Task GetGridAsync();
    }
}
