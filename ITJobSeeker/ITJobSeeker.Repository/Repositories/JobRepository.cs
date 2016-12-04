using ITJobSeeker.Model.Models;
using ITJobSeeker.Repository.Infrastructure;
using ITJobSeeker.Repository.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ITJobSeeker.Repository.Repositories
{
    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        public JobRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Job GetJobDetailByName(string jobName)
        {
            var job = this.DbContext.Jobs.Where(n => n.Name == jobName).FirstOrDefault();

            return job;
        }

        public List<Job> GetListJobByName(string jobName)
        {
            var jobs = this.DbContext.Jobs.Where(n => n.Name.Contains(jobName)).ToList();

            return jobs;
        }

        public List<Job> GetListJobByLocation(string location)
        {
            var jobs = this.DbContext.Jobs.Where(n => n.Comapny.Name.Contains(location)).ToList();

            return jobs;
        }

        public IEnumerable<Job> GetJobsWithCompany()
        {
            return DbContext.Jobs.AsEnumerable();
        }
    }
}
