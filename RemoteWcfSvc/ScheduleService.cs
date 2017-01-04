using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace RemoteWcfSvc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ScheduleService" in both code and config file together.
    public class ScheduleService : IScheduleService
    {

        public List<string> GetJobs()
        {
            var jobs = new JobManagement.JobsCore(ConfigurationManager.AppSettings["database"]);

            // Run the logic in a separate thread asynchronously, kind of example of the bad code pattern
            var t = Task.Run(() => jobs.GetJobs());

            return t.Result;
        }


        public string ScheduleJob(string type, IDictionary<string, string> values)
        {
            var jobs = new JobManagement.JobsCore(ConfigurationManager.AppSettings["database"]);

            var t = Task.Run(() => jobs.SubmitJob(type, values));

            return t.Result;
        }
    }
}
