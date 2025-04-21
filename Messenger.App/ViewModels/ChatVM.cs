using Messenger.App.Services;
using Messenger.App.Services.Implementations;

namespace Messenger.App.ViewModels
{
    public class ChatVM
    {
        public readonly IMessagesHandler MessagesHandler;
        public readonly ChatsManager ChatsManager;

        public ChatVM(IMessagesHandler messageshandler, ChatsManager chatsManager)
        {
            MessagesHandler = messageshandler;
            ChatsManager = chatsManager;
        }
    }
}
