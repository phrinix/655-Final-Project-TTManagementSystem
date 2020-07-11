using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTManagementSystem
{
    public class Ticket
    {
        public string Number { get; private set; }
        public string Subject { get; private set; }
        public string Status    { get; private set;}
        public string Location { get; private set; }
        public string Severty { get; private set; }

        public Ticket(string Number, string Subject, string Status, string Location, string Severty)
        {
            this.Number = Number;
            this.Subject = Subject;
            this.Status = Status;
            this.Location = Location;
            this.Severty = Severty;
        }
    }
}