using AutoMapper;
using DataAccessLayer.Models.DTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
  public  class AppUserMapping : Profile
    {
        public AppUserMapping()
        {
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            CreateMap<AppUserDTO, AppUser>().ReverseMap();

        }
    }
}
