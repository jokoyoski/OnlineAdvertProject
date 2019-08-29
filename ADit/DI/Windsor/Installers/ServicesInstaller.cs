using AA.Infrastructure.Interfaces;
using AA.Infrastructure.Providers;
using AA.Infrastructure.Services;
using AA.Infrastructure.Utility;
using ADit.Domain.Services;
using ADit.Interfaces;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ADit.DI.Windsor.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IEnvironment))
                    .ImplementedBy(typeof(Environment))
                    .Named("Environment")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IEmail))
                    .ImplementedBy(typeof(Email))
                    .Named("Email")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ISessionStateProvider))
                    .ImplementedBy(typeof(SessionStateProvider))
                    .Named("SessionStateProvider")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IFulfilmentService))
                    .ImplementedBy(typeof(FulfilmentService))
                    .Named("FulfilmentService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ISessionStateService))
                    .ImplementedBy(typeof(SessionStateService))
                    .Named("SessionStateService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IFormsAuthenticationService))
                    .ImplementedBy(typeof(FormsAuthenticationService))
                    .Named("FormsAuthenticationService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAccountService))
                    .ImplementedBy(typeof(AccountService))
                    .Named("AccountService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));
            container.Register(
               Component.For(typeof(IOrderServices))
                   .ImplementedBy(typeof(OrderServices))
                   .Named("OrderServices")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAesEncryption))
                    .ImplementedBy(typeof(AesEncryption))
                    .Named("AesEncryption")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));
            container.Register(
               Component.For(typeof(ILookupService))
                   .ImplementedBy(typeof(LookupServices))
                   .Named("LookupServices")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));
            container.Register(
               Component.For(typeof(IBrandingService))
                   .ImplementedBy(typeof(BrandingService))
                   .Named("BrandingService")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));
            container.Register(
                Component.For(typeof(IScriptingService))
                    .ImplementedBy(typeof(ScriptingService))
                    .Named("ScriptingService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

          

            container.Register(
                 Component.For(typeof(ITvServices))
                     .ImplementedBy(typeof(TvServices))
                     .Named("TvServices")
                     .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IGeneralService))
                    .ImplementedBy(typeof(GeneralService))
                    .Named("GeneralService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IRadioServices))
                    .ImplementedBy(typeof(RadioServices))
                    .Named("RadioServices")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IPrintService))
                    .ImplementedBy(typeof(PrintService))
                    .Named("PrintService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
             Component.For(typeof(IDigitalFileServices))
                 .ImplementedBy(typeof(DigitalServices))
                 .Named("DigitalServices")
                 .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
               Component.For(typeof(IOnlineServices))
                   .ImplementedBy(typeof(OnlineService))
                   .Named("OnlineService")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ITransactionService))
                    .ImplementedBy(typeof(TransactionService))
                    .Named("TransactionService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));
        }
    }
}