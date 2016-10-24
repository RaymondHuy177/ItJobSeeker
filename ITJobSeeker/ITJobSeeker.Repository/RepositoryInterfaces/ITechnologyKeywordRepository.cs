using ITJobSeeker.Model.Models;
using ITJobSeeker.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Repository.RepositoryInterfaces
{
    public interface ITechnologyKeywordRepository : IRepository<TechnologyKeyword>
    {
        TechnologyKeyword GetKeywordDetailByName(string name);
    }
}
