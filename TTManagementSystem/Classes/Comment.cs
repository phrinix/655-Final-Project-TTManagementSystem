using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTManagementSystem
{
    public class Comment
    {
        public string ticket_id { get; private set; }
        public string time_stamp    { get; private set;}
        public string description { get; private set; }
        public string uname { get; private set; }

        public Comment(string ticket_idr, string time_stamp, string description, string uname)
        {
            this.ticket_id = ticket_id;
            this.time_stamp = time_stamp;
            this.description = description;
            this.uname = uname;
        }
    }
}