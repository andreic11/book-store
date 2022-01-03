using LibraryAPI.DTO;
using LibraryAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface IUserService
    {
        UserResponseDTO Create(UserRequestDTO model);

        Task<UserResponseDTO> Update(UserRequestDTO model);

        UserResponseDTO Authenticate(UserRequestDTO model);

        IEnumerable<User> GetAllUsers();

        User GetById(Guid id);

        Task<bool> Delete(Guid userId);
    }
}
