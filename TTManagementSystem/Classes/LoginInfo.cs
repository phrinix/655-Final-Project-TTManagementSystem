using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTManagementSystem
{
    public class LoginInfo
    {
        public string UserName { get; private set; }
        public string Name     { get; private set; }
        public string Password { get; private set; }
        public string userRole { get; private set; }

        public LoginInfo(string UserName, string Password, string Name, string userRole)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.Name = Name;
            this.userRole = userRole;
        }
    }
}