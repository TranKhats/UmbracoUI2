using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoUI2.Models
{
    public class SearchResultsModel
    {
        public IEnumerable<NodeResultItemModel> ListNode { get; set; }
    }

    public class NodeResultItemModel
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }
}