using Our.Umbraco.Ditto;
using Servcorp.Web.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Web;
using UmbracoUI2.Helpers;
using UmbracoUI2.Models;

namespace UmbracoUI2.TypeConverters
{
    public class MutiLanguageConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
            //return sourceType == typeof(List<ProductContainer>) || base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            List<ProductContainer> result = new List<ProductContainer>();
            var content = context.Instance as IPublishedContent;
            var attrs = context.PropertyDescriptor.Attributes.OfType<UmbracoPropertyAttribute>().ToList();
            try
            {
                var vosto = content.TryGetVortoValue<IEnumerable<IPublishedContent>>(context.PropertyDescriptor.Name);
                if (vosto != null)
                {
                    foreach (var item in vosto)
                    {
                        var properties = item.Properties;

                        //--------------------------
                        //string productImage = "";
                        //var media = properties.FirstOrDefault(t => t.PropertyTypeAlias == "productImage")?.DataValue.ToString();
                        //if (!string.IsNullOrEmpty(media))
                        //{
                        //    var umbracoHelper = new Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current);
                        //    var guidUdi = GuidUdi.Parse(media);
                        //    var imageNodeId = ApplicationContext.Current.Services.EntityService.GetIdForKey(guidUdi.Guid, (UmbracoObjectTypes)Enum.Parse(typeof(UmbracoObjectTypes), guidUdi.EntityType, true));

                        //    var publishedContent = umbracoHelper.TypedMedia(imageNodeId.Result);
                        //    productImage = publishedContent.Url;
                        //}
                        //--------------------------


                        var dataItem = new ProductContainer()
                        {
                            Description = properties.FirstOrDefault(t => t.PropertyTypeAlias == "description")?.DataValue.ToString(),
                            ProductName = properties.FirstOrDefault(t => t.PropertyTypeAlias == "productName")?.DataValue.ToString(),
                            ProductImage = UmbracoUI2Helper.GetMediaUrlPicker(properties.FirstOrDefault(t => t.PropertyTypeAlias == "productImage")?.DataValue.ToString())/*properties.FirstOrDefault(t => t.PropertyTypeAlias == "productImage")?.DataValue.ToString()*/,
                        };
                        result.Add(dataItem);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(MutiLanguageConverter), $"Failed to get vorto value from node {content.Id} and propertys", ex);
            }
            return result;
        }
    }
}