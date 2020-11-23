using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Our.Umbraco.Ditto;
using Our.Umbraco.Vorto.Extensions;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace UmbracoUI2.Web.Extensions
{
    public static class PublishedContentExtensions
    {
        public static IList<IPublishedContent> LoadNodesFromMultinodePicker(this IPublishedContent content, string propertyAlias)
        {
            var topNavigationItems = new List<IPublishedContent>();

            if (content != null)
            {
                var items = content.GetPropertyValue<string>(propertyAlias);

                foreach (var item in items.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    int nodeId;
                    if (int.TryParse(item, out nodeId))
                    {
                        var node = UmbracoContext.Current.ContentCache.GetById(nodeId);

                        if (node != null)
                        {
                            topNavigationItems.Add(node);
                        }
                    }
                }
            }

            return topNavigationItems;
        }

        public static IEnumerable<int> GetPropertyValueIds(this IPublishedContent content, string propertyAlias)
        {
            return content?.GetPropertyValue<string>(propertyAlias)
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }

        public static bool CompareVortoValue(this IPublishedContent content, string propertyAlias, string value)
        {
            if (content.HasVortoValue(propertyAlias))
            {
                var vortoValue = content.TryGetVortoValue<string>(propertyAlias);
                return !string.IsNullOrEmpty(value) && vortoValue.Equals(value, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public static object TryGetVortoValue(this IPublishedContent content, string propertyAlias)
        {
            return content.TryGetVortoValue<object>(propertyAlias);
        }

        public static T TryGetVortoValue<T>(this IPublishedContent content, string propertyAlias)
        {
            try
            {
                string currentUrl = HttpContext.Current.Request.Url != null ? HttpContext.Current.Request.Url.ToString() + "/" : "";
                var currentLanguageCode = "";
                if (currentUrl.Contains("/ja/"))
                {
                    currentLanguageCode = "ja";
                }
                else if (currentUrl.Contains("/en/"))
                {
                    currentLanguageCode = "en";
                }
                else if (currentUrl.Contains("/vi/"))
                {
                    currentLanguageCode = "vi";
                }

                if (currentLanguageCode != "")
                    return content.GetVortoValue<T>(propertyAlias, currentLanguageCode.ToString());

                return content.GetVortoValue<T>(propertyAlias);
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(PublishedContentExtensions), $"Failed to get vorto value from node {content.Id} and property {propertyAlias}", ex);
            }

            return default(T);
        }

        public static T GetSafePropertyValue<T>(this IPublishedContent content, string propertyAlias)
        {
            if (content.HasProperty(propertyAlias) && content.HasValue(propertyAlias))
            {
                return content.GetPropertyValue<T>(propertyAlias);
            }

            return default(T);
        }
    }
}