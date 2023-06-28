using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Publisher> Publishers { get; set; }
        DbSet<Reserve> Reserves { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
