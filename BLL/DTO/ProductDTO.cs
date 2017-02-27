using System;
using DAL.Entities;

namespace BLL.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathForMainPhoto { get; set; }
        public string PathForFolderWithPhotos { get; set; }
    }
}
