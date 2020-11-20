using Our.Umbraco.Ditto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using UmbracoUI2.TypeConverters;

namespace UmbracoUI2.Models
{
    public class HomeModel
    {
        //public string Title { get; set; }


        //public string Image { get; set; }

        //[UmbracoDictionary("more")]
        //public string ReadMoreLabel { get; set; }

        //[TypeConverter(typeof(LinkModelTypeConverter))]
        //[UmbracoProperty("multiUrlPicker")]
        //public LinkModel MultiUrlPicker { get; set; }

        //[UmbracoProperty("largeImage")]
        //[TypeConverter(typeof(MediaPickerUrlConverter))]
        //public object LargeImage { get; set; }


        [TypeConverter(typeof(MutiLanguageConverter))]
        [UmbracoProperty("productContainer")]
        public List<ProductContainer> ProductContainer { get; set; }
    }

    public class ProductContainer
    {
        [UmbracoProperty("description")]
        public string Description { get; set; }

        [UmbracoProperty("productName")]
        public string ProductName { get; set; }

        [UmbracoProperty("productImage")]
        [TypeConverter(typeof(MediaPickerUrlConverter))]
        public object ProductImage { get; set; }        
        
    }
}