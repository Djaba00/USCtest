using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.DTOEntities;
using USCtext.DAL.Entities;

namespace USCtest.BLL.Configurations
{
    public class MappingProfileBLL : Profile
    {
        public MappingProfileBLL()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<FlatDTO, Flat>();
            CreateMap<Flat, FlatDTO>();

            CreateMap<TaxDTO, Tax>();
            CreateMap<Tax, TaxDTO>();
        }
    }
}
