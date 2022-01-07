using LibraryAPI.Models.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models.Books
{
    public class BooksAuthors
    {
        public Guid BookId { get; set; }

        public Book Book { get; set; }

        public Guid AuthorId { get; set; }

        public User Author { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CreatedAt { get; set; }
    }
}
