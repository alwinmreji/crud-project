using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;


namespace New_webApi
{
    public class General
    {
        public static DataTable SelectQuery(string query)
        {

            DataTable dt = new DataTable();
            try
            {
                MySqlConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                //Logger.Log("Query", query);
                using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
                {

                    conn.Open();
                    MySqlCommand command = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    adapter.Fill(dt);

                }
            }
            catch (Exception e)
            {
                //Logger.Log("Error", e.ToString());

            }

            return dt;
        }
        public static string MySqlConnectionString = string.Empty;
        public static int DML(string query)
        {
            try
            {
                MySqlConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                //Logger.Log("Query", query);

                using (MySqlConnection connection = new MySqlConnection(MySqlConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        connection.Open();
                        try
                        {
                            cmd.CommandTimeout = 0;
                            return cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            return -1;
                            // ExceptionLogger.LogAllError(ex);
                        }

                    }
                }
            }

            catch (Exception e)
            {
                //Logger.Log("Error", e.ToString());
                return -1;

            }

        }
    }
}

