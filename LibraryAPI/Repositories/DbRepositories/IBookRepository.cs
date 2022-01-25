using LibraryAPI.Models.Books;
using LibraryAPI.Repositories.Generic;
using System;
using System.Collections.Generic;

namespace LibraryAPI.Repositories.DbRepositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Book GetByTitle(string title);

        List<Book> GetAllByCart(Guid cartId);
    }
}
