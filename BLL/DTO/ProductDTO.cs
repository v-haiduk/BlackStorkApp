using System;
using DAL.Entities;

namespace BLL.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string pathForMainPhoto { get; set; }
        //add fields for other photo, which will be in slider
    }
}
