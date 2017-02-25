using System;
using DAL.Entities;

namespace BLL.DTO
{
    public class UserAccountDTO
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string HashOfPassword { get; set; }
    }
}
