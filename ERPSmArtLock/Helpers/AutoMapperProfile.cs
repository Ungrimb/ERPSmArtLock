using AutoMapper;
using ERPSmArtLock.Models;
using ERPSmArtLock.Entities;

namespace ERPSmArtLock.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile ( )
        {
            CreateMap<Users, UsersModel> ();
            CreateMap<RegisterModel, Users> ();
            CreateMap<UpdateModel, Users> ();
        }
    }
}
