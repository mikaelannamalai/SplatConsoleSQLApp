using System;
using System.Data.SqlClient;
using System.Data;

namespace SPLAT
{
    class db

    {
        public static SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=SPLAT;Integrated Security=True");
        public static SqlCommand cmd = new SqlCommand("",conn);
        public static DataSet ds;
        public static SqlDataAdapter da;
        public static string sql;
        public static void openConnection ()
        {
            try
            {
                   if (conn.State == ConnectionState.Closed)
                {
                    conn.Open ();
                    Console.WriteLine("The connection is: "+conn.State.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Open Connection Failed: " + ex.Message);
                throw;
            }
                  }
        public static void closeConnection()
        { 
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine("The connection is: " + conn.State.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Closed Connection error: " + ex.Message);
                throw;
            }
        }
    }
}
