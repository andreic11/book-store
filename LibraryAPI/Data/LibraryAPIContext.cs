using LibraryAPI.Models.Users;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using System;
using LibraryAPI.Models.Carts;
using LibraryAPI.Models.Books;

namespace LibraryAPI.Data
{
    public class LibraryAPIContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BooksAuthors> BooksAuthors { get; set; }

        public LibraryAPIContext(DbContextOptions<LibraryAPIContext>options) : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Insert Admin data
            builder.Entity<User>()
                .HasData( 
                    new { Id = Guid.NewGuid(), 
                        UserName = "admin", 
                        PasswordHash = BCryptNet.HashPassword("admin"),
                        Role = Role.Admin,
                        FirstName = "Admin", 
                        LastName = "Admin",
                        Email = "admin@gmail.com"
                    });

            //one to one
            builder.Entity<User>()
                .HasOne(user => user.Cart)
                .WithOne(cart => cart.User)
                .HasForeignKey<Cart>(cart => cart.UserId);

            //One to Many
            builder.Entity<Cart>()
                .HasMany(cart => cart.Books)
                .WithOne(book => book.Cart);

            builder.Entity<Book>()
                .HasOne(book => book.Cart)
                .WithMany(cart => cart.Books);

            //Many to Many
            builder.Entity<BooksAuthors>().HasKey(ba => new { ba.BookId, ba.AuthorId });

            builder.Entity<BooksAuthors>()
                .HasOne<Book>(ba => ba.Book)
                .WithMany(book => book.BooksAuthors)
                .HasForeignKey(ba => ba.BookId);

            builder.Entity<BooksAuthors>()
                .HasOne<User>(ba => ba.Author)
                .WithMany(ba => ba.BooksAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            base.OnModelCreating(builder);
        }

    }
}
