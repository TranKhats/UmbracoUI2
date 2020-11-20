using Our.Umbraco.Ditto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using UmbracoUI2.TypeConverters;

namespace UmbracoUI2.Models
{
    public class AboutModel
    {
        [UmbracoProperty("title")]
        public string Title { get; set; }

        [UmbracoProperty("aboutCompany")]
        public string AboutCompany { get; set; }

        [UmbracoProperty("companyImage")]
        [TypeConverter(typeof(MediaPickerUrlConverter))]
        public object CompanyImage { get; set; }
    }
}