using LibraryAPI.Models.Users;
using LibraryAPI.Repositories.Generic;

namespace LibraryAPI.Repositories.DbRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUserName(string username);
    }
}
