using System;

namespace DAL.Entities
{
    /// <summary>
    /// The model of account for storage in the DB.
    /// </summary>
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public string Login { get; set; }
        public string HashOfPassword { get; set; }
    }
}
