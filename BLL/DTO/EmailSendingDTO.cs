using System;
using DAL.Entities;

namespace BLL.DTO
{
    /// <summary>
    /// The DTO (data transfer object) is intermediate class 
    /// for transfer of data about email sending  between layers
    /// </summary>
    public class EmailSendingDTO
    {
        public int EmailSendingId { get; set; }
        public string Email { get; set; }

    }
}
