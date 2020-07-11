using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;


namespace TTManagementSystem
{
    public class CommentDAO
    {
        public static List<Comment> comment(string ticket_id)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            OracleCommand cmd = new OracleCommand("SELECT ticket_id, time_stamp, description, uname FROM comments WHERE ticket_id = :ticket_id ORDER BY time_stamp DESC", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Comment> Comments = new List<Comment>();

            cmd.Parameters.AddWithValue("ticket_id", ticket_id);
            da.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Comments.Add(new Comment(Convert.ToString(dr["ticket_id"]), Convert.ToString(dr["time_stamp"])
                    , Convert.ToString(dr["description"]), Convert.ToString(dr["uname"])));
            }
            return Comments;
        }
    }
}