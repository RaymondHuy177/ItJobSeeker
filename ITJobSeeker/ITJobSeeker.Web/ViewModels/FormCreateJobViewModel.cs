using ITJobSeeker.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITJobSeeker.Web.ViewModels
{
    public class FormCreateJobViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SmallDescription { get; set; }
        public string Requirement { get; set; }

        public DateTime ExpiredDate { get; set; }
        public string Salary { get; set; }
        
        public string Benefits { get; set; }

        public string FirstTechStack { get; set; }
        public string SecondTechStack { get; set; }
        public string ThirdTechStack { get; set; }

        public List<KeyValuePair<string, string>> TechStackDropDownList;

        public void PrepareViewModel(IEnumerable<TechnologyKeyword> keywords)
        {
            TechStackDropDownList = new List<KeyValuePair<string, string>>();
            foreach (var keyword in keywords)
            {
                TechStackDropDownList.Add(new KeyValuePair<string, string>(keyword.ID.ToString(), keyword.Name));
            }
        }
    }
}