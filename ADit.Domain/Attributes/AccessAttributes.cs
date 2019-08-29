using AA.Infrastructure.Interfaces;
using AA.Infrastructure.Providers;
using AA.Infrastructure.Services;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using ADit.Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ADit.Domain.Attributes
{
    public sealed class AccessAuthorize : AuthorizeAttribute
    {
        private static ISessionStateProvider sessionStateProvider;
        private static ISessionStateService session;
        private static IAccountRepository accountRepository;

        /// <summary>
        /// When overridden, provides an entry point for custom authorization checks.
        /// </summary>
        /// <param name="httpContext">The HTTP context, which encapsulates all HTTP-specific information about an individual HTTP request.</param>
        /// <returns>
        /// true if the user is authorized; otherwise, false.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">httpContext</exception>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            var isGranted = false;

            sessionStateProvider = new SessionStateProvider();
            session = new SessionStateService(sessionStateProvider);
            accountRepository = new AccountRepository();

            var userId = (session.GetSessionValue(SessionKey.UserId) ?? "").ToString().ToString();
            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }

            var theRolesAsStored = session.GetSessionValue(SessionKey.UserRoles);
            var roleCollection = theRolesAsStored != null ? ((string[])theRolesAsStored).ToList() : new List<string>();
            var roleCollectionToUpper = roleCollection.Select(role => role.ToUpper()).ToList();

            foreach (var role in Roles)
            {
                isGranted = roleCollectionToUpper.Contains(role.ToUpper());
                if (isGranted)
                {
                    var theAction = role.ToUpper();
                    accountRepository.LogUserAction(userId, theAction, true);
                    break;
                }
            }
            if (isGranted)
            {
                return true;
            }

            //log all action when action is not granted
            foreach (var role in Roles)
            {
                accountRepository.LogUserAction(userId, role, false);
            }

            return false;
        }

        /// <summary>
        /// Processes HTTP requests that fail authorization.
        /// </summary>
        /// <param name="filterContext">Encapsulates the information for using <see cref="T:System.Web.Mvc.AuthorizeAttribute" />.
        ///  The <paramref name="filterContext" /> object contains the controller, HTTP context, request context, action result, and route data.
        /// </param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "Error",
                action = "AccessDenied",
                page = url
            }));

            base.HandleUnauthorizedRequest(filterContext);
        }

        /// <summary>
        /// Gets or sets the user roles.
        /// </summary>
        public new string[] Roles
        {
            get { return base.Roles.Split(','); }
            set { base.Roles = string.Join(",", value); }
        }
    }
}
