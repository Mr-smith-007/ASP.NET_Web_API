using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Web_API.Data.Queries
{
    public class UpdateDeviceQuery
    {
        public string NewName { get; }
        public string NewSerial { get; }

        public UpdateDeviceQuery(string newName = null, string newSerial = null)
        {
            NewName = newName;
            NewSerial = newSerial;
        }
    }
}
