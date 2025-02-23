﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Core.DTOs;

namespace BusinessLogic.Core.Interface
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
        Task<bool> LogoutAsync(string userId);
        Task<LoginResponse> RefreshTokenAsync(RefreshTokenRequest refreshTokenRequest);
        Task<bool> SaveOTP(int userId, string otp);
        Task<bool> VerifyOTP(int userId, string otp);
        Task<bool> ChangePassword(int userId, string newPassword);
        Task<int?> GetUserIdByEmail(string email);
    }
}
