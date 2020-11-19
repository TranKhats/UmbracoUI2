using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UmbracoUI2.Services;

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
            var menu = _navigationService.GetNavigations();
            return PartialView("~/Views/Partials/_TopNavigation.cshtml", menu);
        }
    }
}