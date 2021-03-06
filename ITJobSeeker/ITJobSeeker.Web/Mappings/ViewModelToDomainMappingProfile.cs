﻿using AutoMapper;
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
                .ForMember(u => u.UserName, map => map.MapFrom(vm => vm.UserName))
                .ForMember(u => u.LastName, map => map.MapFrom(vm => vm.LastName))
                .ForMember(u => u.FirstName, map => map.MapFrom(vm => vm.FirstName))
                .ForMember(u => u.Password, map => map.MapFrom(vm => vm.Password))
                .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email))
                .ForMember(u => u.IsMale, map => map.MapFrom(vm => vm.IsMale))
                .ForMember(u => u.Telephone, map => map.MapFrom(vm => vm.Phone));

            Mapper.CreateMap<FormCreateJobViewModel, Job>()
                .ForMember(j => j.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(j => j.Requirement, map => map.MapFrom(vm => vm.Requirement))
                .ForMember(j => j.Benefits, map => map.MapFrom(vm => vm.Benefits))
                .ForMember(j => j.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(j => j.SmallDescription, map => map.MapFrom(vm => vm.SmallDescription))
                .ForMember(j => j.Salary, map => map.MapFrom(vm => vm.Salary))
                .ForMember(j => j.SecondTechStack, map => map.MapFrom(vm => vm.SecondTechStack))
                .ForMember(j => j.ThirdTechStack, map => map.MapFrom(vm => vm.ThirdTechStack))
                .ForMember(j => j.FirstTechStack, map => map.MapFrom(vm => vm.FirstTechStack));

            Mapper.CreateMap<FormEditJobViewModel, Job>()
                .ForMember(j => j.ID, map => map.MapFrom(vm => new Guid(vm.ID)))
                .ForMember(j => j.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(j => j.Requirement, map => map.MapFrom(vm => vm.Requirement))
                .ForMember(j => j.Benefits, map => map.MapFrom(vm => vm.Benefits))
                .ForMember(j => j.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(j => j.SmallDescription, map => map.MapFrom(vm => vm.SmallDescription))
                .ForMember(j => j.Salary, map => map.MapFrom(vm => vm.Salary))
                .ForMember(j => j.SecondTechStack, map => map.MapFrom(vm => vm.SecondTechStack))
                .ForMember(j => j.ThirdTechStack, map => map.MapFrom(vm => vm.ThirdTechStack))
                .ForMember(j => j.FirstTechStack, map => map.MapFrom(vm => vm.FirstTechStack));

            Mapper.CreateMap<RecruiterRegisterFormViewModel, User>()
                .ForMember(u => u.ID, map => map.MapFrom(vm => vm.ID))
                .ForMember(u => u.UserName, map => map.MapFrom(vm => vm.UserName))
                .ForMember(u => u.LastName, map => map.MapFrom(vm => vm.CompanyName))
                .ForMember(u => u.FirstName, map => map.MapFrom(vm => vm.CompanyName))
                .ForMember(u => u.Password, map => map.MapFrom(vm => vm.Password))
                .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email))
                .ForMember(u => u.IsMale, map => map.MapFrom(vm => vm.IsMale))
                .ForMember(u => u.Telephone, map => map.MapFrom(vm => vm.Phone));

            Mapper.CreateMap<RecruiterRegisterFormViewModel, Company>()
                .ForMember(u => u.ID, map => map.MapFrom(vm => vm.ID))
                .ForMember(c => c.Name, map => map.MapFrom(vm => vm.CompanyName))
                .ForMember(c => c.Address, map => map.MapFrom(vm => vm.Address))
                .ForMember(c => c.Location, map => map.MapFrom(vm => vm.Location))
                .ForMember(c => c.Type, map => map.MapFrom(vm => vm.CompanyType))
                .ForMember(c => c.Size, map => map.MapFrom(vm => vm.CompanySize));

            Mapper.CreateMap<ProfilePageViewModel, Company>()
                .ForMember(u => u.ID, map => map.MapFrom(vm => vm.ID))
                .ForMember(c => c.Name, map => map.MapFrom(vm => vm.CompanyName))
                .ForMember(c => c.Address, map => map.MapFrom(vm => vm.Address))
                .ForMember(c => c.Location, map => map.MapFrom(vm => vm.Location))
                .ForMember(c => c.Type, map => map.MapFrom(vm => vm.Type))
                .ForMember(c => c.Size, map => map.MapFrom(vm => vm.Size));
        }
    }
}