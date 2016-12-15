using ITJobSeeker.Model.Models;
using ITJobSeeker.Repository.Infrastructure;
using ITJobSeeker.Repository.RepositoryInterfaces;
using ITJobSeeker.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Service.ServiceImpl
{
    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IUnitOfWork unitOfWork;

        public static int JobsPerPage = 20;

        public JobService(IJobRepository _jobRepository, IUnitOfWork _unitOfWork, ICompanyRepository _companyRepository)
        {
            this.jobRepository = _jobRepository;
            this.unitOfWork = _unitOfWork;
            this.companyRepository = _companyRepository;
        }
        public IEnumerable<Job> GetJobsByPage(int page = 1)
        {
            var listJobs = jobRepository.GetJobsWithCompany();
            int skipJobs = (page - 1) * JobsPerPage;
            int jobsRemain = listJobs.Count() - skipJobs;
            if (jobsRemain > JobsPerPage)
                return listJobs.Skip(skipJobs).Take(JobsPerPage);
            return listJobs.Skip(skipJobs).Take(jobsRemain);
        }
        public Job GetDetailJob(Guid id)
        {
            Job job = jobRepository.GetById(id);
            Company company = companyRepository.GetById(job.CompanyID);
            job.Comapny = company;
            return job;
        }

        public void AddJob(Job job)
        {
            jobRepository.Add(job);
            unitOfWork.Commit();
        }

        public IEnumerable<Job> GetJobsByRecruiter(Guid RecruiterID)
        {
            return jobRepository.GetMany(j => j.CompanyID == RecruiterID);
        }

        public void EditJob(Job job)
        {
            Job editJob = jobRepository.GetById(job.ID);
            editJob.Benefits = job.Benefits;
            editJob.Description = job.Description;
            editJob.SmallDescription = job.SmallDescription;
            editJob.FirstTechStack = job.FirstTechStack;
            editJob.SecondTechStack = job.SecondTechStack;
            editJob.ThirdTechStack = job.ThirdTechStack;
            editJob.Name = job.Name;
            editJob.IsActive = false;
            editJob.Requirement = job.Requirement;
            editJob.Salary = job.Salary;
            unitOfWork.Commit();
        }

        public void SaveJob()
        {
            unitOfWork.Commit();
        }

        public void DeleteJob(Job job)
        {
            jobRepository.Delete(job);
            unitOfWork.Commit();
        }

        public List<Job> Filter(string keyword, string location)
        {
            IEnumerable<Job> jobs =
                jobRepository.GetMany(j => j.FirstTechStack.Contains(keyword)
                                || j.SecondTechStack.Contains(keyword)
                                || j.ThirdTechStack.Contains(keyword)
                                || j.Name.Contains(keyword));
            IEnumerable<Company> companies = companyRepository.GetAll();
            List<Job> result = new List<Job>();
            foreach (var job in jobs)
            {
                foreach (var company in companies)
                {
                    if (company.Location == location)
                    {
                        result.Add(job);
                    }
                }
            }
            return result;
        }
    }
}
