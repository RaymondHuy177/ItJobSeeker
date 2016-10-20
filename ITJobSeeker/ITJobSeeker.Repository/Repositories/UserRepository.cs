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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public User GetUserByEmail(string email)
        {
            var user = this.DbContext.Users.Where(n => n.Email == email).FirstOrDefault();
            return user;
        }
    }
}
