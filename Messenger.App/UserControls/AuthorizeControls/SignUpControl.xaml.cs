using System.Windows.Controls;

namespace Messenger.App.UserControls.AuthorizeControls
{
    public partial class SignUpControl : UserControl
    {
        public event EventHandler OnSignUp;
        public event EventHandler OnChangeMode;

        public SignUpControl()
        {
            InitializeComponent();
        }

        private void Button_ChangeMode_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnChangeMode?.Invoke(sender, e);
        }

        private void Button_SignUp_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnSignUp?.Invoke(sender, e);
        }
    }
}
