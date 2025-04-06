using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.App.Services
{
    public interface IAPIRequest
    {
        Task<T> GetDataAsync<T>(string endpoint);
        Task PostDataAsync(string endpoint, object data);
    }
}
