using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackStorkApp.Models
{
    public class PageModel
    {
        public int PageNumber { get; set; }
        public int PageCapacity { get; set; }
        public int TotalItems { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageCapacity); }
        }
    }
}