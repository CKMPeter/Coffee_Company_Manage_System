using CoffeeCompanyMS.Forms.Authentication;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS.DAOs
{
    /// <summary>
    /// BaseDAO is an abstract class that provides common database access methods.
    /// It uses the Template Method Pattern,
    /// which defines the skeleton of general algorithm for executing queries:
    /// Getting a connection, executing a command, and handling exceptions.
    /// </summary>
    internal abstract class BaseDAO
    {
        protected SqlConnection GetConnection()
        {
            return UserSession.Instance.ConnectionFactory.CreateConnection();
        }

        protected List<T> ExecuteQuery<T>(string query, Func<SqlDataReader, T> mapper, Dictionary<string, object> parameters = null)
        {
            List<T> result = new List<T>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(mapper(reader));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Query failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        protected bool ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Command failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        protected object ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Scalar query failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
