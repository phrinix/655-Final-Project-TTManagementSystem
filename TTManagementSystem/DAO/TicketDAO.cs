using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace TTManagementSystem
{
    public class TicketDAO
    {
        public static List<Ticket> ticket(string userRole, string room_no, string userName)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            OracleCommand cmd;
            if (userRole == "CLIENT")
            {
                cmd = new OracleCommand("SELECT DISTINCT Ticket_id, subject, status, severity, room_no FROM ticket_prop INNER JOIN comments USING (ticket_id) WHERE room_no = :room_no AND uname= :uname", conn);
                cmd.Parameters.AddWithValue("uname", userName);
            }
            else
            {
                cmd = new OracleCommand("SELECT Ticket_id, subject, status, severity, room_no FROM ticket_prop WHERE room_no = :room_no", conn);
            }
            cmd.Parameters.AddWithValue("room_no", room_no);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Ticket> tickets = new List<Ticket>();

            
            da.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                tickets.Add(new Ticket(Convert.ToString(dr["ticket_id"]),Convert.ToString(dr["subject"]),Convert.ToString(dr["status"])
                    , Convert.ToString(dr["room_no"]), Convert.ToString(dr["severity"])));
            }
            return tickets;
        }
    }
}