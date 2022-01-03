using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTO
{
    public class UserRequestDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
