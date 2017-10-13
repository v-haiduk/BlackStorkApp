﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlackStorkApp.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [AllowHtml]
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string PathForMainPhoto { get; set; }
        public string PathForFolderWithPhotos { get; set; }
    }
}