using Messenger.App.ViewModels;
using System.Windows;

namespace Messenger.App.Windows
{
    public partial class AuthorizeWindow : Window
    {
        private AuthorizeVM viewModel;

        public AuthorizeWindow()
        {
            InitializeComponent();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = (DataContext as AuthorizeVM)!;
        }

        private void logInControl_OnChangeMode(object sender, EventArgs e)
        {
            logInControl.Visibility = Visibility.Hidden;
            signUpControl.Visibility = Visibility.Visible;
        }

        private void signUpControl_OnChangeMode(object sender, EventArgs e)
        {
            logInControl.Visibility = Visibility.Visible;
            signUpControl.Visibility = Visibility.Hidden;
        }

        private async void logInControl_OnLogIn(object sender, EventArgs e)
        {
            var user = await viewModel.DataController.LogInUserAsync(new DTO.UserLogInDTO
            {
                Login = logInControl.loginTextBox.Text,
                Password = logInControl.passwordTextBox.Text
            });

            if (user == null)
            {
                // TODO Check login progress
            }
            else
            {
                viewModel.ChatsManager.SetCurrentUser(user);
                viewModel.OpenChatWindow();
            }
        }

        private async void signUpControl_OnSignUp(object sender, EventArgs e)
        {
            string password = signUpControl.passwordTextBox.Text;
            List<string> validationErrors = viewModel.Validators.ValidatePassword(password);

            if (validationErrors.Count == 0)
            {
                var user = await viewModel.DataController.SignUpUserAsync(new DTO.UserSignUpDTO
                {
                    Name = signUpControl.nameTextBox.Text,
                    Login = signUpControl.loginTextBox.Text,
                    Password = password
                });

                // TODO Check signup progress

                if (user == null)
                {
                    // TODO Check login progress
                }
                else
                {
                    viewModel.ChatsManager.SetCurrentUser(user);
                    viewModel.OpenChatWindow();
                }
            }
            else
            {
                // TODO Validation
            }
        }
    }
}
