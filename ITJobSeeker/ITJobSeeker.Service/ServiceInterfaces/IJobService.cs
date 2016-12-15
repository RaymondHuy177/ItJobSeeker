using ITJobSeeker.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Service.ServiceInterfaces
{
    public interface IJobService
    {
        IEnumerable<Job> GetJobsByPage(int page = 1);

        Job GetDetailJob(Guid id);

        void AddJob(Job job);

        IEnumerable<Job> GetJobsByRecruiter(Guid RecruiterID);

        void EditJob(Job job);

        void SaveJob();

        void DeleteJob(Job job);

        List<Job> Filter(string keyword, string location);
    }
}
