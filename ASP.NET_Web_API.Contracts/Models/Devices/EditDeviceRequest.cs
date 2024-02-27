using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Web_API.Contracts.Models.Devices
{
    public class EditDeviceRequest
    {
        public string NewRoom { get; set; }
        public string NewName { get; set; }
        public string NewSerial { get; set; }
    }
}
