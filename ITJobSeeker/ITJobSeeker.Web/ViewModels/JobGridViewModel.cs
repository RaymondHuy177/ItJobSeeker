using ITJobSeeker.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITJobSeeker.Web.ViewModels
{
    public class JobGridViewModel
    {
        public IEnumerable<Job> FirstColumnJob;
        public IEnumerable<Job> SecondColumnJob;
        public bool HasLogin;
        public JobGridViewModel(IEnumerable<Job> jobs, bool hasLogin = false)
        {
            HasLogin = hasLogin;
            int paginition = jobs.Count() / 2;
            if (jobs.Count() % 2 == 0)
            {
                FirstColumnJob = jobs.Take(paginition);
                SecondColumnJob = jobs.Skip(paginition).Take(paginition);
            }
            else
            {
                FirstColumnJob = jobs.Take(paginition + 1);
                SecondColumnJob = jobs.Skip(paginition + 1).Take(paginition - 1);
            }
        }
    }
}