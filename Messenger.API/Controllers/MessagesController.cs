using Messenger.API.Data;
using Messenger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Messenger.API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class MessagesController : ControllerBase
    {
        private readonly MessengerDBContext _context;
        public MessagesController(MessengerDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostMessageAsync([FromBody] Message message)
        {
            _context.Chats
                .Where(c => c.Id == message.ChatId)
                .Single()
                .LastChange = DateTime.UtcNow;
            message.SentTime = DateTime.UtcNow;
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<List<Message>> OnGetMessagesAsync([FromQuery]int chatId)
        {
            return await _context.Messages
                .Where(m => m.ChatId == chatId)
                .OrderBy(m => m.SentTime)
                .ToListAsync();
        }
    }
}
