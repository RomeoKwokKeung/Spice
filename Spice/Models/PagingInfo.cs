using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class PagingInfo
    {
        //know how many item we have
        public int TotalItem { get; set; }
        //how many item we want to display per page
        public int ItemsPerPage { get; set; }
        
        public int CurrentPage { get; set; }

        public int totalPage => (int)Math.Ceiling((decimal)TotalItem / ItemsPerPage);
        //store the url
        public string urlParam { get; set; }
    }
}
