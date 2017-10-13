using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlackStorkApp.Models
{
    public class SubscribeModel
    {
        public int SubscribeId { get; set; }
        [AllowHtml]
        public string Email { get; set; }
    }
}