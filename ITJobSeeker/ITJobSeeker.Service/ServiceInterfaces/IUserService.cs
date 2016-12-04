﻿using ITJobSeeker.Model.Models;
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
    }
}
