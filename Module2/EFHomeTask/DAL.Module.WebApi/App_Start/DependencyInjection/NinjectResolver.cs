using System.Web.Http.Dependencies;
using Ninject;

namespace DAL.Module.WebApi.DependencyInjection
{
    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
            IoCContainer.RegisterServices(_kernel);
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }
}