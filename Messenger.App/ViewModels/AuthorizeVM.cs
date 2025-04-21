using Messenger.App.Services;
using Messenger.App.Services.Implementations;

namespace Messenger.App.ViewModels
{
    public class AuthorizeVM
    {
        public event EventHandler? OnOpenChatWindow;

        public readonly IAuthHandler DataController;
        public readonly IValidators Validators;
        public readonly ChatsManager ChatsManager;

        public AuthorizeVM(IAuthHandler dataController, IValidators validators, ChatsManager chatsManager)
        {
            DataController = dataController;
            Validators = validators;
            ChatsManager = chatsManager;
        }

        public void OpenChatWindow()
        {
            OnOpenChatWindow?.Invoke(this, EventArgs.Empty);
        }
    }
}
