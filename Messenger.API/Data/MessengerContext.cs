using Messenger.Models;
using Microsoft.EntityFrameworkCore;

namespace Messenger.API.Data
{
    public class MessengerContext:DbContext
    {
        public MessengerContext(DbContextOptions<MessengerContext> options) : base(options) { }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
