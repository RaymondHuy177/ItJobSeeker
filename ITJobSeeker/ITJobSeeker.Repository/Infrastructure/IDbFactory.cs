using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Repository.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ItJobSeekerEntities Init();
    }
}
