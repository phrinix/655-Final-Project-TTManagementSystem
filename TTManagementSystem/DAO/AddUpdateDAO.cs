using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace TTManagementSystem
{
    public class AddUpdateDAO
    {
        public static void AddTicket(string user_id,string room,string severity,string subj,string descript)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            conn.Open();
            OracleCommand cmd;
            string sql = "INSERT INTO TICKET_PROP (TICKET_ID, STATUS, SEVERITY, SUBJECT, ROOM_NO) VALUES (TICKET_ID_SEQUENCE.NEXTVAL, 'OPEN', :severity, :sub, :room)";
            cmd = new OracleCommand(sql, conn);
            cmd.Parameters.AddWithValue("severity", severity);
            cmd.Parameters.AddWithValue("sub", subj);
            cmd.Parameters.AddWithValue("room", room);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            string sql2 = "INSERT INTO COMMENTS(TICKET_ID, TIME_STAMP, DESCRIPTION, UNAME) VALUES (TICKET_ID_SEQUENCE.CURRVAL, CURRENT_TIMESTAMP, :descript, :user_id)";
            cmd = new OracleCommand(sql2, conn);
            cmd.Parameters.AddWithValue("descript", descript);
            cmd.Parameters.AddWithValue("user_id", user_id);
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }
        public static void UpdateTicket(string user_id, string ticket_no, string status, string descript)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            conn.Open();
            OracleCommand cmd;
            string sql = "UPDATE TICKET_PROP SET status = :status WHERE ticket_id = :ticket_id";
            cmd = new OracleCommand(sql, conn);
            cmd.Parameters.AddWithValue("status", status);
            cmd.Parameters.AddWithValue("ticket_id", ticket_no);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            if (descript == "")
            {
                descript = "Only Staus Changed";
            }

            string sql2 = "INSERT INTO COMMENTS(TICKET_ID, TIME_STAMP, DESCRIPTION, UNAME) VALUES (:ticket, CURRENT_TIMESTAMP, :descript, :user_id)";
            cmd = new OracleCommand(sql2, conn);
            cmd.Parameters.AddWithValue("descript", descript);
            cmd.Parameters.AddWithValue("user_id", user_id);
            cmd.Parameters.AddWithValue("ticket", ticket_no);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}