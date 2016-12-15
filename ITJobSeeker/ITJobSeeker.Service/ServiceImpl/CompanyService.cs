using ITJobSeeker.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJobSeeker.Model.Models;
using System.Web;
using ITJobSeeker.Repository.RepositoryInterfaces;
using ITJobSeeker.Repository.Infrastructure;
using System.IO;

namespace ITJobSeeker.Service.ServiceImpl
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IPictureRepository pictureRepository;
        private readonly IUnitOfWork unitOfWork;

        public CompanyService(ICompanyRepository _companyRepository,
            IPictureRepository _pictureRepository,
            IUnitOfWork _unitOfWork)
        {
            companyRepository = _companyRepository;
            pictureRepository = _pictureRepository;
            unitOfWork = _unitOfWork;
        }

        public void UpdateRecruiterInfo(Company company, HttpPostedFileBase firstPicture, 
            HttpPostedFileBase secondPicture, HttpPostedFileBase thirdPicture, HttpPostedFileBase Avatar)
        {
            string serverPath = AppDomain.CurrentDomain.BaseDirectory + "images\\recruiter\\";

            Picture firstPic = new Picture();
            
            Picture secondPic = new Picture();
            
            Picture thirdPic = new Picture();

            Picture avatar = new Picture();
            
            company.FirstPictureID = firstPic.ID;
            company.SecondPictureID = secondPic.ID;
            company.ThirdPictureID = thirdPic.ID;
            company.AvatarID = avatar.ID;
            pictureRepository.Add(firstPic);
            pictureRepository.Add(secondPic);
            pictureRepository.Add(thirdPic);
            pictureRepository.Add(avatar);
            companyRepository.Update(company);
            
            firstPicture.SaveAs(Path.Combine(serverPath, firstPic.ID.ToString() + ".png"));
            firstPic.Data = File.ReadAllBytes(Path.Combine(serverPath, firstPic.ID.ToString() + ".png"));

            secondPicture.SaveAs(Path.Combine(serverPath, secondPic.ID.ToString() + ".png"));
            secondPic.Data = File.ReadAllBytes(Path.Combine(serverPath, secondPic.ID.ToString() + ".png"));

            thirdPicture.SaveAs(Path.Combine(serverPath, thirdPic.ID.ToString() + ".png"));
            thirdPic.Data = File.ReadAllBytes(Path.Combine(serverPath, thirdPic.ID.ToString() + ".png"));

            Avatar.SaveAs(Path.Combine(serverPath, avatar.ID.ToString() + ".png"));
            avatar.Data = File.ReadAllBytes(Path.Combine(serverPath, avatar.ID.ToString() + ".png"));
            try
            {
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                int a = 2;
            }
        }
    }
}
