using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public string Text { get; set; }
        public DateTime SentTime { get; set; }

        [NotMapped]
        public bool BelongCurrentUser { get; set; }
    }
}
