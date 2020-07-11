using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace TTManagementSystem
{
    public class LocationDAO
    {
        public static List<Location> locations(string userRole, string userName)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            OracleCommand cmd;
            if (userRole == "CLIENT")
            {
                cmd = new OracleCommand("SELECT DISTINCT room_no FROM ticket_prop INNER JOIN comments USING (ticket_id) WHERE uname = :uname", conn);
                cmd.Parameters.AddWithValue("uname", userName);

            }
            else
            {
                cmd = new OracleCommand("SELECT room_no FROM room_loc", conn);
            }
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Location> loc = new List<Location>();
            da.Fill(dt);
            conn.Close();

            foreach(DataRow dr in dt.Rows)
            {
                loc.Add(new Location(Convert.ToString(dr["room_no"])));
            }
            return loc;
        }
    }
}