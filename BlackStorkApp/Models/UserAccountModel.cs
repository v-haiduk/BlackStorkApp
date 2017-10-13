using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlackStorkApp.Models
{
    public class UserAccountModel
    {
        public int UserId { get; set; }

        [Required (ErrorMessage ="Введите e-mail")]
        [AllowHtml]
        public string Login { get; set; }

        [Required (ErrorMessage = "Введите пароль")]
        [AllowHtml]
        public string HashOfPassword { get; set; }
    }
}