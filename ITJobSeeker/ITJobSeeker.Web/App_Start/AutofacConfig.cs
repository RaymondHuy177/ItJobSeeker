using Autofac;
using Autofac.Integration.Mvc;
using ITJobSeeker.Repository.Infrastructure;
using ITJobSeeker.Repository.Repositories;
using ITJobSeeker.Repository.RepositoryInterfaces;
using ITJobSeeker.Service.ServiceImpl;
using ITJobSeeker.Service.ServiceInterfaces;
using System.Reflection;
using System.Web.Mvc;

namespace ITJobSeeker.Web.App_Start
{
    public class AutofacConfig
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<JobService>().As<IJobService>().InstancePerRequest();

            builder.RegisterType<JobRepository>().As<IJobRepository>().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}