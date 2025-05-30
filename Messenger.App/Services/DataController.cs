using Messenger.App.DTO;
using Messenger.Models;
using Messenger.Models.DTO;

namespace Messenger.App.Services
{
    public class DataController
    {
        private readonly APIRequest _apiRequest;

        public DataController(APIRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }

        public async Task<UserClientDTO?> LogInUserAsync(UserLogInDTO user)
        {
            return await _apiRequest.PostDataAsync<UserClientDTO>("auth/login", user);
        }

        public async Task<UserClientDTO?> SignUpUserAsync(UserSignUpDTO user)
        {
            return await _apiRequest.PostDataAsync<UserClientDTO>("auth/signup", user);
        }

        public async Task SendMessageAsync(Message message)
        {
            await _apiRequest.PostDataAsync("messages", message);
        }

        public async Task<List<Message>> GetMessagesAsync(int chatId)
        {
            return await _apiRequest.GetDataAsync<List<Message>>($"messages?chatId={chatId}") ?? new();
        }

        public async Task<List<ChatClientDTO>> GetChatsForUserAsync(int userId)
        {
            return await _apiRequest.GetDataAsync<List<ChatClientDTO>>($"chats/orderedList/{userId}") ?? new();
        }

        public async Task<DateTime> GetChatUpdateStatusAsync(int chatId)
        {
            return await _apiRequest.GetDataAsync<DateTime>($"chats/status?chatId={chatId}");
        }
    }
}
