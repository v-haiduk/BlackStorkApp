using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackStorkApp.Models
{
    public class UserAccountModel
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string HashOfPassword { get; set; }
    }
}