using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MiddleTier
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDevicesService" in both code and config file together.
    [ServiceContract(Name = "UserAccessService", Namespace = "http://appdynamics.com/Demo")]
    public interface IUserAccess
    {
        [OperationContract(Action = "ValidateAccess")]
        bool ValidateAccess(string userName, string userId);

        [OperationContract(Action = "Authenticate")]
        bool Authenticate(string userId, bool mobile, int provider);
    }

}
