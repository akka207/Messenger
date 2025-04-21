namespace Messenger.Models
{
    public class MessageChunk
    {
        public List<Message>? Messages { get; set; }
        public int Count => Messages?.Count ?? 0;
        public readonly int Capacity;

        public MessageChunk(int capacity)
        {
            Capacity = capacity;
        }
    }
}
