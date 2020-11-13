using Our.Umbraco.Ditto;
using RJP.MultiUrlPicker.Models;
using Servcorp.Web.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace UmbracoUI2.TypeConverters
{
    public class MutiLanguageConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            List<string> result = new List<string>();
            var content = context.Instance as IPublishedContent;
            //--------------
            var attrs = context.PropertyDescriptor.Attributes.OfType<UmbracoPropertyAttribute>().ToList();
            //if (attrs.Any())
            //{
            //    var valueAttr = attrs.First();
            //   var xxx= content.TryGetVortoValue(valueAttr.PropertyName);
            //    return xxx;
            //}
            //--------------------
            var vosto = content.TryGetVortoValue<IEnumerable<IPublishedContent>>(context.PropertyDescriptor.Name);
            foreach (var item in vosto)
            {
                result.Add(item.Properties.FirstOrDefault().DataValue.ToString());
            }
            return result;
        }
    }
}