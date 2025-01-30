using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Core;
using Entities.Core;
using Microsoft.Data.SqlClient;
using Repository.Core.Interface;

namespace Repository.Core
{
    public class BusinessRepository :IBusinessRepository
    {
        private readonly CoreSQLDbHelper _sqlHelper;

        public BusinessRepository(CoreSQLDbHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public async Task<IEnumerable<Business>> GetAllAsync()
        {
            var query = "SELECT * FROM core.businessM";
            var dataTable = _sqlHelper.ExecuteQuery(query);
            var businesses = new List<Business>();

            foreach (DataRow row in dataTable.Rows)
            {
                businesses.Add(MapDataRowToBusiness(row));
            }

            return await Task.FromResult(businesses);
        }

        public async Task<Business> GetByIdAsync(long id)
        {
            var query = "SELECT * FROM core.businessM WHERE id = @Id";
            var parameters = new[] { new SqlParameter("@Id", id) };
            var dataTable = _sqlHelper.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count == 0) return null;

            return await Task.FromResult(MapDataRowToBusiness(dataTable.Rows[0]));
        }

        public async Task AddAsync(Business business)
        {
            var query = @"INSERT INTO core.businessM (code, name, isActive, tanNo, panNo, businessTypeID, address, nationID, stateID, districtID, pin, gstin, epf, esi, phoneCountryCode, phoneNo) 
                          VALUES (@Code, @Name, @IsActive, @TanNo, @PanNo, @BusinessTypeId, @Address, @NationId, @StateId, @DistrictId, @Pin, @Gstin, @Epf, @Esi, @PhoneCountryCode, @PhoneNo)";

            var parameters = GetSqlParameters(business);
            _sqlHelper.ExecuteNonQuery(query, parameters);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Business business)
        {
            var query = @"UPDATE core.businessM SET code = @Code, name = @Name, isActive = @IsActive, tanNo = @TanNo, panNo = @PanNo, 
                          businessTypeID = @BusinessTypeId, address = @Address, nationID = @NationId, stateID = @StateId, districtID = @DistrictId, 
                          pin = @Pin, gstin = @Gstin, epf = @Epf, esi = @Esi, phoneCountryCode = @PhoneCountryCode, phoneNo = @PhoneNo 
                          WHERE id = @Id";

            var parameters = GetSqlParameters(business);
            _sqlHelper.ExecuteNonQuery(query, parameters);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(long id)
        {
            var query = "DELETE FROM core.businessM WHERE id = @Id";
            var parameters = new[] { new SqlParameter("@Id", id) };
            _sqlHelper.ExecuteNonQuery(query, parameters);
            await Task.CompletedTask;
        }

        private static Business MapDataRowToBusiness(DataRow row)
        {
            return new Business
            {
                Id = Convert.ToInt64(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                IsActive = Convert.ToBoolean(row["isActive"]),
                TanNo = row["tanNo"].ToString(),
                PanNo = row["panNo"].ToString(),
                BusinessTypeId = row["businessTypeID"] as int?,
                Address = row["address"].ToString(),
                NationId = row["nationID"] as int?,
                StateId = row["stateID"] as int?,
                DistrictId = row["districtID"] as int?,
                Pin = row["pin"].ToString(),
                Gstin = row["gstin"].ToString(),
                Epf = row["epf"].ToString(),
                Esi = row["esi"].ToString(),
                PhoneCountryCode = row["phoneCountryCode"].ToString(),
                PhoneNo = row["phoneNo"].ToString(),
            };
        }

        private static SqlParameter[] GetSqlParameters(Business business)
        {
            return new[]
            {
                new SqlParameter("@Id", business.Id),
                new SqlParameter("@Code", business.Code),
                new SqlParameter("@Name", business.Name ?? (object)DBNull.Value),
                new SqlParameter("@IsActive", business.IsActive),
                new SqlParameter("@TanNo", business.TanNo ?? (object)DBNull.Value),
                new SqlParameter("@PanNo", business.PanNo ?? (object)DBNull.Value),
                new SqlParameter("@BusinessTypeId", business.BusinessTypeId ?? (object)DBNull.Value),
                new SqlParameter("@Address", business.Address ?? (object)DBNull.Value),
                new SqlParameter("@NationId", business.NationId ?? (object)DBNull.Value),
                new SqlParameter("@StateId", business.StateId ?? (object)DBNull.Value),
                new SqlParameter("@DistrictId", business.DistrictId ?? (object)DBNull.Value),
                new SqlParameter("@Pin", business.Pin ?? (object)DBNull.Value),
                new SqlParameter("@Gstin", business.Gstin ?? (object)DBNull.Value),
                new SqlParameter("@Epf", business.Epf ?? (object)DBNull.Value),
                new SqlParameter("@Esi", business.Esi ?? (object)DBNull.Value),
                new SqlParameter("@PhoneCountryCode", business.PhoneCountryCode ?? (object)DBNull.Value),
                new SqlParameter("@PhoneNo", business.PhoneNo ?? (object)DBNull.Value)
            };
        }
    }
}
