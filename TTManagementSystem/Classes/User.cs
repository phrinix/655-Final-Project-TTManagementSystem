using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTManagementSystem
{
    public class User
    
    {
        public string UserName { get; private set; }
        public string FullName { get; private set; }

        public User(string Firstname, string Lastname, string UserName)
        {
            this.UserName = UserName;
            this.FullName = Firstname + " " + Lastname;
        }
    }
}