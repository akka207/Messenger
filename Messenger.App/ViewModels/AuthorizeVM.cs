using Messenger.App.Services;

namespace Messenger.App.ViewModels
{
    public class AuthorizeVM
    {
        public event EventHandler? OnOpenChatWindow;

        public readonly DataController DataController;
        public readonly DataValidators Validators;
        public readonly ChatsManager ChatsManager;

        public AuthorizeVM(DataController dataController, DataValidators validators, ChatsManager chatsManager)
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
