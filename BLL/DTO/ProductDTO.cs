using System;
using DAL.Entities;

namespace BLL.DTO
{
    /// <summary>
    /// The DTO (data transfer object) is intermediate class 
    /// for transfer of data about product between layers
    /// </summary>
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathForMainPhoto { get; set; }
        public string PathForFolderWithPhotos { get; set; }
    }
}
