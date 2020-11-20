using IServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmbracoUI2.Services;

namespace UmbracoDI2.Services
{
    public abstract class UmbracoTemplatePage : Umbraco.Web.Mvc.UmbracoTemplatePage
    {
        public ISearchService _searchingServices { get; set; }
    }
}