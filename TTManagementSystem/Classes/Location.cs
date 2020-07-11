using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTManagementSystem
{
    public class Location
    {
        public string loc{ get; private set;}
        public Location(string loc)
        {
            this.loc = loc;
        }
    }
}