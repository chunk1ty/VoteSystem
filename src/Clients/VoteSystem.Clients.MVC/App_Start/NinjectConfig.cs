using System;
using System.Data.Entity;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;
using VoteSystem.Authentication;
using VoteSystem.Clients.MVC;
using VoteSystem.Common;
using VoteSystem.Common.Constants;
using VoteSystem.Data;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.Ef;
using VoteSystem.Data.Ef.Contracts;
using VoteSystem.Data.Ef.Repositories;
using VoteSystem.Services.Web;
using VoteSystem.Services.Web.Contracts;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectConfig), "Stop")]

namespace VoteSystem.Clients.MVC
{
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
            //kernel.Bind(typeof(IRepository<>))
            //    .To(typeof(Repository<>));
            //kernel.Bind(typeof(IDeletableRepository<>))
            //   .To(typeof(DeletableRepository<>));

            // TODO check this binding IVoteSystemDbContext
            // InRequestScope for using one db context
            //kernel.Bind(typeof(DbContext)).To(typeof(VoteSystemDbContext))
            //                        .InRequestScope();

            kernel.Bind<IVoteSystemDbContext>().To<VoteSystemDbContext>().InRequestScope();
            //Rebind(typeof(DbContext), typeof(IVoteSystemDbContext)).To<VoteSystemDbContext>().InRequestScope();

            kernel.Bind(b => b.From(GlobalConstants.DataServicesAssembly)
                                    .SelectAllClasses()
                                    .BindDefaultInterface());

            kernel.Bind<ISignInService>().ToMethod(_ => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>());
            kernel.Bind<IUserManagerService>().ToMethod(_ => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());

            // TODO bind the entire assembly
            kernel.Bind(typeof(ICacheService)).To(typeof(CacheService));
            kernel.Bind(typeof(IIdentifierProvider)).To(typeof(IdentifierProvider));
            kernel.Bind<IVoteSystemRepository>().To<EfVoteSystemRepository>();
        }        
    }
}
