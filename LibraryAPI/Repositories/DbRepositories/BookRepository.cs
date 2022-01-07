using LibraryAPI.Data;
using LibraryAPI.Models.Books;
using LibraryAPI.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Repositories.DbRepositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryAPIContext context) : base(context)
        {

        }

        public Book GetByTitle(string title)
        {
            return _table.FirstOrDefault(b => b.Title.ToLower().Equals(title.ToLower()));
        }
    }
}
