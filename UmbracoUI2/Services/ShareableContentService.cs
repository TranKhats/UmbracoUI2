using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IServices.IServices;
using Umbraco.Core.Models;
using Umbraco.Web;
using UmbracoUI2.Models;
using Our.Umbraco.Ditto;
using UmbracoUI2.Web.Extensions;

namespace UmbracoUI2.Services
{
    public class ShareableContentService : IShareableContentService
    {
        public object GetShareableContent<T>(int id) where T : class//class có nghĩa là T phải là một lớp và không phải là một loại giá trị hoặc một cấu trúc.
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            var node = umbracoHelper.TypedContent(id);
            var poco = node.As<T>();
            return poco;
        }

        public object GetShareableContent<T>(string alias) where T : class
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            var node = UmbracoContext.Current.ContentCache.GetByRoute(alias);
            var poco = node.As<T>();
            return poco;
        }
    }
}