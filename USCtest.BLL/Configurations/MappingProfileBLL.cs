using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.Models;
using USCtest.DAL.Entities;

namespace USCtest.BLL.Configurations
{
    public class MappingProfileBLL : Profile
    {
        public MappingProfileBLL()
        {
            CreateMap<AccountModel, ApplicationUser>().ReverseMap();

            CreateMap<UserProfileModel, UserProfile>().ReverseMap();

            CreateMap<FlatModel, Flat>().ReverseMap();

            CreateMap<RegistrationModel, Registration>().ReverseMap();

            CreateMap<TaxModel, Tax>().ReverseMap();
        }
    }
}
