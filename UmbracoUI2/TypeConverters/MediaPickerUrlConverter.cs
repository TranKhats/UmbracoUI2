using Our.Umbraco.Ditto;
using Servcorp.Web.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Web;
using UmbracoUI2.Models;

namespace UmbracoUI2.TypeConverters
{
    public class MediaPickerUrlConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var mediaId = value as string;
            var test= UmbracoContext.Current.MediaCache.GetById(1088)?.Url; ;
            if (mediaId != null)
            {
                int id;
                if (int.TryParse(mediaId, out id))
                {
                    var media = UmbracoContext.Current.MediaCache.GetById(id);
                    return media.Url;
                }
                return string.Empty;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}