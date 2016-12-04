using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITJobSeeker.Web.ViewModels
{
    public class RecruiterRegisterFormViewModel
    {
        public Guid ID = Guid.NewGuid();
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsMale { get; set; }
        public string CompanyType { get; set; }
        public string CompanySize { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
    }
}