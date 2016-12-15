using ITJobSeeker.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITJobSeeker.Service.ServiceInterfaces
{
    public interface ICompanyService
    {
        void UpdateRecruiterInfo(Company company, HttpPostedFileBase firstPicture,
            HttpPostedFileBase secondPicture, HttpPostedFileBase thirdPicture, HttpPostedFileBase Avatar);
    }
}
