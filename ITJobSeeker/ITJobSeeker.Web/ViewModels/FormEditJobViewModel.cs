using ITJobSeeker.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITJobSeeker.Web.ViewModels
{
    public class FormEditJobViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SmallDescription { get; set; }
        public string Requirement { get; set; }
        public string Salary { get; set; }

        public string Benefits { get; set; }

        public string FirstTechStack { get; set; }
        public string SecondTechStack { get; set; }
        public string ThirdTechStack { get; set; }

        public List<KeyValuePair<string, string>> TechStackDropDownList;

        public void PrepareViewModel(IEnumerable<TechnologyKeyword> keywords, Job job)
        {
            ID = job.ID.ToString();
            Name = job.Name;
            Description = job.Description;
            SmallDescription = job.SmallDescription;
            Requirement = job.Requirement;
            Salary = job.Salary;
            Benefits = job.Benefits;
            FirstTechStack = job.FirstTechStack;
            SecondTechStack = job.SecondTechStack;
            ThirdTechStack = job.ThirdTechStack;
            TechStackDropDownList = new List<KeyValuePair<string, string>>();
            foreach (var keyword in keywords)
            {
                TechStackDropDownList.Add(new KeyValuePair<string, string>(keyword.ID.ToString(), keyword.Name));
            }
        }
    }
}