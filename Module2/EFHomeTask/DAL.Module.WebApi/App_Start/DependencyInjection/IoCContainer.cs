using DAL.Module.DataAccess.Contract.Infrastructure;
using DAL.Module.DataAccess.Implementation.UnitsOfWork;
using Ninject;

namespace DAL.Module.WebApi.DependencyInjection
{
    public static class IoCContainer
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}