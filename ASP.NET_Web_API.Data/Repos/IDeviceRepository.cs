using ASP.NET_Web_API.Data.Models;
using ASP.NET_Web_API.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Web_API.Data.Repos
{
    public interface IDeviceRepository
    {
        Task<Device[]> GetDevices();
        Task<Device> GetDeviceByName(string name);
        Task<Device> GetDeviceById(Guid id);
        Task SaveDevice(Device device, Room room);
        Task UpdateDevice(Device device, Room room, UpdateDeviceQuery query);
        Task DeleteDevice(Device device);
    }
}
