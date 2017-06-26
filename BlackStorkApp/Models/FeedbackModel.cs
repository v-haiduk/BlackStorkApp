﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlackStorkApp.Models
{
    public class FeedbackModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        [StringLength(50)]

        public string UserName { get; set; }

        [Required]
        [Display(Name = "Адрес электронной почты")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Сообщение")]
        [DataType(DataType.MultilineText)]
        public string MessageText { get; set; }
    }
}