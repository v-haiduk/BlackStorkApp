using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlackStorkApp.Models
{
    public class FeedbackModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        [AllowHtml]
        [StringLength(50)]

        public string UserName { get; set; }

        [Required]
        [Display(Name = "Адрес электронной почты")]
        [AllowHtml]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Сообщение")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string MessageText { get; set; }
    }
}