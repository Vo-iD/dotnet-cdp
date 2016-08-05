using System.Configuration;
using CargosService.Business.Contract.Packaging;
using CargosService.Business.Implementation.Packaging;
using CargosService.Configuration.Contract.Settings;
using CargosService.Configuration.Implementation.Settings;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Contract.Models;
using CargosService.DataAccess.Implementation.Repositories.EntityFrameworkRepositories;
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
            kernel.Bind<IPackagingManager>().To<PackagingManager>();
            kernel.Bind<IFullRepository<Cargo>>().To<GenericRepository<Cargo>>();

            ConfigurableServices(kernel);
        }

        private static void ConfigurableServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}