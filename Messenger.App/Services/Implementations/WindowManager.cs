using Messenger.App.ViewModels;
using Messenger.App.Windows;
using Messenger.Models;
using System.Windows;

namespace Messenger.App.Services.Implementations
{
    public class WindowManager
    {
        private readonly AuthorizeWindow _authorizeWindow;
        private readonly ChatWindow _chatWindow;

        private readonly AuthorizeVM _authorizeVM;
        private readonly ChatVM _chatVM;

        private Window? CurrentWindow;

        public WindowManager(AuthorizeWindow authorizeWindow, ChatWindow chatWindow, AuthorizeVM authorizeVM, ChatVM chatVM)
        {
            _authorizeWindow = authorizeWindow;
            _chatWindow = chatWindow;
            _authorizeVM = authorizeVM;
            _chatVM = chatVM;
        }

        public void Startup()
        {
            // TODO Autoloading

            _authorizeVM.OnOpenChatWindow += _authorizeVM_OnOpenChatWindow;

            _authorizeWindow.DataContext = _authorizeVM;
            _chatWindow.DataContext = _chatVM;

            OpenAuthorizeWindow();
        }

        private void _authorizeVM_OnOpenChatWindow(object? sender, EventArgs e)
        {
            OpenChatWindow();
        }

        public void OpenAuthorizeWindow()
        {
            CurrentWindow?.Close();
            _authorizeWindow.Show();
            CurrentWindow = _authorizeWindow;
        }

        public void OpenChatWindow()
        {
            CurrentWindow?.Close();
            _chatWindow.Show();
            CurrentWindow = _chatWindow;
        }
    }
}
