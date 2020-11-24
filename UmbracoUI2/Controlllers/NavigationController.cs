using IServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UmbracoUI2.Services;
using UmbracoUI2.Web.Constants;


namespace UmbracoUI2.Controlllers
{
    public class NavigationController : Controller
    {
        private INavigationService _navigationService;

        public NavigationController(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        // GET: Navigation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetNavigationMenu()
        {
            var language = HttpContext.Request.Cookies[UmbracoUI2Constants.LanguagesCookieKey];
            var menu = _navigationService.GetNavigations(language.Value);
            return PartialView("~/Views/Partials/_TopNavigation.cshtml", menu);
        }
    }
}