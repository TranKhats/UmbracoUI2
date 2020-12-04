using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UmbracoUI2.Helpers;
using UmbracoUI2.Web.Constants;

namespace UmbracoUI2.Controlllers
{
    public class FormsController : Controller
    {
        // GET: Forms
        public ActionResult Index()
        {
            return View();
            //return CurrentTemplate(5);

        }

        [HttpPost]
        public ActionResult SwitchLanguage(string language = null)
        {
            //HttpCookie cookie = new HttpCookie(UmbracoUI2Constants.LanguagesCookieKey);
            if (string.IsNullOrEmpty(language))
            {
                language = UmbracoUI2Constants.Languages.FirstOrDefault().Value;
            }
            var previousLanguage = HttpContext.Request.Cookies[UmbracoUI2Constants.LanguagesCookieKey].Value;
            if (previousLanguage.Trim().ToLower() != language.Trim().ToLower())
            {
                UmbracoUI2Helper.SetCookie(Response, language);
            }
            //cookie.Value = language;
            //cookie.Expires = DateTime.Now.AddDays(30);
            //Response.SetCookie(cookie);
            var result = new { status = true, expiredDay = 30, language,previousLanguage };
            return Json(result);
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View("~/Views/SearchResult.cshtml");
        }
    }
}