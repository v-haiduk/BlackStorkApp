using System;
using DAL.Entities;

namespace BLL.DTO
{
    /// <summary>
    /// The DTO (data transfer object) is intermediate class 
    /// for transfer of data about topic between layers
    /// </summary>
    public class TopicDTO
    {
        public int TopicId { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreate { get; set; }
        public string PathForMainPhoto { get; set; }
        public string PathForFolderWithPhotos { get; set; }
    }
}
