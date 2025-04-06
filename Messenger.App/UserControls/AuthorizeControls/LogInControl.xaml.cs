using System.Windows.Controls;

namespace Messenger.App.UserControls.AuthorizeControls
{
    public partial class LogInControl : UserControl
    {
        public event EventHandler OnLogIn;
        public event EventHandler OnChangeMode;

        public LogInControl()
        {
            InitializeComponent();
        }

        private void Button_ChangeMode_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnChangeMode?.Invoke(sender, e);
        }

        private void Button_LogIn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnLogIn?.Invoke(sender, e);
        }
    }
}
