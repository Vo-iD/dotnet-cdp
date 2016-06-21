using System.Web;
using System.Web.Http;
using DAL.Module.WebApi.DependencyInjection;
using Ninject;

namespace DAL.Module.WebApi
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
