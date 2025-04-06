using Messenger.API.Data;
using Messenger.App.DTO;
using Messenger.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class UsersController : ControllerBase
    {
        private readonly MessengerContext _context;
        public UsersController(MessengerContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> OnLogInAsync([FromBody] UserLogInDTO userDTO)
        {
            return Ok();
        }

        [HttpPost("signup")]
        public async Task<IActionResult> OnSignUpAsync([FromBody] UserSignUpDTO userDTO)
        {
            Console.WriteLine("hello");
            var user = ObjectAdapter.UserSighUpTOUser(userDTO, BCrypt.Net.BCrypt.HashPassword);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
