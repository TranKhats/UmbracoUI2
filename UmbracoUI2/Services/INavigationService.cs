using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmbracoUI2.Models;

namespace UmbracoUI2.Services
{
    public interface INavigationService
    {
        NavigationsResultModel GetNavigations();
    }
}