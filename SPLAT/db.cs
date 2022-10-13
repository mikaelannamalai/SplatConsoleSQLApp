using System;
using System.Data.SqlClient;
using System.Data;

namespace SPLAT
{
    public class DB

    {
        private static SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=SPLAT;Integrated Security=True");

        private static SqlCommand cmd;
        private static DataSet ds;
        private static SqlDataAdapter adapter = new SqlDataAdapter();
        private static String sql;
        public static String TICKETS_TABLE = "TICKETS";
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
                openConnection();
                Console.WriteLine(conn.ConnectionString);
                String comma = ", ";
                String fieldNamesStr = "";
                for (int i = 0; i < fields.Length - 1; i++)
                {
                    fieldNamesStr += fields[i] + comma;
                }
                fieldNamesStr += fields[fields.Length - 1];


                String valuesStr = "";
                for (int i = 0; i < values.Length - 1; i++)
                { valuesStr += "'"+values[i] +"'"+ comma;
                }
                valuesStr +="'"+ values[values.Length - 1]+"'";
                
                sql = "INSERT INTO " + table + " (" + fieldNamesStr + ") " + "values(" + valuesStr + ");";
                Console.WriteLine(fieldNamesStr);
                Console.WriteLine(valuesStr);
                Console.WriteLine(sql);
                cmd = new SqlCommand(sql, conn); 
                Console.WriteLine(cmd.Connection.State.ToString());   
                adapter.InsertCommand= new SqlCommand(sql,conn);
                adapter.InsertCommand.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
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
