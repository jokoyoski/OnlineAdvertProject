using ADit.Interfaces;
using ADit.Repositories.Services;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ADit.DI.Windsor.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(
               Component.For(typeof(IAccountRepository))
                   .ImplementedBy(typeof(AccountRepository))
                   .Named("AccountRepository")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));
            container.Register(
              Component.For(typeof(IOrderRepository))
                  .ImplementedBy(typeof(OrderRepository))
                  .Named("OrderRepository")
                  .LifeStyle.Is(LifestyleType.PerWebRequest));
            container.Register(
             Component.For(typeof(ILookupRepository))
                 .ImplementedBy(typeof(LookupRepository))
                 .Named("LookupRepository")
                 .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
              Component.For(typeof(IGeneralRepository))
                  .ImplementedBy(typeof(GeneralRepository))
                  .Named("GeneralRepository")
                  .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
              Component.For(typeof(IRadioRepository))
                  .ImplementedBy(typeof(RadioRepository))
                  .Named("ServicesRepository")
                  .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
              Component.For(typeof(ITvRepository))
                  .ImplementedBy(typeof(TvRepostiory))
                  .Named("TvRepository")
                  .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
             Component.For(typeof(IFulfilmentRepository))
                 .ImplementedBy(typeof(FulfilmentRepository))
                 .Named("FulfilmentRepository")
                 .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
             Component.For(typeof(IScriptingRepository))
                 .ImplementedBy(typeof(ScriptingRepository))
                 .Named("ScriptingRepository")
                 .LifeStyle.Is(LifestyleType.PerWebRequest));



            container.Register(
              Component.For(typeof(IBrandingRepository))
                  .ImplementedBy(typeof(BrandingRepository))
                  .Named("BrandingRepository")
                  .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
             Component.For(typeof(IDigitalFileRepository))
                 .ImplementedBy(typeof(DigitalFileRepository))
                 .Named("DigitalFileRepository")
                 .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
              Component.For(typeof(IPrintRepository))
                  .ImplementedBy(typeof(PrintRepository))
                  .Named("PrintRepository")
                  .LifeStyle.Is(LifestyleType.PerWebRequest));








            container.Register(
         Component.For(typeof(IOnlineRepository))
             .ImplementedBy(typeof(OnlineRepository))
             .Named("OnlineRepository")
             .LifeStyle.Is(LifestyleType.PerWebRequest));
        }
    }
}