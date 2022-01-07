using LibraryAPI.Models.Base;
using LibraryAPI.Models.Books;
using LibraryAPI.Models.Users;
using System;
using System.Collections.Generic;

namespace LibraryAPI.Models.Carts
{
    public class Cart : BaseEntity
    {
        public User User { get; set; }

        public Guid UserId { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}