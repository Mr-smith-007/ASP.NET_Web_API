using ASP.NET_Web_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Web_API.Data.Repos
{
    public class RoomRepository : IRoomRepository
    {
        private readonly Context _context;

        public RoomRepository(Context context)
        {
            _context = context;
        }
                
        public async Task<Room> GetRoomByName(string name)
        {
            return await _context.Rooms.Where(r => r.Name == name).FirstOrDefaultAsync();
        }
               
        public async Task AddRoom(Room room)
        {
            var entry = _context.Entry(room);
            if (entry.State == EntityState.Detached)
                await _context.Rooms.AddAsync(room);

            await _context.SaveChangesAsync();
        }
        
        public async Task<Room> GetRoomById(Guid id)
        {
            return await _context.Rooms.Where(r => r.Id == id).FirstOrDefaultAsync();
        }
        
        public async Task UpdateRoom(Room room)
        {
            Room roomFromEntity = _context.Rooms.Where(r => r.Id == room.Id).FirstOrDefault();
            roomFromEntity.Name = room.Name;
            roomFromEntity.Area = room.Area;
            roomFromEntity.GasConnected = room.GasConnected;
            roomFromEntity.Voltage = room.Voltage;

            var entry = _context.Entry(roomFromEntity);
            if (entry.State == EntityState.Detached)
                _context.Rooms.Update(roomFromEntity);
            await _context.SaveChangesAsync();
        }
    }
}
