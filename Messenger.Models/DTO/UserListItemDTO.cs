using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models.DTO
{
    public class UserListItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public DateTime LastOnline { get; set; }
        public string PicturePath { get; set; }
    }
}
