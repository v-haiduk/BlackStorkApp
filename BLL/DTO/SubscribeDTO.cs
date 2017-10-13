using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    /// <summary>
    /// The DTO (data transfer object) is intermediate class 
    /// for transfer of data about email between layers
    /// </summary>
    public class SubscribeDTO
    {
        public int SubscribeId { get; set; }
        public string Email { get; set; }
    }
}
