using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackStorkApp.Models
{
    /// <summary>
    /// Class with list of colours, which use in products (equipments)
    /// </summary>
    public class ColourModel
    {
        public int ColourId { get; set; }
        public string Name { get; set; }
        public string PathForImage { get; set; }
    }
}