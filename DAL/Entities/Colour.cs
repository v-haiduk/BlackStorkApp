using System;

namespace DAL.Entities
{
    /// <summary>
    /// The model for list with colours of products (equipments)
    /// </summary>
    public class Colour
    {
        public int ColourId { get; set; }
        public string Name { get; set; }
        public string PathForImage { get; set; }
    }
}
