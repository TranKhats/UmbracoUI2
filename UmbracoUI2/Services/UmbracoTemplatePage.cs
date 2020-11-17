using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmbracoUI2.Services;

namespace UmbracoDI2.Services
{
    public abstract class UmbracoTemplatePage : Umbraco.Web.Mvc.UmbracoTemplatePage
    {
        public INumber _numberServices { get; set; }
        public ISearchService _searchingServices { get; set; }
    }
}