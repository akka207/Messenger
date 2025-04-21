using Messenger.App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models.DTO
{
    public class ObjectAdapter
    {
        public static User UserSighUpTOUser(UserSignUpDTO user, Func<string, string> passwordHasher)
        {
            return new User()
            {
                Name = user.Name,
                Login = user.Login,
                HashedPassword = passwordHasher(user.Password)
            };
        }

        public static User UserLogInTOUser(UserLogInDTO user, Func<string, string> passwordHasher)
        {
            return new User()
            {
                Login = user.Login,
                HashedPassword = passwordHasher(user.Password)
            };
        }

        public static UserClientDTO UserTOUserClient(User user)
        {
            return new UserClientDTO() 
            { 
                Id = user.Id,
                Name = user.Name ?? string.Empty,
                Login = user.Login,
                HashedPassword = user.HashedPassword,
                PicturePath = user.PicturePath ?? string.Empty
            };
        }
    }
}
