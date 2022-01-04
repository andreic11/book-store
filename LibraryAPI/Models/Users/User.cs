using LibraryAPI.Models.Base;
using LibraryAPI.Models.Books;
using LibraryAPI.Models.Carts;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryAPI.Models.Users
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        public Role Role { get; set; }

        public Cart Cart { get; set; }

        public Author Author { get; set; }

        //public ICollection<BooksAuthors> BooksAuthors { get; set; }
    }
}