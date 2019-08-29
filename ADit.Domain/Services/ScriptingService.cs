using ADit.Interfaces;
using System;

namespace ADit.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IScriptingService" />
    public class ScriptingService : IScriptingService
    {

        private readonly IOrderRepository orderRepository;
        private readonly IRadioRepository radioRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly IFulfilmentFactory fulfilmentFactory;
        private readonly IScriptingFactory scriptingFactory;

        public ScriptingService(IOrderRepository orderRepository, IRadioRepository radioRepository, ILookupRepository lookupRepository, IScriptingFactory scriptingFactory, IFulfilmentFactory fulfilmentFactory)
        {
            this.orderRepository = orderRepository;
            this.radioRepository = radioRepository;
            this.lookupRepository = lookupRepository;
            this.scriptingFactory = scriptingFactory;
            this.fulfilmentFactory = fulfilmentFactory;
        }


        /// <summary>
        /// Gets the script radio order view.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns>IRadioMainView.</returns>
        public IRadioMainView GetScriptRadioOrderView(int orderFulfilmentId, string message)
        {
            var orderInFulfilment = orderRepository.GetOrderFulfilmentById(orderFulfilmentId);

            if (orderInFulfilment == null)
            {
                throw new ArgumentNullException(nameof(orderInFulfilment));
            }

            //Get Radio Order
            var radioOrder = radioRepository.GetUserRadioOrderById(orderInFulfilment.ServiceTransactionId);
            
            //Get Only Active Material Type For Radio
            var activeMaterialType = lookupRepository.GetActiveMaterialTypeForRadio();

            var orderFulfilmentStatus = orderRepository.GetFulfilmentStatuses(orderInFulfilment.FufilmentStatusCode);

            //Get Radio Airing Details
            var radioAiringDetails = radioRepository.GetRadioTransactionAiring(radioOrder.RadioTransactionId);

            var viewModel = this.fulfilmentFactory.GetFulfilmentTransaction(radioOrder, activeMaterialType, radioAiringDetails,
                orderFulfilmentStatus, orderInFulfilment.FufilmentStatusCode, orderInFulfilment.FufilmentStatusDescription,
                orderInFulfilment.OrderFulfilmentId, message);

            return viewModel;
        }



    }
}
