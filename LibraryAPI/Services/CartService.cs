using LibraryAPI.Models.Carts;
using LibraryAPI.Repositories.DbRepositories;
using System;
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
    }
}