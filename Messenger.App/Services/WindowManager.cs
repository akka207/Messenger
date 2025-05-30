using Messenger.App.ViewModels;
using Messenger.App.Windows;
using Messenger.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Messenger.App.Services
{
    public class WindowManager
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly AuthorizeVM _authorizeVM;
        private readonly ChatVM _chatVM;

        private Window? _currentWindow;

        public WindowManager(IServiceProvider serviceProvider, AuthorizeVM authorizeVM, ChatVM chatVM)
        {
            _serviceProvider = serviceProvider;
            _authorizeVM = authorizeVM;
            _chatVM = chatVM;
        }

        public void Startup()
        {
            // TODO Autoloading

            _authorizeVM.OnOpenChatWindow += _authorizeVM_OnOpenChatWindow;
            _chatVM.OnOpenAuthWindow += _chatVM_OnOpenAuthWindow;

            OpenAuthorizeWindow();
        }

        private void _chatVM_OnOpenAuthWindow(object? sender, EventArgs e)
        {
            OpenAuthorizeWindow();
        }

        private void _authorizeVM_OnOpenChatWindow(object? sender, EventArgs e)
        {
            OpenChatWindow();
        }

        public void OpenAuthorizeWindow()
        {
            var authWindow = _serviceProvider.GetRequiredService<AuthorizeWindow>();
            authWindow.Show();
            _currentWindow?.Close();
            _currentWindow = authWindow;
        }

        public void OpenChatWindow()
        {
            var chatWindow = _serviceProvider.GetRequiredService<ChatWindow>();
            chatWindow.Show();
            _currentWindow?.Close();
            _currentWindow = chatWindow;
        }
    }
}
