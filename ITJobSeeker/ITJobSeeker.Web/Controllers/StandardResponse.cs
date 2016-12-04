using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITJobSeeker.Web.Controllers
{
    public class StandardResponse
    {
        public int Status;

        public string Message;

        public StandardResponse()
        {
            Status = 0;
            Message = "";
        }
    }
}