using Messenger.App.Services;
using Messenger.Models;
using Messenger.Models.DTO;

namespace Messenger.App.ViewModels
{
    public class ChatVM
    {
        public readonly DataController DataController;
        public readonly ChatsManager ChatsManager;

        public ChatVM(DataController dataController, ChatsManager chatsManager)
        {
            DataController = dataController;
            ChatsManager = chatsManager;
        }

        public async Task<List<ChatClientDTO>> GetChatListItemsAsync()
        {
            var chats = await DataController.GetChatsForUserAsync(ChatsManager.CurrentUser.Id);

            if (chats.Count >= 0)
            {
                ChatsManager.SetCurrentChat(chats.First());
            }

            return chats;
        }

        public async Task<List<Message>> GetChatMessagesAsync()
        {
            var messages = await DataController.GetMessagesAsync(ChatsManager.CurrentChat.Id);

            return messages;
        }
    }
}
