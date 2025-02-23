using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Admin;



namespace Repository.Core.Interface
{
    public interface ILoginRepository
    {
        Task<User> LoginAsync(string userName,string password);
        Task<bool> SaveOTP(int userId, string otp);
        Task<bool> VerifyOTP(int userId, string otp);
        Task<bool> ChangePassword(int userId, string newPassword);
        Task<int?> GetUserIdByEmail(string email);
    }
}
