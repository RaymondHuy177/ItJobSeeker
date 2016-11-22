using ITJobSeeker.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJobSeeker.Model.Models;
using ITJobSeeker.Service.Common;

namespace ITJobSeeker.Service.ServiceImpl
{
    public class ConstraintService : IConstraintService
    {
        public string ValidateJobSeekerInfo(User user)
        {
            if (String.IsNullOrWhiteSpace(user.Email))
                return "Email can not be null";
            else if (String.IsNullOrWhiteSpace(user.Password))
                return "Password can not be null";
            else if (String.IsNullOrWhiteSpace(user.FirstName))
                return "FirstName can not be null";
            else if (String.IsNullOrWhiteSpace(user.LastName))
                return "LastName can not be null";
            else if (String.IsNullOrWhiteSpace(user.Location))
                return "Location can not be null";
            else if (String.IsNullOrWhiteSpace(user.Address))
                return "Address can not be null";
            return ActionStatus.Success;
        }
    }
}
