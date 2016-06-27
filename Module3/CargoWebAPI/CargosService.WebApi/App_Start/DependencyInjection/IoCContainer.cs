using System.Configuration;
using CargosService.Business.Contract.Packaging;
using CargosService.Business.Implementation.Packaging;
using CargosService.Configuration.Contract.Settings;
using CargosService.Configuration.Implementation.Settings;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Implementation.UnitsOfWork;
using Ninject;

namespace CargosService.WebApi.DependencyInjection
{
    public static class IoCContainer
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IPackagingConfiguration>().To<PackagingConfiguration>();
            kernel.Bind<IPackagingService>().To<PackagingService>();

            ConfigurableServices(kernel);
        }

        private static void ConfigurableServices(IKernel kernel)
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