using ASP.NET_Web_API.Configuration;
using ASP.NET_Web_API.Contracts.Home;
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
        }
    }
}
