using Our.Umbraco.Ditto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using UmbracoUI2.TypeConverters;

namespace UmbracoUI2.Models
{
    public class LocationModel
    {
        [TypeConverter(typeof(MutiLanguageLocationsConverter))]
        [UmbracoProperty("locationItems")]
        public List</*object*/LocationItem> LocationItems { get; set; }
    }

    public class LocationItem
    {
        [UmbracoProperty("phoneNumber")]
        public string ContactNumber { get; set; }

        [UmbracoProperty("address")]
        public string Address { get; set; }

        [UmbracoProperty("locationName")]
        public string LocationName { get; set; }
    }
}