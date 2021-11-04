using MovieReservation.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservation
{
    class functionMSSQL
    {
        public static DataTable getFromDatabase(string SQL)
        {
            DataTable dataTable;

            try
            {
                dataTable = getFromDatabase(SQL.Replace("`",""), classGlobalVariables.Server,
                            classGlobalVariables.Username, classGlobalVariables.Password,
                            classGlobalVariables.Database, classGlobalVariables.Sqlport);

                return dataTable;
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return null;
            }
        }

        public static DataTable getFromDatabase(string SQL, string server, string userid, string password, string database, string sqlport)
        {
            DataTable dataTable;
            string connectionString;
            SqlConnection sqlConnection;
            SqlCommand sqlCommand;
            SqlDataAdapter sqlDataAdapter;

            try
            {
                dataTable = new DataTable();
                sqlConnection = null;

                connectionString = @"Data Source = " + classGlobalVariables.Server +
                                                    ";Initial Catalog=" + classGlobalVariables.Database +
                                                    ";Integrated Security=True;";
                                                    //";User id=" + classGlobalVariables.Username +
                                                    //";Password=" + classGlobalVariables.Password + ";";

                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                sqlCommand = new SqlCommand(SQL, sqlConnection);
                sqlCommand.CommandTimeout = 300;
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);

                sqlConnection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return null;
            }
        }

        public static bool setDatabase(string SQL, Dictionary<string,string> dictionaryOfParameters)
        {
            string server;
            string userid;
            string password;
            string database;
            string sqlport;
            string connectionString;
            SqlConnection sqlConnection;
            SqlCommand sqlCommand;

            try
            {
                server = classGlobalVariables.Server;
                userid = classGlobalVariables.Username;
                password = classGlobalVariables.Password;
                database = classGlobalVariables.Database;
                sqlport = classGlobalVariables.Sqlport;

                connectionString = @"Data Source = " + classGlobalVariables.Server +
                                                    ";Initial Catalog=" + classGlobalVariables.Database +
                                                    ";Integrated Security=True;";
                //";User id=" + classGlobalVariables.Username +
                //";Password=" + classGlobalVariables.Password + ";";

                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                sqlCommand = new SqlCommand(SQL.Replace("`",""), sqlConnection);
                foreach(KeyValuePair<string,string> parameter in dictionaryOfParameters)
                    sqlCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                sqlCommand.CommandTimeout = 300;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return false;
            }
        }

        public long getNextTableId(string tablename)
        {
            string minTableId;
            string maxTableId;
            string tableIdAsString;
            long outputTableId;
            List<string> listOfSqlQueries;

            try
            {
                minTableId = "100000000000";
                maxTableId = "999999999999";
                tableIdAsString = "";
                outputTableId = 0;
                listOfSqlQueries = new List<string>();
                                       
                listOfSqlQueries.Add(@"select (coalesce(MAX(table_id)," + minTableId + ") + 1) as T FROM " + tablename + @" 
                                       WHERE table_id >= " + minTableId + @"
                                       AND table_id <= " + maxTableId);
                tableIdAsString = ExecuteSQLTransaction(listOfSqlQueries);

                listOfSqlQueries.Clear();
                listOfSqlQueries.Add(@"INSERT into " + tablename + $" (table_id) VALUES ( {tableIdAsString} )");
                ExecuteSQLTransaction(listOfSqlQueries);
                outputTableId = long.TryParse(tableIdAsString, out outputTableId) ? outputTableId : 0;

                return outputTableId;
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return 0;
            }
        }

        public string ExecuteSQLTransaction(List<string> listOfSqlQueries)
        {
            string returnValue;
            string sqlQuery = "";
            string connectionString;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlcommand;

            try
            {
                returnValue = "";
                sqlQuery = "";
                connectionString = @"Data Source = " + classGlobalVariables.Server +
                                                    ";Initial Catalog=" + classGlobalVariables.Database +
                                                    ";Integrated Security=True;";
                //";User id=" + classGlobalVariables.Username +
                //";Password=" + classGlobalVariables.Password + ";";

                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction();

                sqlcommand = new SqlCommand();
                sqlcommand.CommandTimeout = 300;
                sqlcommand.Connection = sqlConnection;
                sqlcommand.Transaction = sqlTransaction;

                foreach (string query in listOfSqlQueries)
                {
                    sqlQuery = query;
                    sqlcommand.CommandText = query;

                    if (query.Trim().IndexOf("select") == 0)
                        returnValue = sqlcommand.ExecuteScalar().ToString();
                    else if (query.Trim().ToLower().IndexOf("insert") == 0)
                    {
                        if (sqlcommand.ExecuteNonQuery() < 0)
                            throw new Exception();
                    }
                    else
                        sqlcommand.ExecuteNonQuery();
                }

                sqlTransaction.Commit();
                if (sqlConnection != null)
                    sqlConnection.Close();

                return returnValue;
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage("Exception: \n " + ex.ToString() + " \n Query: \n " + sqlQuery);
                try
                {
                    if (sqlTransaction != null)
                    {
                        sqlTransaction.Rollback();
                        functionGlobal.printLogMessage("Roll back sucessful");
                    }
                }
                catch (Exception ex1)
                {
                    functionGlobal.printLogMessage("Unable to do rollback. error: \n" + ex1.ToString());
                }

                if (sqlConnection != null)
                    sqlConnection.Close();

                return "";
            }
        }
    }
}