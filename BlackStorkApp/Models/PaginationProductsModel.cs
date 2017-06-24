using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackStorkApp.Models
{
    public class PaginationProductsModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public PageModel Page { get; set; }
    }
}