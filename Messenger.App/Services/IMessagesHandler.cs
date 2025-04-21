using Messenger.Models;

namespace Messenger.App.Services
{
    public interface IMessagesHandler
    {
        Task SendMessageAsync(Message message);
        Task<List<Message>> GetMessagesAsync(Chat chat);
    }
}
