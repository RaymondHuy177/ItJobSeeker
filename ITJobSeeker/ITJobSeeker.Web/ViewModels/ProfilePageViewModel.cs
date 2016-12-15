using ITJobSeeker.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITJobSeeker.Web.ViewModels
{
    public class ProfilePageViewModel
    {
        public string ID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public HttpPostedFileBase Avatar { get; set; }
        public HttpPostedFileBase FirstPicture { get; set; }
        public HttpPostedFileBase SecondPicture { get; set; }
        public HttpPostedFileBase ThirdPicture { get; set; }
    }
}