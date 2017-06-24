using System;


namespace DAL.Entities
{
    /// <summary>
    /// The model of topic for storage in the DB.
    /// </summary>
    public class Topic
    {
        public int TopicId { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreate { get; set; }
        public string PathForMainPhoto { get; set; }
        public string PathForFolderWithPhotos { get; set; }
    }
}
