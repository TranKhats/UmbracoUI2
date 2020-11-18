using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using UmbracoUI2.Models;

namespace UmbracoUI2.Controlllers
{
    public class SiteLayoutController : SurfaceController
    {
        // GET: SiteLayout
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public const string VIEW_FOLDER_PATH = "~/Views/Partials/SiteLayout/";

        /// <summary>
        /// Renders the top navigation partial
        /// </summary>
        /// <returns>Partial view with a model</returns>
        public ActionResult RenderTopNavigation()
        {
            List<NavigationListItems> nav = GetNavigationModelFromDatabase();
            //return PartialView(VIEW_FOLDER_PATH + "_TopNavigation.cshtml", nav);  
            return PartialView("~/Views/Partials/_TopNavigation.cshtml", nav);
        }

        /// <summary>
        /// Finds the home page and gets the navigation structure based on it and it's children
        /// </summary>
        /// <returns>A List of NavigationListItems, representing the structure of the site.</returns>
        private List<NavigationListItems> GetNavigationModelFromDatabase()
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            IPublishedContent homePage = umbracoHelper.TypedContent(UmbracoContext.Current.PageId);



            //int homePageId = int.Parse(CurrentPage.Path.Split(',')[HOME_PAGE_POSITION_IN_PATH]);
            //IPublishedContent homePage = Umbraco.Content(homePageId);
            List<NavigationListItems> nav = new List<NavigationListItems>();

            var test =umbracoHelper.ContentAtRoot();
            var data = test.ToList()[0].Url;


            nav.Add(new NavigationListItems(new NavigationLinks(homePage.Url, homePage.Name)));

            nav.AddRange(GetChildNavigationList(homePage));
            return nav;
        }

        /// <summary>
        /// Loops through the child pages of a given page and their children to get the structure of the site.
        /// </summary>
        /// <param name="page">The parent page which you want the child structure for</param>
        /// <returns>A List of NavigationListItems, representing the structure of the pages below a page.</returns>
        private List<NavigationListItems> GetChildNavigationList(IPublishedContent page)
        {
            List<NavigationListItems> listItems = null;
            var childPages = page.Children.Where(t => t.IsVisible());
            if (childPages != null && childPages.Any() && childPages.Count() > 0)
            {
                listItems = new List<NavigationListItems>();
                foreach (var childPage in childPages)
                {
                    NavigationListItems listItem = new NavigationListItems(new NavigationLinks(childPage.Url, childPage.Name));
                    listItem.Items = GetChildNavigationList(childPage);
                    listItems.Add(listItem);
                }
            }
            return listItems;
        }
    }
}