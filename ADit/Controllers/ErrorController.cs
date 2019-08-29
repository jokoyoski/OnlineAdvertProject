using System.Web.Mvc;

namespace ADit.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return this.View("Error");
        }

        /// <summary>
        /// Accesses the denied.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult AccessDenied(string page)
        {
            this.ViewBag.ThePage = page;

            return this.View("AccessDenied");
        }
    }
}