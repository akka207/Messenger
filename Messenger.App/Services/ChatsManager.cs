using Messenger.Models;
using Messenger.Models.DTO;

namespace Messenger.App.Services
{
    public class ChatsManager
    {
        public ChatClientDTO CurrentChat { get; private set; } = new ChatClientDTO();
        public UserClientDTO CurrentUser { get; private set; }

        public void SetCurrentUser(UserClientDTO userClient)
        {
            CurrentUser = userClient;
        }

        public void SetCurrentChat(ChatClientDTO chat)
        {
            CurrentChat = chat;
        }

        public Message CreateMessage(string text)
        {
            return new Message()
            {
                UserId = CurrentUser.Id,
                ChatId = CurrentChat.Id,
                Text = text
            };
        }
    }
}
