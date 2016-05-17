using DataAccess.Contract.Infrastructure;
using DataAccess.Implementation.Infrastructure;
using Ninject;

namespace EFHomeTask.DependencyInjection
{
    public static class IoCContainer
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}