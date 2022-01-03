using LibraryAPI.Data;
using LibraryAPI.Models.Users;
using LibraryAPI.Repositories.Generic;
using System.Linq;

namespace LibraryAPI.Repositories.DbRepositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(LibraryAPIContext context) : base(context)
        {

        }

        public User GetByUserName(string username)
        {
            return _table.FirstOrDefault(u => u.UserName.ToLower().Equals(username.ToLower()));
        }
    }
}
