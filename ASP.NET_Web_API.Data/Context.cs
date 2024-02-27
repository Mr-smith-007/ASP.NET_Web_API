using ASP.NET_Web_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Web_API.Data
{
    public class Context: DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Device> Devices { get; set; }
        
        public Context(DbContextOptions<Context> options): base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Room>().ToTable("Rooms");
            builder.Entity<Device>().ToTable("Devices");
        }
    }
}
