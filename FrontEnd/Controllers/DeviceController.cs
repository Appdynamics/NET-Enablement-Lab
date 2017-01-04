using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class DeviceController : Controller
    {
        // GET: Device
        public ActionResult GetAllDevices(string userId)
        {
            var userSvc = new UserAccessService.UserAccessServiceClient();
            int n = -1;

            if(userSvc.ValidateAccess(this.User.Identity.Name, userId))
            {
                var devices = new Logic.Devices().GetDevices(userId);

                n = devices.Length;

                foreach(var device in devices)
                {
                    new Logic.Devices().GetDevice(userId, device.Id);
                }
            }

            string message = string.Format("success {1} devices. userId={0}", userId, n);
            return Content(message);
        }

        public ActionResult GetDeviceStatus(string userId, string deviceId)
        {
            var userSvc = new UserAccessService.UserAccessServiceClient();
            if (userSvc.ValidateAccess(this.User.Identity.Name, userId))
            {
                new Logic.Devices().GetDevice(userId, deviceId);
            }

            string message = string.Format("success device status. userId={0}. deviceId={1}", userId, deviceId);
            return Content(message);
        }

        public ActionResult UpdateDeviceSettings(string userId, string deviceId)
        {
            var userSvc = new UserAccessService.UserAccessServiceClient();
            if (userSvc.ValidateAccess(this.User.Identity.Name, userId))
            {
                var deviceSvc = new DevicesService.DevicesServiceClient();
                deviceSvc.UpdateDeviceSettings(userId, deviceId, "settings " + DateTime.Now.ToString()); 
            }

            string message = string.Format("success update device settings. userId={0}. deviceId={1}", userId, deviceId);
            return Content(message);
        }

        public ActionResult GetDeviceSettings(string userId, string deviceId)
        {
            var userSvc = new UserAccessService.UserAccessServiceClient();
            if (userSvc.ValidateAccess(this.User.Identity.Name, userId))
            {
                var deviceSvc = new DevicesService.DevicesServiceClient();
                deviceSvc.GetDeviceSettings(userId, deviceId);
            }

            string message = string.Format("success get device settings. userId={0}. deviceId={1}", userId, deviceId);
            return Content(message);
        }
    }
}