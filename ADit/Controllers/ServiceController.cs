using ADit.Interfaces;
using System.Web.Mvc;

namespace ADit.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IRadioServices radioService;

       
        public ServiceController(IRadioServices radioService)
        {
            this.radioService = radioService;
        }

        // GET: Services
        
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Adds the radio.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRadio()
        {
            var viewModel = this.radioService.GetRadioTransactionView();

            return View("AddRadio", viewModel);
        }











    }
}