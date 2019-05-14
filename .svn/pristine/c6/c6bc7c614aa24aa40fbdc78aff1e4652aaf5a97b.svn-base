using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace RSSMWeb.Code
{
    /// <summary>
    /// 数据库的通用访问类
    /// 此类为抽象类，不允许实例化，在应用时直接调用
    /// </summary>
    public abstract class SqlHelper
    {
        //获取数据库连接字符串，其属于静态变量且只读，项目中所有文档可以直接使用，但不能修改
        public static readonly string ConnectionStringLocalTransaction = ConfigurationManager.ConnectionStrings["RSSMWeb.Properties.Settings.str_conn"].ConnectionString;
        public static readonly string ConnectionStringLocalTransactionERP = ConfigurationManager.ConnectionStrings["RSSMWeb.Properties.Settings.str_conn_ERP"].ConnectionString;
        //public static readonly string ConnectionStringInventoryDistributedTransaction = ConfigurationManager.ConnectionStrings["SQLConnString2"].ConnectionString;
        //public static readonly string ConnectionStringOrderDistributedTransaction = ConfigurationManager.ConnectionStrings["SQLConnString3"].ConnectionString;
        //public static readonly string ConnectionStringProfile = ConfigurationManager.ConnectionStrings["SQLProfileConnString"].ConnectionString;
        //数据库连接字符串  链接不同的数据库使用这个不同的链接名称即可
        public static string ConnString = System.Configuration.ConfigurationManager.AppSettings["ConnString"];
        //数据库连接字符串
        public static string agentsConnString = System.Configuration.ConfigurationManager.AppSettings["agentsConnString"];

        #region private utility methods & constructors
        //Since this class provides only static methods, make the default constructor private to prevent
        //instances from being created with "new SqlHelper()"
        public SqlHelper() { }

        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter p in commandParameters)
            {
                //check for derived output value with no value assigned
                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }
                command.Parameters.Add(p);
            }
        }
        private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                //do nothing if we get no data
                return;
            }
            // we must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }
            //iterate through the SqlParameters, assigning the values from the corresponding position in the
            //value array
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                commandParameters[i].Value = parameterValues[i];
            }
        }
        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            //if the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            //associate the connection with the command
            command.Connection = connection;
            //set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;
            //if we were provided a transaction, assign it.
            if (transaction != null)
            {
                command.Transaction = transaction;
            }
            //set the command type
            command.CommandType = commandType;
            //attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        #endregion private utility methods & constructors
        #region DataHelpers
        public static string CheckNull(object obj)
        {
            return (string)obj;
        }
        public static string CheckNull(DBNull obj)
        {
            return null;
        }
        #endregion
        #region AddParameters
        public static object CheckForNullString(string text)
        {
            if (text == null || text.Trim().Length == 0)
            {
                return System.DBNull.Value;
            }
            else
            {
                return text;
            }
        }
        public static SqlParameter MakeInParam(string ParamName, object Value)
        {
            return new SqlParameter(ParamName, Value);
        }
        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }
        /// <summary>
        /// Make input param.
        /// </summary>
        /// <param name="ParamName">Name of param.</param>
        /// <param name="DbType">Param type.</param>
        /// <param name="Size">Param size.</param>
        /// <returns>New parameter.</returns>
        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }
        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;
            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;
            return param;
        }

        #endregion
        #region ExecuteNonQuery
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteNonQuery(connectionString, commandType, commandText, (SqlParameter[])null);
        }
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create & open a SqlConnection, and dispose of it after we are done.
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                //call the overload that takes a connection in place of the connection string
                return ExecuteNonQuery(cn, commandType, commandText, commandParameters);
            }
        }
        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteNonQuery(connection, commandType, commandText, (SqlParameter[])null);
        }
        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            //finally, execute the command.
            int retval = cmd.ExecuteNonQuery();
            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return retval;
        }
        public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteNonQuery(transaction, commandType, commandText, (SqlParameter[])null);
        }
        public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            //finally, execute the command.
            int retval = cmd.ExecuteNonQuery();
            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return retval;
        }
        #endregion ExecuteNonQuery
        #region ExecuteDataSet
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteDataset(connectionString, commandType, commandText, (SqlParameter[])null);
        }
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create & open a SqlConnection, and dispose of it after we are done.
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                //call the overload that takes a connection in place of the connection string
                return ExecuteDataset(cn, commandType, commandText, commandParameters);
            }
        }

        public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteDataset(connection, commandType, commandText, (SqlParameter[])null);
        }
        public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            //create the DataAdapter & DataSet
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            //fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds);
            // detach the SqlParameters from the command object, so they can be used again.   
            cmd.Parameters.Clear();
            //return the dataset
            return ds;
        }
        public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteDataset(transaction, commandType, commandText, (SqlParameter[])null);
        }
        public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            //create the DataAdapter & DataSet
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            //fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds);
            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            //return the dataset
            return ds;
        }
        #endregion ExecuteDataSet
        #region ExecuteDataTable
        public static DataTable ExecuteDataTable(string connectionString, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteDataTable(connectionString, commandType, commandText, (SqlParameter[])null);
        }
        public static DataTable ExecuteDataTable(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create & open a SqlConnection, and dispose of it after we are done.
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                //call the overload that takes a connection in place of the connection string
                return ExecuteDataTable(cn, commandType, commandText, commandParameters);
            }
        }
        public static DataTable ExecuteDataTable(SqlConnection connection, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteDataTable(connection, commandType, commandText, (SqlParameter[])null);
        }

        public static DataTable ExecuteDataTable(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            /*
            //create a command and prepare it for execution
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 60;
            //PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
   
            //create the DataAdapter & DataTable
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);   
            DataTable dt = new DataTable();
            */
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            //create the DataAdapter & DataTable
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //fill the DataTable using default values for DataTable names, etc.
            da.Fill(dt);
            // detach the SqlParameters from the command object, so they can be used again.   
            cmd.Parameters.Clear();
            //return the DataTable
            return dt;
        }

        public static DataTable ExecuteDataTable(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteDataTable(transaction, commandType, commandText, (SqlParameter[])null);
        }

        public static DataTable ExecuteDataTable(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            //create the DataAdapter & DataTable
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //fill the DataTable using default values for DataTable names, etc.
            da.Fill(dt);
            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            //return the DataTable
            return dt;
        }
        #endregion ExecuteDataTable
        #region ExecuteReader
        private enum SqlConnectionOwnership
        {
            /// <summary>Connection is owned and managed by SqlHelper</summary>
            Internal,
            /// <summary>Connection is owned and managed by the caller</summary>
            External
        }

        private static SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, SqlConnectionOwnership connectionOwnership)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters);
            //create a reader
            SqlDataReader dr;
            // call ExecuteReader with the appropriate CommandBehavior
            if (connectionOwnership == SqlConnectionOwnership.External)
            {
                dr = cmd.ExecuteReader();
            }
            else
            {
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return dr;
        }
        public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteReader(connectionString, commandType, commandText, (SqlParameter[])null);
        }
        public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create & open a SqlConnection
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            try
            {
                //call the private overload that takes an internally owned connection in place of the connection string
                return ExecuteReader(cn, null, commandType, commandText, commandParameters, SqlConnectionOwnership.Internal);
            }
            catch
            {
                //if we fail to return the SqlDatReader, we need to close the connection ourselves
                cn.Close();
                throw;
            }
        }

        public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteReader(connection, commandType, commandText, (SqlParameter[])null);
        }
        public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //pass through the call to the private overload using a null transaction value and an externally owned connection
            return ExecuteReader(connection, (SqlTransaction)null, commandType, commandText, commandParameters, SqlConnectionOwnership.External);
        }
        public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteReader(transaction, commandType, commandText, (SqlParameter[])null);
        }
        public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //pass through to private overload, indicating that the connection is owned by the caller
            return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, SqlConnectionOwnership.External);
        }
        #endregion ExecuteReader
        #region ExecuteScalar
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteScalar(connectionString, commandType, commandText, (SqlParameter[])null);
        }
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create & open a SqlConnection, and dispose of it after we are done.
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                //call the overload that takes a connection in place of the connection string
                return ExecuteScalar(cn, commandType, commandText, commandParameters);
            }
        }
        public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteScalar(connection, commandType, commandText, (SqlParameter[])null);
        }
        public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            //execute the command & return the results
            object retval = cmd.ExecuteScalar();
            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return retval;
        }
        /// <summary>
        ///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount");
        /// </remarks>
        /// <param name="transaction">a valid SqlTransaction</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteScalar(transaction, commandType, commandText, (SqlParameter[])null);
        }
        /// <summary>
        /// <param name="transaction">a valid SqlTransaction</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            //execute the command & return the results
            object retval = cmd.ExecuteScalar();
            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return retval;
        }
        #endregion ExecuteScalar
        #region ExecuteXmlReader
        public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteXmlReader(connection, commandType, commandText, (SqlParameter[])null);
        }
        public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            //create the DataAdapter & DataSet
            XmlReader retval = cmd.ExecuteXmlReader();
            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return retval;
        }

        public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteXmlReader(transaction, commandType, commandText, (SqlParameter[])null);
        }

        public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            //create the DataAdapter & DataSet
            XmlReader retval = cmd.ExecuteXmlReader();
            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return retval;
        }
        #endregion ExecuteXmlReader
    }
}