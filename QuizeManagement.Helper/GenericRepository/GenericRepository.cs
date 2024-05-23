using QuizeManagement.Models.DbContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Helper.GenericRepository
{
    public class GenericRepository
    {
        public static DataTable GetSingleDataTable(string commandText, Dictionary<string,object> parameters)
        {
            DataTable _dataTable = new DataTable();

            using (QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities())
            {
                string connectionString = _context.Database.Connection.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 120;

                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                            }
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(_dataTable);
                        }
                    }
                }
            }

            return _dataTable;
        }
    }
}
