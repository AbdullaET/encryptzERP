using encrypzERP.BL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypzERP.BL.dbContexts
{
    public class coreDBContext:IDisposable
    {
        private readonly string _connectionString;
        public coreDBContext(string connectionString) {
            _connectionString = connectionString;
        }
        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }


        public async Task<List<mUsers>> GetUsersAsync()
        {
            var users = new List<mUsers>();

            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM mUsers", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            users.Add(new mUsers
                            {
                                pkUserId = reader.GetInt32(0),
                                userId = reader.GetString(1),
                                // Map other properties
                            });
                        }
                    }
                }
            }

            return users;
        }

        // Example: Add a new account
        public async Task AddUsersAsync(mUsers users)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("INSERT INTO mUsers (pkUserId) VALUES (@pkUserId)", connection))
                {
                    command.Parameters.AddWithValue("@pkUserId", users.pkUserId);
                    // Add other parameters as needed

                    await command.ExecuteNonQueryAsync();
                }
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
