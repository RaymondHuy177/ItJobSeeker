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
        private readonly ICompanyRepository companyRepository;
        private readonly IConstraintService constraintService;
        private readonly IRoleRepository roleRepository;

        public UserService(
            IUserRepository _userRepository,
            ICompanyRepository _companyRepository,
            IRoleRepository _roleRepository,
            IUnitOfWork _unitOfWork, 
            IConstraintService _constraintService)
        {
            roleRepository = _roleRepository;
            companyRepository = _companyRepository;
            userRepository = _userRepository;
            unitOfWork = _unitOfWork;
            constraintService = _constraintService;
        }

        public string AddJobSeeker(User jobSeeker)
        {
            string message = constraintService.ValidateJobSeekerInfo(jobSeeker);
            if (!message.Equals(ActionStatus.Success))
                return message;
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

        public void RegisterRecruiter(User Recruiter, Company company)
        {
            Recruiter.RoleID = roleRepository.Get(r => r.Name == "Recruiter").ID;
            Recruiter.Password = PasswordEncrypt.ConverToMD5(Recruiter.Password);
            userRepository.Add(Recruiter);
            companyRepository.Add(company);
            unitOfWork.Commit();
        }

        public User GetUserInfo(Guid id)
        {
            User user = userRepository.GetById(id);
            Company company = companyRepository.GetById(id);
            user.Company = company;
            return user;
        }

        public IEnumerable<User> GetAllJobSeekerGridView()
        {
            Role role = roleRepository.Get(r => r.Name == "JobSeeker");
            IEnumerable<User> users = userRepository.GetMany(u => u.RoleID == role.ID);
            return users;
        }
        

        public IEnumerable<User> GetAllRecruiterGridView()
        {
            Role role = roleRepository.Get(r => r.Name == "Recruiter");
            IEnumerable<User> users = userRepository.GetMany(u => u.RoleID == role.ID);
            IEnumerable<Company> companies = companyRepository.GetAll();
            foreach (User user in users)
            {
                foreach (Company company in companies)
                {
                    if (user.ID == company.ID)
                    {
                        user.Company = company;
                        break;
                    }
                }
            }
            return users;
        }

        public void UpdateActiveStatus(string userID, bool status)
        {
            User user = userRepository.GetById(new Guid(userID));
            user.IsActive = status;
            unitOfWork.Commit();
        }
    }
}
