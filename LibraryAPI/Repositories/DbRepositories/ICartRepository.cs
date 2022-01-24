using LibraryAPI.Models.Carts;
using LibraryAPI.Repositories.Generic;
using System;

namespace LibraryAPI.Repositories.DbRepositories
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Cart GetByUserId(Guid userId);
    }
}
