using Messenger.App.DTO;

namespace Messenger.App.Services.Implementations
{
    public class DataController : IDataController
    {
        private readonly IAPIRequest _apiRequest;

        public DataController(IAPIRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }

        public async Task LogInUserAsync(UserLogInDTO user)
        {

        }

        public async Task SignUpUserAsync(UserSignUpDTO user)
        {
            await _apiRequest.PostDataAsync("signup", user);
        }
    }
}
