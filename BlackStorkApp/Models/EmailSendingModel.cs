using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackStorkApp.Models
{
    /// <summary>
    /// Class with list of email, which use for subscribe.
    /// </summary>
    public class EmailSendingModel
    {
        public int EmailSendingModelId { get; set; }
        public string Email { get; set; }
    }
}