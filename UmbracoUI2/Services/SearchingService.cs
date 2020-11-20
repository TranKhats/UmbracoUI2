using System.Linq;
using UmbracoUI2.Models;
using Examine.LuceneEngine.SearchCriteria;
using Umbraco.Web;
using IServices.IServices;
using Dtos.Models;

namespace UmbracoUI2.Services
{
    public class SearchingService : ISearchService
    {
        public SearchResultsModel Search(string query)
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);

            var searcher = Examine.ExamineManager.Instance.SearchProviderCollection["ExternalSearcher"];

            var searchCriteria = searcher.CreateSearchCriteria(Examine.SearchCriteria.BooleanOperation.Or);
            var searchQuery = searchCriteria.Field("nodeName", query.Boost(5)).Or().Field("nodeName", query.Fuzzy()).And().Field("__IndexType", "content").And().OrderByDescending("createDate");
            var searchResults = searcher.Search(searchQuery.Compile());
            //foreach (var item in searchResults.ToList())
            //{
            //    var node = umbracoHelper.TypedMedia(item.Id);
            //}
            var resultNodeItems = searchResults.Select(t => new NodeResultItemModel()
            {
                Name = umbracoHelper.TypedContent(t.Id)?.Name,
                Url = umbracoHelper.TypedContent(t.Id)?.Url,
                Id = t.Id.ToString()
            });
            return new SearchResultsModel() { ListNode = resultNodeItems };
        }
    }
}