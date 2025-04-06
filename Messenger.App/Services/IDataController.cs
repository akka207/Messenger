using Messenger.App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.App.Services
{
    public interface IDataController
    {
        Task SignUpUserAsync(UserSignUpDTO user);
        Task LogInUserAsync(UserLogInDTO user);
    }
}
