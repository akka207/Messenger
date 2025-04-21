using Messenger.Models;
using Messenger.Models.DTO;

namespace Messenger.App.Services.Implementations
{
    public class ChatsManager
    {
        private const int ChatMessagesChunkCapacity = 15;
        private const int LoadedChunksLimit = 4;

        public Chat CurrentChat { get; private set; } = new Chat() { Id = 1, User1Id = 1, User2Id = 2 };
        public UserClientDTO CurrentUser { get; private set; }

        public void SetCurrentUser(UserClientDTO userClient)
        {
            CurrentUser = userClient;
        }

        public Message CreateMessage(string text)
        {
            return new Message()
            {
                UserId = CurrentUser.Id,
                ChatId = CurrentChat.Id,
                Text = text,
                SentTime = DateTime.UtcNow
            };
        }
    }
}
