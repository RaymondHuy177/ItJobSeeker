using ITJobSeeker.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJobSeeker.Model.Models;
using ITJobSeeker.Repository.RepositoryInterfaces;
using ITJobSeeker.Repository.Infrastructure;
using ITJobSeeker.Service.Common;

namespace ITJobSeeker.Service.ServiceImpl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConstraintService constraintService;

        public UserService(IUserRepository _userRepository, IUnitOfWork _unitOfWork, IConstraintService _constraintService)
        {
            this.userRepository = _userRepository;
            this.unitOfWork = _unitOfWork;
            this.constraintService = _constraintService;
        }

        public string AddJobSeeker(User jobSeeker)
        {
            string message = constraintService.ValidateJobSeekerInfo(jobSeeker);
            if (!message.Equals(ActionStatus.Success))
                return message;
            if (jobSeeker.AvatarID == null || jobSeeker.AvatarID == new Guid())
                jobSeeker.AvatarID = new Guid("0cee8ce8-5cf5-4d5a-b4e8-8c089cec3411");
            jobSeeker.RoleID = new Guid("8fab4cd3-d18a-4926-980f-d4859510fddf");
            jobSeeker.Password = PasswordEncrypt.ConverToMD5(jobSeeker.Password);
            userRepository.Add(jobSeeker);
            return ActionStatus.Success;
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public string RegisterJobSeeker(User jobSeeker)
        {
            string message = AddJobSeeker(jobSeeker);
            if (!message.Equals(ActionStatus.Success))
                return message;
            Save();
            return ActionStatus.Success;
        }
    }
}
