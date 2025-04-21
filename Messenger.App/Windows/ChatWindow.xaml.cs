using Messenger.App.ViewModels;
using Messenger.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Messenger.App.Windows
{
    public partial class ChatWindow : Window
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>()
        {
            new User() { Name = "Derek" },
            new User() { Name = "Anna" },
            new User() { Name = "David" },
            new User() { Name = "Oleh" },
            new User() { Name = "Derek" },
            new User() { Name = "Anna" },
            new User() { Name = "David" },
            new User() { Name = "Oleh" },
            new User() { Name = "Derek" },
            new User() { Name = "Anna" },
            new User() { Name = "David" },
            new User() { Name = "Oleh" }
        };

        private ChatVM viewModel;

        public ChatWindow()
        {
            InitializeComponent();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = (DataContext as ChatVM)!;
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string text = messageTextBox.Text;
            await viewModel.MessagesHandler.SendMessageAsync(viewModel.ChatsManager.CreateMessage(text));
        }
    }
}
