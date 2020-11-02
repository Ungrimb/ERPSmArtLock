using AutoMapper;
using ERP.Models;
using ERPSmArtLock.Entities;
using ERPSmArtLock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
