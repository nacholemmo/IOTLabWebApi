using AutoMapper;
using IOTLabWebApi.Controllers.Resources;
using IOTLabWebApi.Core.Models;

namespace IOTLabWebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<UserAppProfile,UserAppProfileResource>();


            //Api Resource to Domain

            CreateMap<UserAppProfileResource,UserAppProfile>();
        }
    }
}