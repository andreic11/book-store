using LibraryAPI.Models.Base;
using LibraryAPI.Models.Carts;
using System;
using System.Collections.Generic;

namespace LibraryAPI.Models.Books
{
    public class Book: BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public Cart Cart { get; set; }

        public Guid CartId { get; set; }

        public ICollection<BooksAuthors> BooksAuthors { get; set; }
    }
}
