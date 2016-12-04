using ITJobSeeker.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Service.ServiceInterfaces
{
    public interface ITechnologyKeywordService
    {
        IEnumerable<TechnologyKeyword> GetTechnologyKeywords(string name = null);

        IEnumerable<TechnologyKeyword> GetAllKeywords();

        TechnologyKeyword GetTechnologyKeyWord(Guid id);

        TechnologyKeyword GetTechnologyKeyword(string name);
    }
}
