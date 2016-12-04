﻿using ITJobSeeker.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Service.Common
{
    public class Account
    {
        public bool HasLoggin = false;
        public bool IsRecruiter = false;
        public bool IsJobSeeker = false;
        public string UserName = "";
        public Account() { }
        public Account(User user)
        {
            UserName = user.UserName;
            HasLoggin = true;
            if (user.Role.Name == "Recruiter")
                IsRecruiter = true;
            else if (user.Role.Name == "JobSeeker")
                IsRecruiter = true;
        }
    }
}