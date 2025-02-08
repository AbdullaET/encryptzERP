using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Data.Core;
using Entities.Admin;
using Microsoft.Data.SqlClient;
using Repository.Core.Interface;

namespace Repository.Core
{
    public class LoginRepository : ILoginRepository
    {
        private readonly CoreSQLDbHelper _sqlHelper;        
        public LoginRepository(CoreSQLDbHelper coreSQLDbHelper)
        {
            _sqlHelper = coreSQLDbHelper;
            
        }
        public Task<User> LoginAsync(string userId, string password)
        {
            try
            {
                User user = new User();
                var query = "SELECT * FROM core.userM WHERE userId = @userId and userPassword= @userPassword";
                var parameters = new[] { 
                    new SqlParameter("@userId",userId),
                    new SqlParameter("@userPassword",password) 
                };
                var dataTable = _sqlHelper.ExecuteQuery(query, parameters);

                if (dataTable.Rows.Count == 0) return Task.FromResult(user);

                user = MapDataRowToUser(dataTable.Rows[0]);
                return Task.FromResult(user);
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static User MapDataRowToUser(DataRow row)
        {
            return new User
            {
                id = Convert.ToInt64(row["id"]),
                userId = Convert.ToString(row["userId"]),
                userName = Convert.ToString(row["userName"]),
                userPassword = row["userPassword"].ToString(),
                panNo = row["panNo"].ToString(),
                adharCardNo = row["adharCardNo"].ToString(),
                phoneNo = row["phoneNo"].ToString(),
                address = row["address"].ToString(),
                stateId = row["stateId"] as int?,
                nationId = row["nationId"] as int?,
                isActive = Convert.ToBoolean(row["isActive"])
            };
        }
    }
}
