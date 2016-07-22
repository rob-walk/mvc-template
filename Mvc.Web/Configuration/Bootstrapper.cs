using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Mvc.Web.Modules;

namespace Mvc.Web.Configuration
{
    public class Bootstrapper
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(new Config())
                .SingleInstance()
                .AsImplementedInterfaces();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            RegisterAllModules(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        private static void RegisterAllModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new LoggingModule());

            builder.RegisterModule(new DataAccessModule());

            builder.RegisterModule(new ServicesModule());
        }
    }
}