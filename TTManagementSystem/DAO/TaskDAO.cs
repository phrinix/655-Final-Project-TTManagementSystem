using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace TTManagementSystem
{
    public class TaskDAO
    {
        static public List<TaskInfo> GetTask(string user)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            OracleCommand cmd;
            cmd = new OracleCommand("SELECT task_id, time_id, uassign_by, uassign_to, describe, stat FROM TASK WHERE uassign_to = :uname_to OR uassign_by= :uname_by", conn);
            cmd.Parameters.AddWithValue("uname_to", user);
            cmd.Parameters.AddWithValue("uname_by", user);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<TaskInfo> task = new List<TaskInfo>();
            da.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                task.Add(new TaskInfo(Convert.ToString(dr["task_id"]),Convert.ToString(dr["time_id"]), Convert.ToString(dr["describe"]), Convert.ToString(dr["stat"])
                    , Convert.ToString(dr["uassign_to"]), Convert.ToString(dr["uassign_by"])));
            }
            return task;
        }
        static public void updateTask(string taskID, string Status)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            conn.Open();
            OracleCommand cmd;
            string sql = "UPDATE task SET stat = :status WHERE task_id = :taskID";
            cmd = new OracleCommand(sql, conn);
            cmd.Parameters.AddWithValue("status", Status);
            cmd.Parameters.AddWithValue("taskID", taskID);
            cmd.ExecuteNonQuery();
        }
        static public void createTask(string assignBy, string assignTo, string describe)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            conn.Open();
            OracleCommand cmd;
            string sql = "INSERT INTO task (task_id, time_id,uassign_by,uassign_to,describe,stat) VALUES (TASK_ID_SEQUENCE.NEXTVAL,CURRENT_TIMESTAMP, :uassignBy, :uassignTo, :describe, 'OPEN')";
            cmd = new OracleCommand(sql, conn);
            cmd.Parameters.AddWithValue("uassignTo", assignTo);
            cmd.Parameters.AddWithValue("uassignBy", assignBy);
            cmd.Parameters.AddWithValue("describe", describe);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static public List<User> userList()
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            OracleCommand cmd;
            cmd = new OracleCommand("SELECT uname, firstname, lastname FROM user_t WHERE u_status != 'CLIENT'", conn);
            
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<User> user = new List<User>();
            da.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                user.Add(new User(Convert.ToString(dr["firstname"]), Convert.ToString(dr["lastname"]), Convert.ToString(dr["uname"])));
            }
            return user;
        }
    }
}