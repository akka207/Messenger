using Messenger.App.DTO;
using Messenger.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.App.Services
{
    public interface IAuthHandler
    {
        Task<UserClientDTO?> LogInUserAsync(UserLogInDTO user);
        Task<UserClientDTO?> SignUpUserAsync(UserSignUpDTO user);
    }
}
