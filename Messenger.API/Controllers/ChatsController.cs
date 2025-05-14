using Messenger.API.Data;
using Messenger.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Messenger.API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ChatsController : Controller
    {
        private readonly MessengerDBContext _context;
        public ChatsController(MessengerDBContext context)
        {
            _context = context;
        }

        [HttpGet("orderedList/{forUserId}")]
        public async Task<IEnumerable<ChatClientDTO>> OnGetUsersListAsync(int forUserId)
        {
            return await _context.Chats
                .Where(c => c.User1Id == forUserId || c.User2Id == forUserId)
                .OrderByDescending(c => c.LastChange)
                .Include(c => c.User1)
                .Include(c => c.User2)
                .Select(c => ObjectAdapter.ChatTOChatClient(c, forUserId))
                .ToListAsync();
        }
    }
}
