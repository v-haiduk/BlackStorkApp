using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    /// <summary>
    /// The model of account for storage in the DB.
    /// </summary>
    public class UserAccount
    {
        [Key]
        public int UserAccountId { get; set; }
        public string Login { get; set; }
        public string HashOfPassword { get; set; }
    }
}
