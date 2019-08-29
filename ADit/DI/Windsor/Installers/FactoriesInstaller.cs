using Castle.MicroKernel.Registration;
using Castle.Core;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ADit.Interfaces;
using ADit.Repositories.Factories;
using ADit.Domain.Factories;
namespace ADit.DI.Windsor.Installers
{
    public class FactoriesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IDbContextFactory))
                    .ImplementedBy(typeof(DbContextFactory))
                    .Named("DbContextFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));



            container.Register(
                Component.For(typeof(IAccountViewsModelFactory))
                    .ImplementedBy(typeof(AccountViewsModelFactory))
                    .Named("AccountViewsModelFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IEmailFactory))
                    .ImplementedBy(typeof(EmailFactory))
                    .Named("EmailFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));
            container.Register(
                Component.For(typeof(IFulfilmentFactory))
                    .ImplementedBy(typeof(FulfilmentFactory))
                    .Named("FulfilmentFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
               Component.For(typeof(IBrandingFactory))
                   .ImplementedBy(typeof(BrandingFactory))
                   .Named("BrandingFactory")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
               Component.For(typeof(IMessageFactory))
                   .ImplementedBy(typeof(MessageFactory))
                   .Named("MessageFactory")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));



            container.Register(
               Component.For(typeof(IGeneralFactory))
                   .ImplementedBy(typeof(GeneralFactory))
                   .Named("LookupFactory")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
              Component.For(typeof(IScriptingFactory))
                  .ImplementedBy(typeof(ScriptingFactory))
                  .Named("ScriptingFactory")
                  .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IOnlineFactory))
                    .ImplementedBy(typeof(OnlineFactory))
                    .Named("OnlineFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));



            container.Register(
                Component.For(typeof(IRadioViewsModelFactory))
                    .ImplementedBy(typeof(RadioViewsModelFactory))
                    .Named("RadioViewsModelFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(ITvFactory))
                    .ImplementedBy(typeof(TvFactory))
                    .Named("ITvFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IPrintFactory))
                    .ImplementedBy(typeof(PrintFactory))
                    .Named("PrintFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


          
 container.Register(
                Component.For(typeof(IOrderSummaryFactory))
                    .ImplementedBy(typeof(OrderSummaryFactory))
                    .Named("OrderSummaryFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


          




        }
    }
}