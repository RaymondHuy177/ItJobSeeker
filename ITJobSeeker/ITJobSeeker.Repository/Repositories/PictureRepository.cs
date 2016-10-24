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
    public class PictureRepository : RepositoryBase<Picture>, IPictureRepository
    {
        public PictureRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Picture GetPictureDetailByName(string name)
        {
            var picture = this.DbContext.Pictures.Where(n => n.Name == name).FirstOrDefault();
            return picture;
        }
    }
}
