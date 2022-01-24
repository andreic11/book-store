using LibraryAPI.Data;
using LibraryAPI.Models.Carts;
using LibraryAPI.Repositories.Generic;
using System;
using System.Linq;

namespace LibraryAPI.Repositories.DbRepositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(LibraryAPIContext context) : base(context)
        {

        }

        public Cart GetByUserId(Guid userId)
        {
            return _table.FirstOrDefault(cart => cart.UserId.Equals(userId));
        }
    }
}