using LibraryAPI.Models.Books;
using LibraryAPI.Repositories.Generic;
using System;
using System.Collections.Generic;

namespace LibraryAPI.Repositories.DbRepositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        List<Book> GetAllByAuthor(Guid authorId);
    }
}
