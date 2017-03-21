using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace JobManagement
{
    public class JobsCore
    {
        public JobsCore(string connectionString)
        {
            context = new JobsModel(connectionString);
            cs = connectionString;
        }

        private JobsModel context = null;
        private string cs;

        public List<string> GetJobs()
        {
            var jobs = context.Jobs.Where((job) => job.status > 0).Select((job) => job.guid);

            var res = jobs.ToList();

            return res;
        }

        public void FinishJob(string job)
        {
            context.Jobs.Where((t) => t.guid == job).ToList().ForEach(xx => xx.status = 0);
            context.SaveChanges();
        }

        public string SubmitJob(string type, IDictionary<string, string> parameters)
        {
            var job = new Job();
            job.guid = Guid.NewGuid().ToString();
            job.type = type;
            job.status = 1;
            job.data = SerializeParameters(parameters);

            context.Jobs.Add(job);

            context.SaveChanges();

            return job.guid;
        }

        public void DeleteOldJobs()
        {
            context.Jobs.RemoveRange(context.Jobs.Where(i => i.status == 0));
            context.SaveChanges();
        }

        public void ScheduleReport(string type, int duration)
        {
            using (var cn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand("sp_ScheduleReport", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@code", duration);

                cn.Open();
                cmd.ExecuteScalar();
            }

        }

        public void LogError(string error, string message)
        {
            try
            {
                using (var cn = new SqlConnection(cs))
                {
                    var cmd = new SqlCommand("sp_LogError", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@error", error);
                    cmd.Parameters.AddWithValue("@message", message);

                    cn.Open();
                    cmd.ExecuteScalar();
                }
            }
            catch { }
        }

        public bool GetJobDetails(string guid, out string type, out IDictionary<string, string> parameters)
        {
            var item = context.Jobs.Where(x => x.guid == guid).Select(i => new { i.type, i.data }).First();

            if (item == null)
            {
                type = null;
                parameters = null;
                return false;
            }

            type = item.type.Trim();
            parameters = DeserializeParameters(item.data);

            return true;
        }

        private static string SerializeParameters(IDictionary<string, string> values)
        {
            if (values == null || values.Count == 0)
                return string.Empty;

            var data = Newtonsoft.Json.JsonConvert.SerializeObject(values);

            return data;

            /* Manual serialization, replaced with JSON
            List<string> items = new List<string>();
            foreach (var i in values)
                items.Add(string.Concat(i.Key, "=", System.Net.WebUtility.UrlEncode(i.Value)));

            string data = string.Join("&", items);

            return data;
            */
        }

        public static IDictionary<string, string> DeserializeParameters(string value)
        {
            if (string.IsNullOrEmpty(value))
                return new Dictionary<string,string>();

            var res = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(value);

            return res;

            /* Manual serialization, replaced with JSON
            var values = value.Split('&');
            var res = new Dictionary<string,string>();

            foreach (string item in values)
            {
                var pair = item.Split('=');
                res[pair[0]] = System.Net.WebUtility.UrlDecode(pair[1]);
            }

            return res;
            */
        }
    }
}
