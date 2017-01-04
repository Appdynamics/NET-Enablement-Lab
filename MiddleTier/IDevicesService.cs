using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MiddleTier
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDevicesService" in both code and config file together.
    [ServiceContract(Name = "DevicesService", Namespace = "http://appdynamics.com/Demo")]
    public interface IDevicesService
    {
        [OperationContract(Action = "GetDevices")]
        IList<DeviceContext> GetDevices(string userId);

        [OperationContract(Action = "GetUserDevices")]
        IList<DeviceContext> GetUserDevices(string userId);

        [OperationContract(Action = "GetDevice")]
        DeviceContext GetDevice(string userId, string deviceId);

        [OperationContract(Action = "GetDeviceSettings")]
        string GetDeviceSettings(string userId, string deviceID);

        [OperationContract(Action = "UpdateDeviceSettings")]
        string UpdateDeviceSettings(string userId, string deviceID, string settings);
    }

    [DataContract]
    public class DeviceContext
    {
        [DataMember]
        public string Type;
        [DataMember]
        public string Id;
        [DataMember]
        public string Family;
        [DataMember]
        public string Status;

        public static DeviceContext DefaultContext()
        {
            var device = new DeviceContext();

            device = new DeviceContext();
            device.Id = Guid.NewGuid().ToString();
            device.Type = Guid.NewGuid().ToString();
            device.Family = Guid.NewGuid().ToString();
            device.Status = "online";

            return device;
        }
    }

}
