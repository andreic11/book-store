using LibraryAPI.DTO;
using LibraryAPI.Models.Books;
using LibraryAPI.Models.Carts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface ICartService
    {
        Cart Create(Guid userId);

        Task<bool> AddItem(Guid userId, Guid itemId);

        Task<bool> RemoveItem(Guid itemId);

        List<BookDTO> GetCartItems(Guid userId);
    }
}
