using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IUserService: IMainService<UserAccountDTO>
    {
        UserAccountDTO GetByLogin(string login);
    }
}
