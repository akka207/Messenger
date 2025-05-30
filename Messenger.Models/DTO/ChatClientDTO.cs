using System.ComponentModel;

namespace Messenger.Models.DTO
{
    public class ChatClientDTO : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int ReceiverUserId { get; set; }
        public UserListItemDTO ReceiverUser { get; set; }
        public DateTime LastUpdate { get; set; }

        private bool unread;
        public bool Unread
        {
            get => unread;
            set
            {
                if (unread != value)
                {
                    unread = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Unread)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
