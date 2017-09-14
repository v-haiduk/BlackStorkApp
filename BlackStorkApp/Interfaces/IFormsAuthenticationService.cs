using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackStorkApp.Interfaces
{
    public interface IFormsAuthenticationService
    {
        void SignOut();
        void SetAuthCookie(string login, bool createPersistentCookie);
    }
}
