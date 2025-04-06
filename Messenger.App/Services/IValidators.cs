using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.App.Services
{
    public interface IValidators
    {
        List<string> ValidatePassword(string password);
    }
}
