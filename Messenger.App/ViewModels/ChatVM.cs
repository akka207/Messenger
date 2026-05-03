using Messenger.App.Services;
using Messenger.Models;
using Messenger.Models.DTO;

namespace Messenger.App.ViewModels
{
    public class ChatVM
    {
        public event EventHandler? OnOpenAuthWindow;

        public readonly DataController DataController;
        public readonly ChatsManager ChatsManager;

        public ChatVM(DataController dataController, ChatsManager chatsManager)
        {
            DataController = dataController;
            ChatsManager = chatsManager;
        }


        public void OpenAuthWindow()
        {
            OnOpenAuthWindow?.Invoke(this, EventArgs.Empty);
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

        public async Task<bool> ChatHasNewMessages(ChatClientDTO chat)
        {
            var updatedChatStatus = await DataController.GetChatUpdateStatusAsync(chat.Id);

            if (updatedChatStatus > chat.LastUpdate)
            {
                chat.LastUpdate = updatedChatStatus;
                return true;
            }

            return false;
        }

        public async Task<bool> CheckAndUpdateChatsAsync(IEnumerable<ChatClientDTO> currentChats)
        {
            bool needChatReloads = false;
            if (currentChats != null)
            {
                foreach (var chat in currentChats)
                {
                    if (await ChatHasNewMessages(chat) && chat.Id != ChatsManager.CurrentChat?.Id)
                    {
                        needChatReloads = true;
                        chat.Unread = true;
                    }
                }
            }
            return needChatReloads;
        }
    }
}
