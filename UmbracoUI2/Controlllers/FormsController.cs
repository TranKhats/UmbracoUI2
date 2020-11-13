using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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


        [HttpGet]
        public ActionResult Search()
        {
            return View("~/Views/SearchResult.cshtml");
        }
    }
}