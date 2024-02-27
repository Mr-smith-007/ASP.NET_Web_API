using ASP.NET_Web_API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Web_API.Data.Repos
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomByName(string name);
        Task AddRoom(Room room);
        Task<Room> GetRoomById(Guid id);
        Task UpdateRoom(Room room);
    }
}
