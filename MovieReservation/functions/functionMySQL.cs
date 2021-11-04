using MovieReservation.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservation
{
    class functionMySQL
    {
        public static DataTable getFromDatabase(string SQL)
        {
            DataTable dataTable;

            try
            {
                dataTable = getFromDatabase(SQL, classGlobalVariables.Server, 
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
            MySqlConnection sqlConnection;
            MySqlCommand sqlCommand;
            MySqlDataAdapter sqlDataAdapter;

            try
            {
                dataTable = new DataTable();
                sqlConnection = null;

                connectionString = @"server=" + server + 
                                    ";userid=" + userid + 
                                    ";password=" + password + 
                                    ";database=" + database + 
                                    ";port=" + sqlport + 
                                    ";Allow Zero Datetime=true;Charset = utf8;Allow User Variables=True;";

                sqlConnection = new MySqlConnection(connectionString);
                sqlConnection.Open();

                sqlCommand = new MySqlCommand(SQL, sqlConnection);
                sqlCommand.CommandTimeout = 300;
                sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
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

        public static bool setDatabase(string SQL, Dictionary<string, string> dictionaryOfParameters)
        {
            string server;
            string userid;
            string password;
            string database;
            string sqlport;
            string connectionString;
            MySqlConnection mySqlConnection;
            MySqlCommand mySqlCommand;

            try
            {
                server = classGlobalVariables.Server;
                userid = classGlobalVariables.Username;
                password = classGlobalVariables.Password;
                database = classGlobalVariables.Database;
                sqlport = classGlobalVariables.Sqlport;

                connectionString = @"server=" + server + 
                                    ";userid=" + userid + 
                                    ";password=" + password + 
                                    ";database=" + database + 
                                    ";port=" + sqlport + 
                                    ";Allow Zero Datetime=true;Connect Timeout=300;";

                mySqlConnection = new MySqlConnection(connectionString);
                mySqlConnection.Open();

                mySqlCommand = new MySqlCommand(SQL, mySqlConnection);
                foreach (KeyValuePair<string, string> parameter in dictionaryOfParameters)
                    mySqlCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                mySqlCommand.CommandTimeout = 300;
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
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

                listOfSqlQueries.Add("SET @temp_table_id = 0;");
                listOfSqlQueries.Add(@"SELECT coalesce(MAX(`table_id`)," + minTableId + ") + 1 INTO @temp_table_id FROM `" + tablename + @"` 
                                WHERE `table_id` >= " + minTableId + @"
                                    AND `table_id` <= " + maxTableId + @" FOR UPDATE;");
                listOfSqlQueries.Add(@"INSERT into `" + tablename + @"` (`table_id`)
                            VALUES ( @temp_table_id );");
                listOfSqlQueries.Add(@"select @temp_table_id AS 'table_id';");

                tableIdAsString = ExecuteSQLTransaction(listOfSqlQueries);
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

            MySqlConnection mySqlConnection = null;
            MySqlTransaction mySqlTransaction = null;
            MySqlCommand mySqlcommand;

            try
            {
                returnValue = "";
                sqlQuery = "";
                connectionString = @"server=" + classGlobalVariables.Server +
                                    ";userid=" + classGlobalVariables.Username +
                                    ";password=" + classGlobalVariables.Password +
                                    ";database=" + classGlobalVariables.Database +
                                    ";port=" + classGlobalVariables.Sqlport +
                                    ";Allow Zero Datetime=true;Charset = utf8; Connect Timeout=300;Allow User Variables=True;";

                mySqlConnection = new MySqlConnection(connectionString);
                mySqlConnection.Open();
                mySqlTransaction = mySqlConnection.BeginTransaction();

                mySqlcommand = new MySqlCommand();
                mySqlcommand.CommandTimeout = 300;
                mySqlcommand.Connection = mySqlConnection;
                mySqlcommand.Transaction = mySqlTransaction;

                foreach (string query in listOfSqlQueries)
                {
                    sqlQuery = query;
                    mySqlcommand.CommandText = query;

                    if (query.Trim().IndexOf("select") == 0)
                        returnValue = mySqlcommand.ExecuteScalar().ToString();
                    else if (query.Trim().ToLower().IndexOf("insert") == 0)
                    {
                        if (mySqlcommand.ExecuteNonQuery() <= 0)
                            throw new Exception();
                    }
                    else
                        mySqlcommand.ExecuteNonQuery();
                }

                mySqlTransaction.Commit();
                if (mySqlConnection != null)
                    mySqlConnection.Close();

                return returnValue;
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage("Exception: \n " + ex.ToString() + " \n Query: \n " + sqlQuery);
                try
                {
                    if (mySqlTransaction != null)
                    {
                        mySqlTransaction.Rollback();
                        functionGlobal.printLogMessage("Roll back sucessful");
                    }
                }
                catch (Exception ex1)
                {
                    functionGlobal.printLogMessage("Unable to do rollback. error: \n" + ex1.ToString());
                }

                if (mySqlConnection != null)
                    mySqlConnection.Close();

                return "";
            }
        }
    }
}
