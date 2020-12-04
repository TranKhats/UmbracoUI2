using IServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using umbraco.interfaces;
using UmbracoUI2.Helpers;
using UmbracoUI2.Services;
using UmbracoUI2.Web.Constants;


namespace UmbracoUI2.Controlllers
{
    public class NavigationController : Controller
    {
        private INavigationService _navigationService;
        ICacheRefresher _cacheRefresher;

        public NavigationController(INavigationService navigationService/*, ICacheRefresher cacheRefresher*/)
        {
            this._navigationService = navigationService;
            //this._cacheRefresher = cacheRefresher;
        }

        // GET: Navigation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetNavigationMenu()
        {
            //_cacheRefresher.RefreshAll();
            var languageCookie = HttpContext.Request.Cookies[UmbracoUI2Constants.LanguagesCookieKey];
            var language = string.Empty;
            if (languageCookie?.Value == null)
            {
                language = UmbracoUI2Constants.Languages.First().Value;
                UmbracoUI2Helper.SetCookie(Response, language);
                //HttpCookie cookie = new HttpCookie(UmbracoUI2Constants.LanguagesCookieKey);
                //cookie.Value = language;
                //cookie.Expires = DateTime.Now.AddDays(30);
                //Response.SetCookie(cookie);
            }
            else
            {
                language = languageCookie.Value;
            }
            //var language = languageCookie?.Value == null ? UmbracoUI2Constants.Languages.First().Value : languageCookie.Value;
            var menu = _navigationService.GetNavigations(language);
            return PartialView("~/Views/Partials/_TopNavigation.cshtml", menu);
        }
    }
}