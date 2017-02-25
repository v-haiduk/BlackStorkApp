using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackStorkApp.Models
{
    public class TopicModel
    {
        public int TopicId { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}