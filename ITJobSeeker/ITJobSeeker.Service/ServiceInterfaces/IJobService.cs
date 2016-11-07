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
    }
}
