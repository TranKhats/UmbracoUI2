using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoUI2.Models
{
    public class NavigationLinks
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool NewWindow { get; set; }
        public string Target { get { return NewWindow ? "_blank" : null; } }
        public string Title { get; set; }

        public NavigationLinks() { }

        public NavigationLinks(string url, string text = null, bool newWindow = false, string title = null)
        {
            Text = text;
            Url = url;
            NewWindow = newWindow;
            Title = title;
        }
    }

    public class NavigationListItems
    {
        public string Text { get; set; }
        public NavigationLinks Link { get; set; }
        public List<NavigationListItems> Items { get; set; }
        public bool HasChildren { get { return Items != null && Items.Any() && Items.Count > 0; } }

        public NavigationListItems() { }

        public NavigationListItems(NavigationLinks link)
        {
            Link = link;
        }

        public NavigationListItems(string text)
        {
            Text = text;
        }
    }
}