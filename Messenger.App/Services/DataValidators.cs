namespace Messenger.App.Services
{
    public class DataValidators
    {
        public List<string> ValidatePassword(string password)
        {
            var errors = new List<string>();

            if (password.Length < 6)
            {
                errors.Add("Password must be at least 6 characters long.");
            }

            if (!password.Any(char.IsLetter))
            {
                errors.Add("Password must contain at least one letter.");
            }

            if (!password.Any(char.IsDigit))
            {
                errors.Add("Password must contain at least one number.");
            }

            return errors;
        }

        public List<string> ValidateLogin(string login)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(login))
            {
                errors.Add("Login cannot be empty.");
            }

            if (!login.All(c => char.IsLetter(c) || c == '_'))
            {
                errors.Add("Login can only contain letters and underscores.");
            }

            return errors;
        }

        public List<string> VerificatePasswords(string password, string passwordConfirmation)
        {
            var errors = new List<string>();

            if (password != passwordConfirmation)
            {
                errors.Add("Passwords do not match.");
            }

            return errors;
        }
    }
}
