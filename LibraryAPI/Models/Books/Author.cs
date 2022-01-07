using LibraryAPI.Models.Base;
using LibraryAPI.Models.Users;
using System;
using System.Collections.Generic;

namespace LibraryAPI.Models.Books
{
    public class Author : BaseEntity
    {
        public User User { get; set; }

        public Guid UserId { get; set; }

        public ICollection<BooksAuthors> BooksAuthors { get; set; }
    }
}
