using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Repository.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        ItJobSeekerEntities dbContext;

        public ItJobSeekerEntities Init()
        {
            return dbContext ?? (dbContext = new ItJobSeekerEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
