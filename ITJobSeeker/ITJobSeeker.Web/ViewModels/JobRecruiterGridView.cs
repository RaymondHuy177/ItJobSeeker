using ITJobSeeker.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITJobSeeker.Web.ViewModels
{
    public class JobRecruiterGridView
    {
        public IEnumerable<Job> Jobs;

        public void PrepareViewModel(IEnumerable<Job> jobs)
        {
            Jobs = jobs;
        }
    }
}