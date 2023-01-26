using DigitalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Service
{
    interface IUserService
    {
        [OperationContract]
        UserData DoValidate(UserData.UserLogs userLogs);
    }
}
