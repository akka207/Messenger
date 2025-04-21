using Messenger.API.Data;
using Messenger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class MessagesController : ControllerBase
    {
        private readonly MessengerContext _context;
        public MessagesController(MessengerContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> OnMessageAsync([FromBody] Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
