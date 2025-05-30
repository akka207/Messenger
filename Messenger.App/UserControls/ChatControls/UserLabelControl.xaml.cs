using Messenger.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Messenger.App.UserControls.ChatControls
{
    public partial class UserLabelControl : UserControl
    {
        public ChatClientDTO Chat
        {
            get { return (ChatClientDTO)GetValue(ChatProperty); }
            set { SetValue(ChatProperty, value); }
        }
        public static readonly DependencyProperty ChatProperty =
            DependencyProperty.Register("Chat", typeof(ChatClientDTO), typeof(UserLabelControl), new UIPropertyMetadata(null));

        public event EventHandler<ChatClientDTO>? OnClick;

        public UserLabelControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnClick?.Invoke(this, Chat);
        }
    }
}
