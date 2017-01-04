using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RemoteWcfSvc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IScheduleService" in both code and config file together.
    [ServiceContract]
    public interface IScheduleService
    {
        [OperationContract]
        List<string> GetJobs();

        [OperationContract]
        string ScheduleJob(string type, IDictionary<string, string> values);
    }
}
