using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Core;
using Entities.Admin;
using Entities.Core;
using Microsoft.Data.SqlClient;
using Repository.Admin.Interface;

namespace Repository.Admin
{
    public class UserRepository:IUserRepository
    {
        private readonly CoreSQLDbHelper _sqlHelper;

        public UserRepository(CoreSQLDbHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        public async Task AddAsync(User user)
        {
            var query = @"Insert Into core.userM( userId, userName, userPassword, panNo, adharCardNo, phoneNo, address, stateId, nationId, isActive,, )
                            Values(  @userId, @userName, @userPassword, @panNo, @adharCardNo, @phoneNo, @address, @stateId, @nationId, @isActive )";

            var parameters = GetSqlParameters(user);
            _sqlHelper.ExecuteNonQuery(query, parameters);
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(long id)
        {
            var query = "DELETE FROM core.CompanyM WHERE id = @Id";
            var parameters = new[] { new SqlParameter("@Id", id) };
            _sqlHelper.ExecuteNonQuery(query, parameters);
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var query = "SELECT * FROM core.userM";
            var dataTable = _sqlHelper.ExecuteQuery(query);
            var users = new List<User>();

            foreach (DataRow row in dataTable.Rows)
            {
                users.Add(MapDataRowToUser(row));
            }

            return await Task.FromResult(users);
        }
        public async Task<User> GetByIdAsync(long id)
        {
            var query = "SELECT * FROM core.userM WHERE id = @Id";
            var parameters = new[] { new SqlParameter("@Id", id) };
            var dataTable = _sqlHelper.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count == 0) return null;

            return await Task.FromResult(MapDataRowToUser(dataTable.Rows[0]));
        }
        public async Task UpdateAsync(User user)
        {
            var query = @"Update core.userM set 
                              userId = @userId
                            , userName = @userName
                            , userPassword = @userPassword
                            , panNo = @panNo
                            , adharCardNo = @adharCardNo
                            , phoneNo = @phoneNo
                            , address = @address
                            , stateId = @stateId
                            , nationId = @nationId
                            , isActive = @isActive
                            WHERE id = @id";

            var parameters = GetSqlParameters(user);
            _sqlHelper.ExecuteNonQuery(query, parameters);
            await Task.CompletedTask;
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


        private static SqlParameter[] GetSqlParameters(User User)
        {
            return new[]
            {
                new SqlParameter("@id",User.id),
                new SqlParameter("@userId",User.userId),
                new SqlParameter("@userName",User.userName),
                new SqlParameter("@userPassword",User.userPassword ?? (object)DBNull.Value),
                new SqlParameter("@panNo",User.panNo ?? (object)DBNull.Value),
                new SqlParameter("@adharCardNo",User.adharCardNo ?? (object)DBNull.Value),
                new SqlParameter("@phoneNo",User.phoneNo ?? (object)DBNull.Value),
                new SqlParameter("@address",User.address ?? (object)DBNull.Value),
                new SqlParameter("@stateId",User.stateId ?? (object)DBNull.Value),
                new SqlParameter("@nationId",User.nationId ?? (object)DBNull.Value),
                new SqlParameter("@isActive",User.isActive)
                };
        }
    }
}
