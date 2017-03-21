using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace AjaxClient.Controllers
{
    public class ClientController : ApiController
    {
        [Route("daily/{userID}/{reportType}")]
        [HttpGet]
        public async Task<string> ScheduleDailyReport(string userID, string reportType)
        {
            reportType = "You-Got-It-Right!-" + reportType;

            var p = new Dictionary<string,string> { { "userID", userID}, { "reportType", reportType }, { "duration", "890" } };

            var client = new ServiceReference.ScheduleServiceClient();

            return await client.ScheduleJobAsync("dailyreport", p);
        }

        [Route("weekly/{userID}/{reportType}")]
        [HttpGet]
        public async Task<string> ScheduleWeeklyReport(string userID, string reportType)
        {
            reportType = "You-Got-It-Right!-" + reportType;

            var p = new Dictionary<string, string> { { "userID", userID }, { "reportType", reportType }, { "duration", "2350" } };

            var client = new ServiceReference.ScheduleServiceClient();

            return await client.ScheduleJobAsync("weeklyreport", p);
        }

        [Route("ondemand/{userID}/{reportType}")]
        [HttpGet]
        public async Task<string> StartOndemandReport(string userID, string reportType)
        {
            reportType = "You-Got-It-Right!-" + reportType;

            var p = new Dictionary<string, string> { { "userID", userID }, { "reportType", reportType }, { "duration", "250" } };

            var client = new ServiceReference.ScheduleServiceClient();

            return await client.ScheduleJobAsync("ondemandreport", p);
        }

    }
}
