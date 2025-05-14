using Messenger.App.ViewModels;
using Messenger.Models;
using Messenger.Models.DTO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Messenger.App.Windows
{
    public partial class ChatWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<ChatClientDTO> chats;
        public ObservableCollection<ChatClientDTO> Chats
        {
            get => chats;
            set
            {
                chats = value;
                OnPropertyChanged(nameof(Chats));
            }
        }


        private ObservableCollection<Message> messages;
        public ObservableCollection<Message> Messages
        {
            get => messages;
            set
            {
                messages = value;
                OnPropertyChanged(nameof(Messages));
            }
        }

        private readonly ChatVM viewModel;

        public ChatWindow(ChatVM chatVM)
        {
            InitializeComponent();
            viewModel = chatVM;
        }

        private async void window_Loaded(object sender, RoutedEventArgs e)
        {
            Chats = new(await viewModel.GetChatListItemsAsync());
            Messages = new(await viewModel.GetChatMessagesAsync());
            currentUserLabel.UserName = viewModel.ChatsManager.CurrentChat.ReceiverUser.Name;
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string text = messageTextBox.Text;
            await viewModel.DataController.SendMessageAsync(viewModel.ChatsManager.CreateMessage(text));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
