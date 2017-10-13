using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackStorkApp.Interfaces;
using System.Web.Security;

namespace BlackStorkApp.Helpers
{
    public class FormsAuthenticationService: IFormsAuthenticationService
    {
        public void SetAuthCookie(string login, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(login, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}