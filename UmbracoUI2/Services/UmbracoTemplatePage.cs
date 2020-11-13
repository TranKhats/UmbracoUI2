using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoDI2.Services
{
    public abstract class UmbracoTemplatePage : Umbraco.Web.Mvc.UmbracoTemplatePage
    {
        public INumber _numberServices { get; set; }
    }
}