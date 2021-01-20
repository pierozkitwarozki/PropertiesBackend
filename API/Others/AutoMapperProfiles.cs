using System.Linq;
using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.Others
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserToRegister, AppUser>().ReverseMap();
            CreateMap<Property, PropertyToReturn>()
                .ForMember(x => x.DistrictName, opt => opt.MapFrom(src => src.District.Name));
            CreateMap<DistrictToAdd, District>().ReverseMap();
            CreateMap<PropertyToAdd, Property>();
            CreateMap<AppUser, UserDetail>()
                .ForMember(x => x.Role, opt => opt.MapFrom(src => src.UserRoles.FirstOrDefault(y => y.UserId == src.Id).Role.Name));
            CreateMap<UserDistrictToAdd, UserDistrict>();
            
        }
    }
}