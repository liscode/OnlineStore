using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// This class connects to SQL
    /// </summary>
    public class DbConnection
    {
        // SqlConnection class member
        private SqlConnection sqlConn;

        public DbConnection(string conString)
        {
            // Create an object of SqlConnection class
            this.sqlConn = new SqlConnection(conString);
        }

        // Opens connection to DB
        public void OpenDBConnection()
        {
            try
            {
                sqlConn.Open();
            }
            catch (SqlException e)
            {
                throw new Exception("Error during OpenConnection\n" + e.Message);
            }
        }

        // Close connection to DB
        public void CloseDBConnection()
        {
            try
            {
                sqlConn.Close();
            }
            catch (SqlException e)
            {
                throw new Exception("Error during CloseConnection\n" + e.Message);
            }
        }

        /// <summary>
        /// Receive the query and return answer in a dataTable
        /// </summary>
        /// <param name="sql">The query</param>
        /// <param name="parameters">A dictionary contains key-values parameters for the query</param>
        /// <returns>Query results</returns>
        public DataTable Query(string sql, SqlParameterCollection parameters = null)
        {
            DataTable myDT = new DataTable();
            using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
            {
                if (parameters != null)
                {
                    // Loop on each parameter (in order to add as SqlParameter)
                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                this.OpenDBConnection();
                SqlDataReader dataReader = null;

                try
                {
                    dataReader = cmd.ExecuteReader();
                    // Load results to datatable
                    myDT.Load(dataReader);
                }
                catch (SqlException e)
                {
                    throw new Exception("Error during Data reading: \n" + e.Message);
                }
                finally
                {
                    dataReader.Close();
                }

                this.CloseDBConnection();
                return myDT;
            }
        }

        /// <summary>
        /// Get a stored procedure name and return answer in a dataTable
        /// </summary>
        /// <param name="spName">Stored procedure name</param>
        /// <returns>Stored procedure results</returns>
        public DataTable ExecSP(string spName, List<SqlParameter> parameters = null)
        {
            DataTable myDT = new DataTable();
            using (var cmd = new SqlCommand(spName, sqlConn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                if (parameters != null)
                {
                    // Loop on each parameter (in order to add as SqlParameter)
                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                this.OpenDBConnection();

                SqlDataReader dataReader = cmd.ExecuteReader();
                try
                {
                    myDT.Load(dataReader);
                }
                catch (SqlException e)
                {
                    throw new Exception("Error during Data reading\n" + e.Message);
                }
                finally
                {
                    dataReader.Close();
                }

                this.CloseDBConnection();
                return myDT;
            }
        }

    }
}

