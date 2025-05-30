using Messenger.App.ViewModels;
using Messenger.Models;
using Messenger.Models.DTO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Messenger.App.Windows
{
    public partial class ChatWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<ChatClientDTO> chats;

        public ObservableCollection<ChatClientDTO> FiltredChats
        {
            get => GetFiltredChats();
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

        private DispatcherTimer messageCheckTimer;

        public ChatWindow(ChatVM chatVM)
        {
            InitializeComponent();
            viewModel = chatVM;
            messageCheckTimer = new DispatcherTimer();
        }

        private async void window_Loaded(object sender, RoutedEventArgs e)
        {
            await UpdateChatsList();
            SetCurrentChat(viewModel.ChatsManager.CurrentChat);
            OnPropertyChanged(nameof(FiltredChats));

            messageCheckTimer.Interval = TimeSpan.FromSeconds(1);
            messageCheckTimer.Tick += MessageCheckTimer_Tick;
            messageCheckTimer.Start();
        }

        private async void MessageCheckTimer_Tick(object sender, EventArgs e)
        {
            bool needChatReloads = false;
            if (chats != null)
            {
                foreach (var chat in chats)
                {
                    if (await viewModel.ChatHasNewMessages(chat) && chat.Id != viewModel.ChatsManager.CurrentChat.Id)
                    {
                        needChatReloads = true;
                        chat.Unread = true;
                    }
                }
                if (needChatReloads)
                {
                    await UpdateChatsList();
                }
            }

            await LoadMessages();
        }

        private async void sendButton_Click(object sender, RoutedEventArgs e)
        {
            string text = messageTextBox.Text;
            var message = viewModel.ChatsManager.CreateMessage(text);
            await viewModel.DataController.SendMessageAsync(message);
            messageTextBox.Text = string.Empty;
            messageTextBox.Focus();
        }

        private void UserLabelControl_OnClick(object sender, ChatClientDTO e)
        {
            SetCurrentChat(e);
        }

        private void messageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                sendButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private void chatsFilterTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            OnPropertyChanged(nameof(FiltredChats));
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.OpenAuthWindow();
        }
        private void ControlBox_OnDrag(object sender, EventArgs e)
        {
            DragMove();
        }

        private void ControlBox_OnClose(object sender, EventArgs e)
        {
            Close();
        }

        private void ControlBox_OnMinimize(object sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private ObservableCollection<ChatClientDTO> GetFiltredChats()
        {
            string filterText = chatsFilterTextBox.Text;
            if (filterText.Length > 0)
            {
                var filtredChats = chats.Where(c => c.ReceiverUser.Name.ToLower().Contains(filterText.ToLower()));

                if (filtredChats.Count() == 0)
                {
                    noChatsTextBlock.Visibility = Visibility.Visible;
                }
                else
                {
                    noChatsTextBlock.Visibility = Visibility.Collapsed;
                }

                return new(filtredChats);
            }
            else
            {
                noChatsTextBlock.Visibility = Visibility.Collapsed;
                return chats;
            }
        }

        private async Task LoadMessages()
        {
            var messages = await viewModel.GetChatMessagesAsync();
            if (Messages == null || messages.Count != Messages.Count)
            {
                messages.ForEach(m => m.BelongCurrentUser = m.UserId == viewModel.ChatsManager.CurrentUser.Id);
                Messages = new(messages);

                messagesScrollViewer?.ScrollToEnd();
            }
        }

        private async void SetCurrentChat(ChatClientDTO chat)
        {
            viewModel.ChatsManager.SetCurrentChat(chat);
            await LoadMessages();
            currentUserLabel.Chat = chat;

            if (Messages.Count == 0)
            {
                noMessagesTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                noMessagesTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private async Task UpdateChatsList()
        {
            var currentChatId = viewModel.ChatsManager.CurrentChat?.Id;

            List<ChatClientDTO> newChats = new(await viewModel.GetChatListItemsAsync());

            foreach (var chat in newChats)
            {
                if (chats != null && chats.Single(c => c.Id == chat.Id).Unread)
                {
                    chat.Unread = true;
                }
            }
            chats = new(newChats);

            if (currentChatId != null)
            {
                var restoredChat = chats.FirstOrDefault(c => c.Id == currentChatId);
                if (restoredChat != null)
                {
                    viewModel.ChatsManager.SetCurrentChat(restoredChat);
                }
            }

            OnPropertyChanged(nameof(FiltredChats));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
