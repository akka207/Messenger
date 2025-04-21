using Messenger.App.DTO;
using Messenger.Models;
using Messenger.Models.DTO;

namespace Messenger.App.Services.Implementations
{
    public class DataController : IAuthHandler, IMessagesHandler
    {
        private readonly IAPIRequest _apiRequest;

        public DataController(IAPIRequest apiRequest)
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

        public async Task<List<Message>> GetMessagesAsync(Chat chat)
        {
            return await _apiRequest.GetDataAsync<List<Message>>($"messages/{chat.Id}") ?? new();
        }
    }
}
