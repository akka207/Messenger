using Messenger.App.Services.Implementations;
using Messenger.App.ViewModels;
using System.Windows;

namespace Messenger.App
{
    public partial class AuthorizeWindow : Window
    {
        public AuthorizeWindow(AuthorizeVM authorizeVM)
        {
            InitializeComponent();
            DataContext = authorizeVM;
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
            await (DataContext as AuthorizeVM)!.DataController.LogInUserAsync(new DTO.UserLogInDTO
            {
                Login = logInControl.loginTextBox.Text,
                Password = logInControl.passwordTextBox.Text
            });
        }

        private async void signUpControl_OnSignUp(object sender, EventArgs e)
        {
            string password = signUpControl.passwordTextBox.Text;
            List<string> validationErrors = (DataContext as AuthorizeVM)!.Validators.ValidatePassword(password);

            if (validationErrors.Count == 0)
            {
                await (DataContext as AuthorizeVM)!.DataController.SignUpUserAsync(new DTO.UserSignUpDTO
                {
                    Name = signUpControl.nameTextBox.Text,
                    Login = signUpControl.loginTextBox.Text,
                    Password = password
                });
            }
            else
            {
                // TODO
            }
        }
    }
}
