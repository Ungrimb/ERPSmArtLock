using AutoMapper;
using ERPSmArtLock.Models;
using ERPSmArtLock.Entities;

namespace ERPSmArtLock.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile ( )
        {
            CreateMap<User, Users> ();
            CreateMap<RegisterModel, User> ();
            CreateMap<UpdateModel, User> ();
        }
    }
}
