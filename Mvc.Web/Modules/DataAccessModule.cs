using Autofac;
using Mvc.Common.DataAccess;

namespace Mvc.Web.Modules
{
    public class DataAccessModule : Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AnyDbContext>().As<IAnyDbContext>()
                   .WithParameter(new NamedParameter("connectionString", ConnectionString))
                   .InstancePerRequest()
                   .AsImplementedInterfaces();
        }
    }
}