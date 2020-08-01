[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BusTicketBookingSystem.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BusTicketBookingSystem.App_Start.NinjectWebCommon), "Stop")]

namespace BusTicketBookingSystem.App_Start
{
    using System;
    using System.Web;
    using BusTicketBookingSystem.Repository.Interfaces;
    using BusTicketBookingSystem.Repository.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
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

                kernel.Bind<IBusRepository>().To<BusRepository>();
                kernel.Bind<ICityRepository>().To<CityRepository>();
                kernel.Bind<IReservationsRepository>().To<ReservationsRepository>();
                kernel.Bind<IToursRepository>().To<ToursRepository>();
                kernel.Bind<IDriversRepository>().To<DriversRepository>();
                kernel.Bind<IFeedbackRepository>().To<FeedbackRepository>();

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
        }        
    }
}
