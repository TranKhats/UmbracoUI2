using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoUI2.Models
{
    public class NavigationsResultModel
    {
        public IEnumerable<NavigationListItem> Navigations;
    }

    //public class RootMenuItem
    //{
    //    public string Url { get; set; }
    //    public string Name { get; set; }
    //    public bool HasChildren { get; set; }
    //    public List<MenuItem> Children { get; set; }
    //}
    //public class MenuItem
    //{
    //    public string Url { get; set; }
    //    public string Name { get; set; }
    //    public bool HasChildren { get; set; }
    //}


    public class NavigationLink
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool NewWindow { get; set; }
        public string Target { get { return NewWindow ? "_blank" : null; } }
        public string Title { get; set; }

        public NavigationLink()
        { }

        public NavigationLink(string url, string text = null, bool newWindow = false, string title = null)
        {
            Text = text;
            Url = url;
            NewWindow = newWindow;
            Title = title;
        }
    }
    public class NavigationListItem
    {
        public string Text { get; set; }
        public NavigationLink Link { get; set; }
        public List<NavigationListItem> Items { get; set; }
        public bool HasChildren { get { return Items != null && Items.Any() && Items.Count > 0; } }

        public NavigationListItem()
        { }

        public NavigationListItem(NavigationLink link)
        {
            Link = link;
        }

        public NavigationListItem(string text)
        {
            Text = text;
        }
    }
}