using Our.Umbraco.Ditto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using UmbracoUI2.Helpers;
using UmbracoUI2.Models;
using UmbracoUI2.Web.Extensions;
using Our.Umbraco.Vorto.Models;

namespace UmbracoUI2.TypeConverters
{
    public class MutiLanguageLocationsConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            var isChecked = sourceType.Name == /*typeof(List<LocationItem>)*/"List`1";
            return isChecked || base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            List<LocationItem> result = new List<LocationItem>();
            var content = context.Instance as IPublishedContent;
            try
            {
                var vosto= value as IEnumerable<IPublishedContent>;
                //var vosto = content.TryGetVortoValue<IEnumerable<IPublishedContent>>(context.PropertyDescriptor.Name);
                //var a = value as IEnumerable<IPublishedContent>;
                //var a0 = a.ToList()[0];
                //var b = a0.TryGetVortoValue("address").ToString();
                if (vosto != null)
                {
                    foreach (var item in vosto)
                    {
                        var properties = item.Properties;
                        var dataItem = new LocationItem()
                        {
                            Address = item.TryGetVortoValue("address").ToString(),
                            LocationName = item.TryGetVortoValue("locationName").ToString(),
                            ContactNumber = properties.FirstOrDefault(t => t.PropertyTypeAlias == "phoneNumber").Value.ToString(),
                            LocationImage= UmbracoUI2Helper.GetMediaUrlPicker(properties.FirstOrDefault(t => t.PropertyTypeAlias == "locationImage")?.DataValue.ToString())
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