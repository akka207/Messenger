using Messenger.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.App.ViewModels
{
    public class AuthorizeVM
    {
        public readonly IDataController DataController;
        public readonly IValidators Validators;

        public AuthorizeVM(IDataController dataController, IValidators validators)
        {
            DataController = dataController;
            Validators = validators;
        }
    }
}
