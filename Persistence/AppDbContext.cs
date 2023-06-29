using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfigurations;
using System.Reflection;

namespace Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Publisher>().HasData(publishers);
            modelBuilder.Entity<Genre>().HasData(genres);
            modelBuilder.Entity<Book>().HasData(books);
        }
        //Чисто для наглядности
        List<Role> roles = new List<Role>
        {
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "User"
                },
                new Role
                {
                    Id = 3,
                    Name = "Librarian"
                }
        };
        List<User> users = new List<User>
        {
                new User
                {
                    Id = 1,
                    Name = "Jhon",
                    Email = "admin@mail.com",
                    Password = User.SetPassword("jhon"),
                    RoleId = 1,
                },
                new User
                {
                    Id = 2,
                    Name = "Susan",
                    Email = "libr@mail.com",
                    Password = User.SetPassword("susan"),
                    RoleId = 3,
                },
                new User
                {
                    Id = 3,
                    Name = "Smit",
                    Email = "user@mail.com",
                    Password = User.SetPassword("smit"),
                    RoleId = 2
                }
        };
        List<Author> authors = new List<Author>
        {
                new Author
                {
                    Id = 1,
                    Name = "Lory",
                    Description = "Lory's desc"
                },
                new Author
                {
                    Id = 2,
                    Name = "Fufan",
                    Description = "Fufan's desc"
                }
        };
        List<Genre> genres = new List<Genre>
        {
                new Genre
                {
                    Id = 1,
                    Name = "Horror",
                    Description = "Scarrry"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Fantasy",
                    Description = "Very interesting"
                }
        };
        List<Publisher> publishers = new List<Publisher>
        {
                new Publisher
                {
                    Id = 1,
                    Name = "KT Studio",
                    Description = "Some desc"
                },
                new Publisher
                {
                    Id = 2,
                    Name = "GM's book",
                    Description = "Desc about pub"
                }
        };
        List<Book> books = new List<Book>
        {
                new Book
                {
                    Id = 1,
                    Title = "Elder's ring",
                    Description = "fantasy book",
                    Count = 10,
                    AuthorId = 1,
                    GenreId = 2,
                    PublisherId = 1,
                },
                new Book
                {
                    Id = 2,
                    Title = "Carry machine",
                    Description = "Kyberpunk book",
                    Count = 7,
                    AuthorId = 2,
                    GenreId = 1,
                    PublisherId = 2,
                },
                new Book
                {
                    Id = 3,
                    Title = "Slyders",
                    Description = "Richest man live book",
                    Count = 18,
                    AuthorId = 2,
                    GenreId = 1,
                    PublisherId = 1,
                },
                new Book
                {
                    Id = 4,
                    Title = "Rurara",
                    Description = "echopunk book",
                    Count = 5,
                    AuthorId = 1,
                    GenreId = 1,
                    PublisherId = 1,
                },
                new Book
                {
                    Id = 5,
                    Title = "Sus's lie",
                    Description = "romantic book",
                    Count = 12,
                    AuthorId = 2,
                    GenreId = 2,
                    PublisherId = 2,
                }
        };
    }
}
