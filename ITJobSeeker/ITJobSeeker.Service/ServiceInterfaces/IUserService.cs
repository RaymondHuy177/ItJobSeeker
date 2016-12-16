using ITJobSeeker.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Service.ServiceInterfaces
{
    public interface IUserService
    {
        string AddJobSeeker(User jobSeeker);
        void Save();
        string RegisterJobSeeker(User jobSeeker);

        void RegisterRecruiter(User Recruiter, Company company);

        User GetUserInfo(Guid id);
        IEnumerable<User> GetAllJobSeekerGridView();
        IEnumerable<User> GetAllRecruiterGridView();
        void UpdateActiveStatus(string userID, bool status);
    }
}
