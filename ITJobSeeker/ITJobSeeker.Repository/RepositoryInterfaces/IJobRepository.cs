using ITJobSeeker.Model.Models;
using ITJobSeeker.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Repository.RepositoryInterfaces
{
    public interface IJobRepository : IRepository<Job>
    {
        Job GetJobDetailByName(string jobName);
        IEnumerable<Job> GetJobsWithCompany();
        List<Job> GetListJobByName(string jobName);

        List<Job> GetListJobByLocation(string location);
    }
}
