using LibraryAPI.DTO;
using LibraryAPI.Models.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        BookDTO Create(BookDTO model);

        Task<BookDTO> Update(BookDTO model);

        IEnumerable<Book> GetAllBooks();

        Task<bool> Delete(Guid bookId);
    }
}
