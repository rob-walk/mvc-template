using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Mvc.Common.Service;
using Mvc.Web.Configuration;

namespace Mvc.Web
{
    public class MvcApplication : HttpApplication
    {
        private static IContainer _container;
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();

            Bootstrap();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error()
        {
            Response.TrySkipIisCustomErrors = true;

            var exception = Server.GetLastError();

            if (exception == null)
                return;

            do
            {
                var appService = _container.Resolve<IAppService>();

                appService.Log.Fatal(exception.Message, exception);

                exception = exception.InnerException;
            } while (exception != null);

            Server.ClearError();

            Server.Transfer("~/500.aspx");
        }

        private static void Bootstrap()
        {
            var bootstrap = new Bootstrapper();

            _container = bootstrap.BuildContainer();
        }

        private static void CreateMaps()
        {
        }
    }
}
