using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITJobSeeker.Web.Startup))]
namespace ITJobSeeker.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
