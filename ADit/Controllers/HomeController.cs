using System;
using System.Web.Mvc;
using AA.Infrastructure.Interfaces;
using ADit.Domain.Models;
using ADit.Interfaces;

namespace ADit.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILookupService lookupService;


        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="lookupService">The lookup service.</param>
        public HomeController(ILookupService lookupService)
        {
            this.lookupService = lookupService;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()

        {
            return View("Index");
        }

        /// <summary>
        /// Ours the story.
        /// </summary>
        /// <returns></returns>
        public ActionResult OurStory()
        {
            return View("OurStory");
        }

        /// <summary>
        /// Hows to use.
        /// </summary>
        /// <returns></returns>
        public ActionResult HowToUse()
        {
            return View("HowToUse");
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View("About");
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Contact()
        {
            var contactView = this.lookupService.GetContactView();
            return View("Contact",contactView);
        }

        /// <summary>
        /// Contacts the specified contact view.
        /// </summary>
        /// <param name="contactView">The contact view.</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactView contactView)
        {
            if (contactView == null)
            {
                throw new ArgumentNullException(nameof(contactView));
            }
            this.lookupService.SendContactMail(contactView);

            return RedirectToAction("Login", "Account", new {infoMessage = "We will contact you shortly"});
        }

        /// <summary>
        /// Helps this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Help()
        {
            return View("Help");
        }
    }
}