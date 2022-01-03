using LibraryAPI.Models.Users;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using System;

namespace LibraryAPI.Data
{
    public class LibraryAPIContext : DbContext
    {
        public DbSet<User> Users { get; set; }

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

            base.OnModelCreating(builder);
        }

    }
}
