﻿using ITJobSeeker.Model.Models;
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
        private readonly IUnitOfWork unitOfWork;

        public static int JobsPerPage = 20;

        public JobService(IJobRepository _jobRepository, IUnitOfWork _unitOfWork)
        {
            this.jobRepository = _jobRepository;
            this.unitOfWork = _unitOfWork;
        }
        public IEnumerable<Job> GetJobsByPage(int page = 1)
        {
            var listJobs = jobRepository.GetAll();
            int skipJobs = (page - 1) * JobsPerPage;
            int jobsRemain = listJobs.Count() - skipJobs;
            if (jobsRemain > JobsPerPage)
                return listJobs.Skip(skipJobs).Take(JobsPerPage);
            return listJobs.Skip(skipJobs).Take(jobsRemain);
        }
    }
}
