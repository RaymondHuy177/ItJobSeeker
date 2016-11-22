using ITJobSeeker.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITJobSeeker.Web.ViewModels
{
    public class JobDetailPageViewModel
    {
        public string JobID;

        public string JobTitle;

        public string Salary;

        public string JobDescription;

        public string JobRequirement;

        public string JobBenefit;

        public string FirstTechStack;

        public string SecondTechStack;

        public string ThirdTechStack;

        public string CompanyName;

        public string CompanyType;

        public string CompanySize;

        public string CompanyNation;

        public string Location;

        public void PrepareViewModel(Job job, Company company)
        {
            JobID = job.ID.ToString();
            JobTitle = job.Name;
            Salary = job.Salary;
            JobDescription = job.Description;
            JobRequirement = job.Requirement;
            JobBenefit = job.Benefits;
            FirstTechStack = job.FirstTechStack;
            SecondTechStack = job.SecondTechStack;
            ThirdTechStack = job.ThirdTechStack;
            CompanyName = job.Comapny.Name;
            CompanySize = "Start up 1-10";
            CompanyNation = "VietNam";
            CompanyType = "Product";
            Location = job.Location;
        }
    }
}