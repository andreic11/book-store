using LibraryAPI.Models.Users;
using System;

namespace LibraryAPI.Utils.JWTUtils
{
    public interface IJWTUtils
    {
        public string GenerateJWTToken(User user);

        public Guid ValidateJWTToken(string token);
    }
}
