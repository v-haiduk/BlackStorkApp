using System;
using DAL.Entities;

namespace BLL.DTO
{
    public class UserProfileDTO
    {
        public int UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        //add other fields
    }
}
