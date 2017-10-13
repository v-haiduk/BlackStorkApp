using System;

namespace DAL.Entities
{
    /// <summary>
    /// The model of account with additional information for storage in the DB.
    /// </summary>
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        //add other fields
    }
}
