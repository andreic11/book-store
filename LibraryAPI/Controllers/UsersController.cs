using LibraryAPI.DTO;
using LibraryAPI.Models.Users;
using LibraryAPI.Services;
using LibraryAPI.Utils.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authentificate")]
        public IActionResult Authentificate(UserRequestDTO user)
        {
            var response = _userService.Authenticate(user);

            if (response == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid!" });
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create(UserRequestDTO user)
        {
            var response = _userService.Create(user);

            return Ok(response);
        }

        // PUT: api/Users/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UserRequestDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            var response = await _userService.Update(user);
            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [Authorization(Role.Admin)]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        // DELETE: api/Users/Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
    }
}
