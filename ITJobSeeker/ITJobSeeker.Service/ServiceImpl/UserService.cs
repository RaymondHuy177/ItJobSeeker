using ITJobSeeker.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJobSeeker.Model.Models;
using ITJobSeeker.Repository.RepositoryInterfaces;
using ITJobSeeker.Repository.Infrastructure;

namespace ITJobSeeker.Service.ServiceImpl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository _userRepository, IUnitOfWork _unitOfWork)
        {
            this.userRepository = _userRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void AddJobSeeker(User jobSeeker)
        {
            if (jobSeeker.AvatarID == null)
                jobSeeker.AvatarID = new Guid("0cee8ce8-5cf5-4d5a-b4e8-8c089cec3411");
            jobSeeker.RoleID = new Guid("8fab4cd3-d18a-4926-980f-d4859510fddf");
            userRepository.Add(jobSeeker);
        }

        public void SaveJobSeeker()
        {
            unitOfWork.Commit();
        }
    }
}
