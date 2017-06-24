using System;
using DAL.Entities;

namespace BLL.DTO
{
    /// <summary>
    /// The DTO (data transfer object) is intermediate class 
    /// for transfer of data about account between layers
    /// </summary>
    public class UserAccountDTO
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string HashOfPassword { get; set; }
    }
}
