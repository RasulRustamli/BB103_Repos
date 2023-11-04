using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Data
{
    internal class Sql
    {
      private static readonly string  con = "server=DESKTOP-FHK353D;database=BB103_ADO;Trusted_connection=true;Integrated security=true";
      private static readonly SqlConnection connection= new SqlConnection(con);


        //non queries method //delete/update/insert
        public int ExecuteNonQuery(string command)
        {
            connection.Open();
            SqlCommand sqlCommand=new SqlCommand(command, connection);
            int result=sqlCommand.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        //query method//select
        public  DataTable ExecuteQuery(string query)
        {
            connection.Open();
            SqlDataAdapter querySelect = new SqlDataAdapter(query, connection);
            DataTable table=new DataTable();
            querySelect.Fill(table);
            return table;

        }



    }
}
