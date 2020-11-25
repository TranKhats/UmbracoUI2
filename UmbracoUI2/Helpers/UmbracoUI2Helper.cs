﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace UmbracoUI2.Helpers
{
    public class UmbracoUI2Helper
    {
        #region Public function
        public static string GetMediaUrlPicker(string mediaId)
        {
            string url = string.Empty;
            if (!string.IsNullOrEmpty(mediaId))
            {
                var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
                //var guidUdi = GuidUdi.Parse(mediaId);
                GuidUdi.TryParse(mediaId,out GuidUdi guidUdi);
                if (guidUdi != null)
                {
                    var imageNodeId = ApplicationContext.Current.Services.EntityService.GetIdForKey(guidUdi.Guid, (UmbracoObjectTypes)Enum.Parse(typeof(UmbracoObjectTypes), guidUdi.EntityType, true));
                    var publishedContent = umbracoHelper.TypedMedia(imageNodeId.Result);
                    url = publishedContent.Url;
                }
            }
            return url;
        }

        public static string GetDictionaryValue(string key, CultureInfo culture, UmbracoContext context)
        {
            var dictionaryItem = context.Application.Services.LocalizationService.GetDictionaryItemByKey(key);
            if (dictionaryItem != null)
            {
                var translation = dictionaryItem.Translations.SingleOrDefault(x => x.Language.CultureInfo.Equals(culture));
                if (translation != null)
                    return translation.Value;
            }
            return key; // if not found, return key
        }
        #endregion
    }
}