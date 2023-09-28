using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Routing.Matching;
using System;
using System.Linq;
using USCtest.BLL.BusinesModels;
using USCtest.BLL.Models;
using USCtest.DAL.Entities;
using USCtest.WebClient.ViewModels;
using USCtest.WebClient.ViewModels.FlatVM;
using USCtest.WebClient.ViewModels.RegistrationVM;
using USCtest.WebClient.ViewModels.TaxVM;
using USCtest.WebClient.ViewModels.UserVM;

namespace USCtest.WebClient.Configurations
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<UserProfileModel, UserViewModel>()
                .ForMember(vm => vm.FullName, opt => opt.MapFrom(m => m.GetFullName()))
                .ForMember(vm => vm.Passport, opt => opt.MapFrom(m => m.GetFullPassport()));
            CreateMap<CreateUserViewModel, UserProfileModel>();
            CreateMap<UpdateTaxViewModel, UserProfileModel>().ReverseMap();

            CreateMap<FlatModel, FlatViewModel>()
                .ForMember(vm => vm.Address, opt => opt.MapFrom(m => m.GetFullAddress()))
                .ForMember(vm => vm.Residents, opt => opt.MapFrom(m => m.GetResidentsCount()))
                .ForMember(vm => vm.Debt, opt => opt.MapFrom(m => m.GetDebt()));
            CreateMap<CreateFlatViewModel, FlatViewModel>();
            CreateMap<FlatModel, UpdateFlatViewModel>().ReverseMap();
            CreateMap<FlatModel, CreateIndicationsViewModel>()
                .ForMember(vm => vm.FlatId, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.Residents, opt => opt.MapFrom(m => m.GetResidentsCount()))
                .ReverseMap();

            CreateMap<IndicationsViewModel, IndicationsModel>();

            CreateMap<CreateTaxViewModel, IndicationsModel>();
            CreateMap<UpdateTaxViewModel, TaxViewModel>().ReverseMap();
            CreateMap<TaxModel, TaxViewModel>()
                .ForMember(vm => vm.Flat, opt => opt.MapFrom(m => m.Flat.GetFullAddress()));

            CreateMap<RegistrationViewModel, RegistrationModel>().ReverseMap();
        }
    }
}