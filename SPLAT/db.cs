using System;
using System.Data.SqlClient;
using System.Data;

namespace SPLAT
{
    public class DB

    {
        private static SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=SPLAT;Integrated Security=True");
        private static SqlCommand cmd = new SqlCommand("",conn);
        private static DataSet ds;
        private static SqlDataAdapter da;
        private static string sql;
        public static string TICKETS_TABLE = "TICKETS";
        private static DB instance;
        //  public static string PROJECTS_TABLE = "Projects";
        //  public static string USERS_TABLE = "Users";

        public static DB getInstance()
        { 
            if (instance == null)
                instance = new DB();
            return instance;
        }


        public static void openConnection ()
        {
            try
            {
                   if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                 //   Console.WriteLine("The connection is: "+conn.State.ToString());
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
                  //  Console.WriteLine("The connection is: " + conn.State.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Closed Connection error: " + ex.Message);
                throw;
            }
        }
        public SqlConnection GetSQLConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    openConnection();
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Open Connection Failed: " + ex.Message);
                throw;
            }
        }

        public void insert(String table, String[] fields, String[] values)
        {
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();

                String comma = ", ";
                String fieldNamesStr = "";
                foreach (String field in fields)
                    fieldNamesStr += "\"" + field + "\"" + comma;
                fieldNamesStr = fieldNamesStr.Substring(0, fieldNamesStr.Length - 1);

                String valuesStr = "";
                foreach (String value in values)
                    valuesStr += "\"" + value + "\"" + comma;
                valuesStr = valuesStr.Substring(0, valuesStr.Length - 1);

                String templ = "INSERT INTO %s (%s) values %s(%s);";
                String sql = String.Format(templ, table, fieldNamesStr, valuesStr);
                cmd.Parameters.Add(sql);
                cmd.ExecuteNonQuery();
                

                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void update(String table, int ID, String field, String value) 
        {
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();

                String templ = "UPDATE %s (%s) SET \" %s(%s) value %s(%s) where id = %s(%s);";
                String sql = String.Format(templ, table, field, value,ID);
                cmd.Parameters.Add(sql);
                cmd.ExecuteNonQuery();



            }
            catch (Exception)
            {

                throw;
            }




        }







        public string get( string table, int id, string column)
        {
            try
            {
                SqlCommand sqlCommand = conn.CreateCommand();
                string sql = "SELECT * FROM " + table + " WHERE ID = " + id;
                
                return sqlCommand.CommandText = sql;

            }
            catch (Exception)
            {

                throw;
            }

        }
        
        public string getAll( string table)
        {
            try
            {
                SqlCommand sqlCommand = conn.CreateCommand();
                string sql = "SELECT * FROM " + table;

                return sqlCommand.CommandText = sql;

            }
            catch (Exception)
            {

                throw;
            }


        }

    }
}
