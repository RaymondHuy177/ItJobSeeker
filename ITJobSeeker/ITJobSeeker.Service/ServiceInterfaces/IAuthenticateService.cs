using ITJobSeeker.Service.Common;
using ITJobSeeker.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Service.ServiceInterfaces
{
    public interface IAuthenticateService
    {
        User Login(string username, string password);

        Account CreateAccountSession(User user);
    }
}
