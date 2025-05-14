using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models.DTO
{
    public class ChatClientDTO
    {
        public int Id { get; set; }
        public int ReceiverUserId { get; set; }
        public UserListItemDTO ReceiverUser { get; set; }
        public DateTime LastChange { get; set; }
    }
}
