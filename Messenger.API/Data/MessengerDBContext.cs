using Messenger.Models;
using Microsoft.EntityFrameworkCore;

namespace Messenger.API.Data
{
    public class MessengerDBContext:DbContext
    {
        public MessengerDBContext(DbContextOptions<MessengerDBContext> options) : base(options) { }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
