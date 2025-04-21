using Messenger.API.Data;
using Messenger.App.DTO;
using Messenger.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Messenger.API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class AuthController : ControllerBase
    {
        private readonly MessengerContext _context;
        public AuthController(MessengerContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<UserClientDTO?> OnLogInAsync([FromBody] UserLogInDTO userDTO)
        {
            Models.User? origin = await _context.Users.Where(u => u.Login == userDTO.Login).FirstOrDefaultAsync();

            if (origin == null)
            {
                // TODO About reporting that login check failed
            }
            else if (!BCrypt.Net.BCrypt.Verify(userDTO.Password, origin.HashedPassword))
            {
                // TODO About reporting that password is incorrect
            }
            else
            {
                return ObjectAdapter.UserTOUserClient(origin);
            }

            return null;
        }

        [HttpPost("signup")]
        public async Task<UserClientDTO?> OnSignUpAsync([FromBody] UserSignUpDTO userDTO)
        {
            var user = ObjectAdapter.UserSighUpTOUser(userDTO, BCrypt.Net.BCrypt.HashPassword);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return ObjectAdapter.UserTOUserClient(user);
        }
    }
}
