using Messenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.App.Services
{
    public interface IMessageChunkLoader
    {
        Task<MessageChunk> GetMessageChunkAsync(Chat chat, int chunkNumber);
    }
}
