using LibraryAPI.Models.Carts;
using System;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface ICartService
    {
        Cart Create(Guid userId);

        Task<bool> AddItem(Guid userId, Guid itemId);
    }
}
