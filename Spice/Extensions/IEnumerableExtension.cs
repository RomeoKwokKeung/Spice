using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Extensions
{
    public static class IEnumerableExtension
    {
        //convert all of the category list object to ienmerable of select list
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                       //selected field in the select item
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())
                   };
        }

    }
}
