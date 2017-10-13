using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlackStorkApp.Models
{
    public class TopicModel
    {
        public int TopicId { get; set; }
        [AllowHtml]
        public string Header { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public DateTime DateOfCreate { get; set; }
        public string PathForMainPhoto { get; set; }
        public string PathForFolderWithPhotos { get; set; }
    }
}