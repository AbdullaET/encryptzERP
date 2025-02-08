using System;
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
        Task<bool> LogoutAsync(int userId);
        Task<LoginResponse> RefreshTokenAsync(RefreshTokenRequest refreshTokenRequest);
    }
}
