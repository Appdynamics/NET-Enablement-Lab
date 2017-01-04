using System.Threading;
using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;

namespace JobProcessor
{
    class JobCore
    {
        private bool running = false;
        private Task task = null;

        public void Start()
        {
            running = true;
            task = Task.Run(() => Loop());
        }

        public void Stop()
        {
            running = false;
            if (task != null)
                task.Wait();
        }

        private void Loop()
        {
#if DEBUG
            Thread.Sleep(TimeSpan.FromMinutes(1));
#endif

            int count = 0;

            while(running)
            {
                try
                {

                    var logic = new JobManagement.JobsCore(ConfigurationManager.AppSettings["database"]);
                    var jobs = logic.GetJobs();

                    foreach (var job in jobs)
                    {
                        string type;
                        IDictionary<string, string> parameters;
                        logic.GetJobDetails(job, out type, out parameters);

                        ProcessJob(type, parameters);

                        count++;

                        // Mark this job as complete asynchronously
                        logic.FinishJob(job);

                        if (!running)
                            break;
                    }

                    if (jobs.Count == 0)
                        Thread.Sleep(500);

                    // Delete old jobs periodically
                    if (count > 100)
                    {
                        count = 0;

                        // Delete olbs jobs asynchronously
                        logic.DeleteOldJobs();
                    }
                }
                catch(Exception ex)
                {
                    System.Diagnostics.EventLog.WriteEntry("JobProcessor", ex.ToString());
                }
            }
        }

        private void ProcessJob(string type, IDictionary<string, string> parameters)
        {
            try
            {

                int duration = 22;

                if (parameters.ContainsKey("duration"))
                {
                    int.TryParse(parameters["duration"], out duration);
                }

                duration += new Random().Next(duration / 8);

                if (type.Equals("ondemandreport", StringComparison.InvariantCultureIgnoreCase))
                {
                    duration += int.Parse(parameters["offset"]);
                }

                var logic = new JobManagement.JobsCore(ConfigurationManager.AppSettings["database"]);
                logic.ScheduleReport(type, duration);
            }
            catch(Exception ex)
            {
                LogException(ex, "Report type = " + type);
            }
        }

        private static void LogException(Exception ex, string message)
        {
            // Typically here would be a real exception handling code, nputting a simle placeholder to log to DB

            var logic = new JobManagement.JobsCore(ConfigurationManager.AppSettings["database"]);
            logic.LogError(ex.ToString(), message);
        }
        
    }
}
