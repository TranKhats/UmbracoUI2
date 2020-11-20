using Our.Umbraco.Ditto;
using UmbracoUI2.Web.Extensions;
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
    public class MutiLanguageProductItemConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(Our.Umbraco.Vorto.Models.VortoValue) || base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            List<ProductContainer> result = new List<ProductContainer>();
            var content = context.Instance as IPublishedContent;
            var attrs = context.PropertyDescriptor.Attributes.OfType<UmbracoPropertyAttribute>().ToList();
            try
            {
                var vosto = content.TryGetVortoValue<IEnumerable<IPublishedContent>>(context.PropertyDescriptor.Name);
                //var test = value.TryConvertTo< Our.Umbraco.Vorto.Models.VortoValue>();
                if (vosto != null)
                {
                    foreach (var item in vosto)
                    {
                        var properties = item.Properties;

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
                LogHelper.Error(typeof(MutiLanguageProductItemConverter), $"Failed to get vorto value from node {content.Id} and propertys", ex);
            }
            return result;
        }


    }
}