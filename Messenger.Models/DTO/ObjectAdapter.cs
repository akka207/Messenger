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

        public static UserListItemDTO UserTOUserListItem(User user)
        {
            return new UserListItemDTO()
            {
                Id = user.Id,
                Name = user.Name ?? string.Empty,
                Login = user.Login,
                LastOnline = user.LastOnline ?? DateTime.MinValue,
                PicturePath = user.PicturePath ?? string.Empty
            };
        }

        public static ChatClientDTO ChatTOChatClient(Chat chat, int userId)
        {
            return new ChatClientDTO()
            {
                Id = chat.Id,
                ReceiverUserId = chat.User1Id == userId ? chat.User2Id : chat.User1Id,
                ReceiverUser = UserTOUserListItem(chat.User1Id == userId ? chat.User2 : chat.User1),
                LastChange = chat.LastChange
            };
        }
    }
}
