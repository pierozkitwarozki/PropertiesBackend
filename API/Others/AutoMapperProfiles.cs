using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.Others
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserToRegister, User>().ReverseMap();
            CreateMap<Property, PropertyToReturn>()
                .ForMember(x => x.DistrictName, opt => opt.MapFrom(src => src.District.Name));
            CreateMap<DistrictToAdd, District>().ReverseMap();
            CreateMap<PropertyToAdd, Property>();
            CreateMap<User, UserDetail>();
            CreateMap<UserPropertyToAdd, UserProperty>();
            
        }
    }
}