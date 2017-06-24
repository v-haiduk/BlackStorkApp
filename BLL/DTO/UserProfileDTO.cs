using System;
using DAL.Entities;

namespace BLL.DTO
{
    /// <summary>
    /// The DTO (data transfer object) is intermediate class 
    /// for transfer of full data about user  between layers
    /// </summary>
    public class UserProfileDTO
    {
        public int UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        //add other fields
    }
}
