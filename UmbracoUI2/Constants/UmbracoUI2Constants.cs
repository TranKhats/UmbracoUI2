using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoUI2.Web.Constants
{
    public class UmbracoUI2Constants
    {
        public static Dictionary<string, string> Languages = new Dictionary<string, string>
        {
            {"English","en" },//fisrt is the default language
            {"Tieng Viet","vi"}
        };

        public static string LanguagesCookieKey = "LanguagesCookieKey";

        public static string AliasPageName = "pageName";
    }
}