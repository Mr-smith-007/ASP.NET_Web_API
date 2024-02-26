using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Web_API.Contracts.Devices
{
   
        public class AddDeviceRequest
        {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        [Range(120, 220, ErrorMessage = "Поддерживаются устройства с напряжением от {1} до {2} вольт.")]
        public int CurrentVolts { get; set; }
        [Required]
        public bool GasUsage { get; set; }
        [Required]
        public string Location { get; set; }
        }
    
}
