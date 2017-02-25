using System;
using DAL.Entities;

namespace BLL.DTO
{
    public class TopicDTO
    {
        public int TopicId { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}
