using LibraryAPI.Models.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryAPI.DTO
{
    public class BookDTO
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid? CartId { get; set; }

        public string ImagePath { get; set; }

        [JsonIgnore]
        public List<Guid> Authors { get; set; }

        public BookDTO()
        {
        }

        public BookDTO(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Description = book.Description;
            ImagePath = book.ImagePath;
        }
    }
}
