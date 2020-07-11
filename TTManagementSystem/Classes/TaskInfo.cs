using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTManagementSystem
{
    public class TaskInfo
    {
        public string taskID { get;  private set; }
        public string Time { get; private set; }
        public string Description { get; private set; }
        public string Status { get; private set; }
        public string AssignTo { get; private set; }
        public string AssignBy { get; private set; }

        public TaskInfo(string taskID, string Time, string Description, string Status, string AssignTo, string AssignBy)
        {
            this.taskID = taskID;
            this.Time = Time;
            this.Description = Description;
            this.Status = Status;
            this.AssignTo = AssignTo;
            this.AssignBy = AssignBy;
        }
    }
}