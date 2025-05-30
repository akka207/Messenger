using Messenger.App.ViewModels;
using System.Text;
using System.Windows;

namespace Messenger.App.Windows
{
    public partial class AuthorizeWindow : Window
    {
        private readonly AuthorizeVM viewModel;

        public AuthorizeWindow(AuthorizeVM authorizeVM)
        {
            InitializeComponent();
            viewModel = authorizeVM;
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
                MessageBox.Show("Invalid login or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            string passwordConfirm = signUpControl.passwordConfirmTextBox.Text;
            string login = signUpControl.loginTextBox.Text;

            List<string> validationErrors = new();
            validationErrors.AddRange(viewModel.Validators.ValidatePassword(password));
            validationErrors.AddRange(viewModel.Validators.VerificatePasswords(password, passwordConfirm));
            validationErrors.AddRange(viewModel.Validators.ValidateLogin(login));

            if (validationErrors.Count == 0)
            {
                var user = await viewModel.DataController.SignUpUserAsync(new DTO.UserSignUpDTO
                {
                    Name = signUpControl.nameTextBox.Text,
                    Login = signUpControl.loginTextBox.Text,
                    Password = password
                });

                if (user == null)
                {
                    MessageBox.Show("Signing up was unsuccessful (posibly server error)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    viewModel.ChatsManager.SetCurrentUser(user);
                    viewModel.OpenChatWindow();
                }
            }
            else
            {
                StringBuilder stringBuilder = new();
                stringBuilder.Append("There some validation errors:\n ");
                stringBuilder.AppendJoin("\n ", validationErrors);

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
    }
}
