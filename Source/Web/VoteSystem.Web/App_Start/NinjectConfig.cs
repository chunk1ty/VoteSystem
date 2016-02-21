[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VoteSystem.Web.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(VoteSystem.Web.NinjectConfig), "Stop")]

namespace VoteSystem.Web
{
    using System;
    using System.Data.Entity;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
   
    using VoteSystem.Common;
    using VoteSystem.Data;
    using VoteSystem.Data.Common;
    using VoteSystem.Services.Web;
    using VoteSystem.Services.Web.Contracts;

    public static class NinjectConfig
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IDbGenericRepository<>)).To(typeof(DbGenericRepository<>));

            // TODO check this binding IVoteSystemDbContext
            // InRequestScope for using one db context
            kernel.Bind(typeof(DbContext)).To(typeof(VoteSystemDbContext));
                                    //.InRequestScope();

            kernel.Bind(b => b.From(GlobalConstants.DataServicesAssembly)
                                    .SelectAllClasses()
                                    .BindDefaultInterface());

            // TODO bind the entire assembly
            kernel.Bind(typeof(ICacheService)).To(typeof(CacheService));
        }        
    }
}
