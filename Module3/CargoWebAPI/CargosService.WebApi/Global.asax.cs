using System.Web;
using System.Web.Http;
using CargosService.DataAccess.Implementation.UnitsOfWork;
using CargosService.WebApi.Controllers;
using CargosService.WebApi.DependencyInjection;
using Ninject;

namespace CargosService.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var kernel = new StandardKernel();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
            AutomapperConfiguration.CreateMappings();
            var c = new CargosController(new EfUnitOfWork());
        }
    }
}
