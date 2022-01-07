using LibraryAPI.DTO;
using LibraryAPI.Models.Books;
using LibraryAPI.Repositories.DbRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        protected IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public BookDTO Create(BookDTO model)
        {
            var entity = new Book
            {
                Title = model.Title,
                Description = model.Description,
                ImagePath = model.ImagePath,
                CartId = null
            };

            _bookRepository.Create(entity);
            _bookRepository.Save();

            return new BookDTO(entity);
        }

        public async Task<BookDTO> Update(BookDTO model)
        {
            var entity = await _bookRepository.FindByIdAsync(model.Id);

            if (entity == null)
            {
                return null;
            }

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.ImagePath = model.ImagePath;

            _bookRepository.Update(entity);
            await _bookRepository.SaveAsync();

            return new BookDTO(entity);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public async Task<bool> Delete(Guid bookId)
        {
            var book = await _bookRepository.FindByIdAsync(bookId);
            if (book == null)
            {
                return false;
            }
            _bookRepository.Delete(book);

            return await _bookRepository.SaveAsync();
        }
    }
}
