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
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<ConstraintService>().As<IConstraintService>().InstancePerRequest();
            builder.RegisterType<TechnologyKeywordService>().As<ITechnologyKeywordService>().InstancePerRequest();
            builder.RegisterType<AuthenticateService>().As<IAuthenticateService>().InstancePerRequest();

            builder.RegisterType<JobRepository>().As<IJobRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>().InstancePerRequest();
            builder.RegisterType<TechnologyKeywordRepository>().As<ITechnologyKeywordRepository>().InstancePerRequest();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}