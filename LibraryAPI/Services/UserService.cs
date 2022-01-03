using LibraryAPI.DTO;
using LibraryAPI.Models.Users;
using LibraryAPI.Repositories.DbRepositories;
using LibraryAPI.Utils;
using LibraryAPI.Utils.JWTUtils;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class UserService : IUserService
    {
        protected IUserRepository _userRepository;
        private IJWTUtils _jWTUtils;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IJWTUtils jWTUtils, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _jWTUtils = jWTUtils;
            _appSettings = appSettings.Value;
        }

        public UserResponseDTO Create(UserRequestDTO model)
        {
            var user = _userRepository.GetByUserName(model.UserName);
            if(user != null)
            {
                throw new ArgumentException("Username already exists", model.UserName);
            }

            var entity = new User
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Role = Role.User,
                PasswordHash = BCryptNet.HashPassword(model.Password)
            };

            _userRepository.Create(entity);
            _userRepository.Save();

            return new UserResponseDTO(entity, null);
        }

        public async Task<UserResponseDTO> Update(UserRequestDTO model)
        {
            var entity = await _userRepository.FindByIdAsync(model.Id);

            if (entity == null)
            {
                return null;
            }

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.PasswordHash = BCryptNet.HashPassword(model.Password);
            entity.Email = model.Email;

            _userRepository.Update(entity);
            await _userRepository.SaveAsync();

            return new UserResponseDTO(entity, null);
        }

        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user = _userRepository.GetByUserName(model.UserName);

            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }

            var jwtToken = _jWTUtils.GenerateJWTToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }

        public async Task<bool> Delete(Guid userId)
        {
            var user = await _userRepository.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }
            _userRepository.Delete(user);

            return await _userRepository.SaveAsync();
        }
    }
}
