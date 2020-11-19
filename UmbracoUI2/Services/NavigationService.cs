using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;
using UmbracoUI2.Models;

namespace UmbracoUI2.Services
{
    public class NavigationService : INavigationService
    {
        public NavigationsResultModel GetNavigations()
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            var pages = umbracoHelper.ContentAtRoot();
            List<NavigationListItem> result = new List<NavigationListItem>();
            if (pages != null)
            {
                var menuItems = ((DynamicPublishedContentList)pages).ToList();
                foreach (var item in menuItems)
                {
                    NavigationListItem rootNode = new NavigationListItem()
                    {
                        Link = new NavigationLink() { Url = item.Url, Text = item.Name },
                        Text = item?.Name
                    };
                    rootNode.Items = GetChildrenById(item.Id);
                    result.Add(rootNode);
                }
                //result = menuItems.Select(item => new NavigationListItem()
                //{
                //    Link = new NavigationLink() { Url = item?.Url, Text = item?.Name },
                //    Items = GetChildrenById(item?.Id)
                //}).ToList();
            }
            return new NavigationsResultModel() { Navigations = result };
        }

        /// <summary>
        /// Finds the home page and gets the navigation structure based on it and it's children
        /// </summary>
        /// <returns>A List of NavigationListItems, representing the structure of the site.</returns>
        private List<NavigationListItem> GetChildrenById(int? id)
        {
            List<NavigationListItem> nav = new List<NavigationListItem>();
            if (id != null)
            {
                var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
                IPublishedContent page = umbracoHelper.TypedContent(id);
                //nav.Add(new NavigationListItem(new NavigationLink(page.Url, page.Name)));
                var item = GetChildNavigationList(page);
                if (item != null)
                {
                    nav.AddRange(item);
                }
            }
            return nav;
        }

        /// <summary>
        /// Loops through the child pages of a given page and their children to get the structure of the site.
        /// </summary>
        /// <param name="page">The parent page which you want the child structure for</param>
        /// <returns>A List of NavigationListItems, representing the structure of the pages below a page.</returns>
        private List<NavigationListItem> GetChildNavigationList(IPublishedContent page)
        {
            List<NavigationListItem> listItems = /*null*/new List<NavigationListItem>(); ;
            var childPages = page.Children.Where(t => t.IsVisible());
            if (childPages != null && childPages.Any() && childPages.Count() > 0)
            {
                //listItems = new List<NavigationListItem>();
                foreach (var childPage in childPages)
                {
                    NavigationListItem listItem = new NavigationListItem(new NavigationLink(childPage.Url, childPage.Name), childPage?.Name);
                    listItem.Items = GetChildNavigationList(childPage);
                    listItems.Add(listItem);
                }
            }
            return listItems;
        }

    }
}