using System.Web;
using System.Web.Http;
using EFHomeTask.DependencyInjection;
using Ninject;

namespace EFHomeTask
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var kernel = new StandardKernel();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
            AutomapperConfiguration.CreateMappings();
        }
    }
}
