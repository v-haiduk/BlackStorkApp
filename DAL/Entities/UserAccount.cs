using System;

namespace DAL.Entities
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public string Login { get; set; }
        public string HashOfPassword { get; set; }
    }
}
