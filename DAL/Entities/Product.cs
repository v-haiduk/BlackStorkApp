using System;


namespace DAL.Entities
{
    /// <summary>
    /// The model of product for storage in the DB.
    /// </summary>
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathForMainPhoto { get; set; }
        public string PathForFolderWithPhotos { get; set; }
    }
}
