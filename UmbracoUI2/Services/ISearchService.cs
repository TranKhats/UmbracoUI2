using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using UmbracoUI2.Models;

namespace UmbracoUI2.Services
{
    public interface ISearchService
    {
        SearchResultsModel Search(string query);
    }
}
