using ITJobSeeker.Model.Models;
using ITJobSeeker.Repository.Infrastructure;
using ITJobSeeker.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Repository.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Company GetCompanyDetailByName(string name)
        {
            var company = this.DbContext.Companies.Where(n => n.Name == name).FirstOrDefault();
            return company;
        }
    }
}
