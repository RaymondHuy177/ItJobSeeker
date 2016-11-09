using AutoMapper;
using ITJobSeeker.Model.Models;
using ITJobSeeker.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITJobSeeker.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<JobSeekerRegisterFormViewModel, User>()
                .ForMember(u=>u.UserName, map=>map.MapFrom(vm=>vm.UserName))
                .ForMember(u => u.LastName, map => map.MapFrom(vm => vm.LastName))
                .ForMember(u => u.FirstName, map => map.MapFrom(vm => vm.FirstName))
                .ForMember(u => u.Password, map => map.MapFrom(vm => vm.Password))
                .ForMember(u => u.Location, map => map.MapFrom(vm => vm.Location))
                .ForMember(u => u.Address, map => map.MapFrom(vm => vm.Address))
                .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email))
                .ForMember(u => u.IsMale, map => map.MapFrom(vm => vm.IsMale))
                .ForMember(u => u.Telephone, map => map.MapFrom(vm => vm.Phone));
        }
    }
}