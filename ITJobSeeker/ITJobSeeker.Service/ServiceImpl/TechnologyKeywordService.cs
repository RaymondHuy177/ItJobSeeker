using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJobSeeker.Service.ServiceInterfaces;
using ITJobSeeker.Repository.RepositoryInterfaces;
using ITJobSeeker.Repository.Infrastructure;
using ITJobSeeker.Model.Models;

namespace ITJobSeeker.Service.ServiceImpl
{
    public class TechnologyKeywordService : ITechnologyKeywordService
    {
        private readonly ITechnologyKeywordRepository techkeywordsRepository;
        private readonly IUnitOfWork unitOfWork;

        public TechnologyKeywordService(ITechnologyKeywordRepository _techkeywordsRepository, IUnitOfWork _unitOfWork)
        {
            this.techkeywordsRepository = _techkeywordsRepository;
            this.unitOfWork = _unitOfWork;
        }

        public IEnumerable<TechnologyKeyword> GetAllKeywords()
        {
            return techkeywordsRepository.GetAll();
        }

        public TechnologyKeyword GetTechnologyKeyword(string name)
        {
            var techKeyword = techkeywordsRepository.GetKeywordDetailByName(name);
            return techKeyword;
        }

        public TechnologyKeyword GetTechnologyKeyWord(Guid id)
        {
            var techKeyword = techkeywordsRepository.GetById(id);
            return techKeyword;
        }

        public IEnumerable<TechnologyKeyword> GetTechnologyKeywords(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return techkeywordsRepository.GetAll();
            else
                return techkeywordsRepository.GetAll().Where(k => k.Name == name);
        }
    }
}
