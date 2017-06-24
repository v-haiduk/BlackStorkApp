using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackStorkApp.Models
{
    public class PaginationTopicsModel
    {
        public IEnumerable<TopicModel> Topics { get; set; }
        public PageModel Page { get; set; }
    }
}