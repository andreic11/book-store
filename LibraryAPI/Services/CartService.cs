using LibraryAPI.DTO;
using LibraryAPI.Models.Books;
using LibraryAPI.Models.Carts;
using LibraryAPI.Repositories.DbRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class CartService : ICartService
    {
        protected ICartRepository _cartRepository;
        protected IBookRepository _bookRepository;

        public CartService(ICartRepository cartRepository, IBookRepository bookRepository)
        {
            _cartRepository = cartRepository;
            _bookRepository = bookRepository;
        }

        public Cart Create(Guid userId)
        {
            var cart = new Cart
            {
                UserId = userId,
            };

            _cartRepository.Create(cart);
            _cartRepository.Save();

            return cart;
        }

        public async Task<bool> AddItem(Guid userId, Guid itemId)
        {
            var cart = _cartRepository.GetByUserId(userId);
            var book = await _bookRepository.FindByIdAsync(itemId);
            if (cart == null || book == null)
            {
                return false;
            }
            book.CartId = cart.Id;

            _bookRepository.Update(book);
            await _bookRepository.SaveAsync();

            return true;
        }

        public async Task<bool> RemoveItem(Guid itemId)
        {
            var book = await _bookRepository.FindByIdAsync(itemId);
            if (book == null)
            {
                return false;
            }
            book.CartId = null;

            _bookRepository.Update(book);
            await _bookRepository.SaveAsync();

            return true;
        }

        public List<BookDTO> GetCartItems(Guid userId)
        {
            var cart = _cartRepository.GetByUserId(userId);
            if(cart == null)
            {
                return null;
            }
            var books = _bookRepository.GetAllByCart(cart.Id)
                .ConvertAll(new Converter<Book, BookDTO>( (b)=>new BookDTO(b) ));

            return books;
        }
    }
}