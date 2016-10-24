using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJobSeeker.Repository.RepositoryInterfaces;
using ITJobSeeker.Repository.Infrastructure;
using ITJobSeeker.Model.Models;

namespace ITJobSeeker.Repository.Repositories
{
    public class TechnologyKeywordRepository : RepositoryBase<TechnologyKeyword>, ITechnologyKeywordRepository
    {
        public TechnologyKeywordRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public TechnologyKeyword GetKeywordDetailByName(string name)
        {
            var keyword = this.DbContext.TechnologyKeywords.Where(n => n.Name == name).FirstOrDefault();
            return keyword;
        }
    }
}
