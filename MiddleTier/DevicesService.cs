using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MiddleTier
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class DevicesService : IDevicesService
    {
        public DeviceContext GetDevice(string userId, string deviceId)
        {
            var data = new DataAccess();
            var p = new Dictionary<string, object>();
            p.Add("@userId", userId);
            p.Add("@deviceId", deviceId);
            p.Add("@code", new Random().Next(17) + 3);
            data.ExecuteQuery("sp_GetDeviceDetails", p);

            var device = DeviceContext.DefaultContext();
            device.Id = deviceId;
            return device;
        }

        public IList<DeviceContext> GetDevices(string userId)
        {
            // UserId will contain encoded number of devices this user have.
            // UserId: bla-bla-blaBBNN
            // BB = hex two digit number = any number used for hiding NN number meaning
            // NN = hex two digit number = number of devices + base

            // By default there is always 1 device
            int N = 1;

            try
            {
                if (userId.Length >= 4)
                {
                    string bb = userId.Substring(userId.Length - 4, 2);
                    string nn = userId.Substring(userId.Length - 2, 2);

                    int b = int.Parse(bb, System.Globalization.NumberStyles.HexNumber);
                    int n = int.Parse(nn, System.Globalization.NumberStyles.HexNumber);

                    N = n - b;
                    if (N < 0) N = -N;
                    if (N > 30) N = 30;
                }
            }
            catch { }

            // Calculate delay based on the N = number of devices
            double t = Math.Exp((N - 10) / 5 ) / 2 * 1000;
            t *= ((new Random().NextDouble() / 5) + 0.9);
            if (t < 0) t = 0;

            int delay = Convert.ToInt32(t);

            var data = new DataAccess();
            var parameters = new Dictionary<string, object>();
            parameters.Add("@userId", userId);
            parameters.Add("@code", delay);
            data.ExecuteQuery("sp_GetAllDevicesForUser", parameters);

            var devices = new List<DeviceContext>();

            for(int i = 0; i < N; i++)
            {
                devices.Add(DeviceContext.DefaultContext());
            }

            return devices;
        }

        public IList<DeviceContext> GetUserDevices(string userId)
        {
            // UserId will contain encoded number of devices this user have.
            // UserId: bla-bla-blaBBNN
            // BB = hex two digit number = any number used for hiding NN number meaning
            // NN = hex two digit number = number of devices + base

            // By default there is always 1 device
            int N = 1;

            try
            {
                if (userId.Length >= 4)
                {
                    string bb = userId.Substring(userId.Length - 4, 2);
                    string nn = userId.Substring(userId.Length - 2, 2);

                    int b = int.Parse(bb, System.Globalization.NumberStyles.HexNumber);
                    int n = int.Parse(nn, System.Globalization.NumberStyles.HexNumber);

                    N = n - b;
                    if (N < 0) N = -N;
                    if (N > 30) N = 30;
                }
            }
            catch { }

            // Calculate delay based on the N = number of devices
            double t = Math.Exp((N - 10) / 5) / 2 * 1000;
            t *= ((new Random().NextDouble() / 5) + 0.9);
            if (t < 0) t = 0;

            int delay = Convert.ToInt32(t);

            var data = new DataAccess();
            var parameters = new Dictionary<string, object>();
            parameters.Add("@userId", userId);
            parameters.Add("@code", delay);
            data.ExecuteQuery("sp_GetAllDevicesForUser", parameters);

            var devices = new List<DeviceContext>();

            for (int i = 0; i < N; i++)
            {
                devices.Add(DeviceContext.DefaultContext());
            }

            return devices;
        }

        public string GetDeviceSettings(string userId, string deviceID)
        {
            var data = new DataAccess();
            var p = new Dictionary<string, object>();
            p.Add("@userId", userId);
            p.Add("@deviceId", deviceID);
            p.Add("@code", new Random().Next(15) + 5);
            data.ExecuteQuery("sp_GetDeviceSettings", p);

            return DateTime.Now.ToString();
        }

        public string UpdateDeviceSettings(string userId, string deviceID, string settings)
        {
            var data = new DataAccess();
            var p = new Dictionary<string, object>();
            p.Add("@userId", userId);
            p.Add("@deviceId", deviceID);
            p.Add("@code", new Random().Next(70) + 20);
            data.ExecuteQuery("sp_UpdateDeviceSettings", p);

            return DateTime.Now.ToString();
        }
    }
}
