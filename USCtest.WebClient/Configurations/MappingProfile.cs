using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Linq;
using USCtest.BLL.BusinesModels;
using USCtest.BLL.Models;
using USCtest.DAL.Entities;
using USCtest.WebClient.ViewModels;
using USCtest.WebClient.ViewModels.FlatVM;
using USCtest.WebClient.ViewModels.TaxVM;
using USCtest.WebClient.ViewModels.UserVM;

namespace USCtest.WebClient.Configurations
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<UserModel, UserViewModel>()
                .ForMember(vm => vm.FullName, opt => opt.MapFrom(m => m.GetFullName()))
                .ForMember(vm => vm.Passport, opt => opt.MapFrom(m => m.GetFullPassport()));

            CreateMap<FlatModel, FlatViewModel>()
                .ForMember(vm => vm.Address, opt => opt.MapFrom(m => m.GetFullAddress()))
                .ForMember(vm => vm.Residents, opt => opt.MapFrom(m => m.Users.Count))
                .ForMember(vm => vm.Users, opt => opt.MapFrom(m => m.Users.Select(u => u.GetFullName())));

            CreateMap<CreateFlatViewModel, FlatViewModel>();
            CreateMap<UpdateFlatViewModel, FlatModel>().ReverseMap();
            CreateMap<CreateTaxViewModel, FlatIndications>().ReverseMap();

            CreateMap<CreateTaxViewModel, TaxViewModel>();
            CreateMap<UpdateTaxViewModel, TaxViewModel>().ReverseMap();
            CreateMap<TaxModel, TaxViewModel>()
                .ForMember(vm => vm.Flat, opt => opt.MapFrom(m => m.Flat.GetFullAddress()));
        }
    }
}