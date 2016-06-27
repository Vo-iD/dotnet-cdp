using System.Configuration;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Implementation.UnitsOfWork;
using Ninject;

namespace CargosService.WebApi.DependencyInjection
{
    public static class IoCContainer
    {
        public static void RegisterServices(IKernel kernel)
        {
            if (bool.Parse(ConfigurationManager.AppSettings["UseEntityFramework"]))
            {
                kernel.Bind<IUnitOfWork>().To<EfUnitOfWork>();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<AdoUnitOfWork>();
            }
        }
    }
}