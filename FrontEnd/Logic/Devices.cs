using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace FrontEnd.Logic
{
    public class Devices
    {
        public DevicesService.DeviceContext[] GetDevices(string userId)
        {
            var t1 = DateTime.Now;
            var deviceSvc = new DevicesService.DevicesServiceClient();
            var devices = deviceSvc.GetDevices(userId);
            var t2 = DateTime.Now;
            var dt = t2 - t1;
            return devices;
        }

        public async Task<DevicesService.DeviceContext[]> GetDevicesAsync(string userId)
        {
            var t1 = DateTime.Now;
            var deviceSvc = new DevicesService.DevicesServiceClient();
            var devices = await deviceSvc.GetUserDevicesAsync(userId);
            var t2 = DateTime.Now;
            var dt = t2 - t1;
            return devices;
        }

        public DevicesService.DeviceContext GetDevice(string userId, string deviceId)
        {
            var t1 = DateTime.Now;
            var deviceSvc = new DevicesService.DevicesServiceClient();
            var device = deviceSvc.GetDevice(userId, deviceId);
            var t2 = DateTime.Now;
            var dt = t2 - t1;
            return device;
        }

        public async Task<DevicesService.DeviceContext> GetDeviceAsync(string userId, string deviceId)
        {
            var t1 = DateTime.Now;
            var deviceSvc = new DevicesService.DevicesServiceClient();
            var device = await deviceSvc.GetDeviceAsync(userId, deviceId);
            var t2 = DateTime.Now;
            var dt = t2 - t1;
            return device;
        }
    }
}