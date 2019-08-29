using ADit.Interfaces;

namespace ADit.Domain.Services
{

    /// <summary>
    /// 
    /// </summary>
    public class CartService
    {

        /// <summary>
        /// The print repository
        /// </summary>
        private readonly IPrintRepository printRepository;
      
        private readonly IPrintFactory printFactory;
     
        private readonly IOnlineFactory onlineFactory;
       
        private readonly IOnlineRepository onlineRepository;
       
        private readonly ILookupRepository lookupRepository;
      
        private readonly ICartFactory cartFactory;

        public CartService(IPrintRepository printRepository, IPrintFactory printFactory,
            IOnlineFactory onlineFactory, IOnlineRepository onlineRepository,ILookupRepository lookupRepository)
        {
            this.lookupRepository = lookupRepository;
            this.printFactory = printFactory;
            this.onlineFactory = onlineFactory;
            this.onlineRepository = onlineRepository;
            this.printRepository = printRepository;
        }

       

    }
}
