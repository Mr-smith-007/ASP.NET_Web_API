using ASP.NET_Web_API.Configuration;
using ASP.NET_Web_API.Contracts.Devices;
using ASP.NET_Web_API.Contracts.Home;
using ASP.NET_Web_API.Contracts.Models.Devices;
using ASP.NET_Web_API.Contracts.Models.Rooms;
using ASP.NET_Web_API.Data.Models;
using AutoMapper;

namespace ASP.NET_Web_API.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressInfo>();
            CreateMap<HomeOptions, InfoResponse>()
                .ForMember(m => m.AddressInfo,
                    opt => opt.MapFrom(src => src.Address));


            CreateMap<AddDeviceRequest, Device>().ForMember(d => d.Location,
                opt => opt.MapFrom(r => r.RoomLocation));
            CreateMap<AddRoomRequest, Room>();
            CreateMap<Device, DeviceView>();
        }
    }
}
