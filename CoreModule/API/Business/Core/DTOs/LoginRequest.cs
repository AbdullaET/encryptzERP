using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Core.DTOs
{
    public class LoginRequest
    {
        public string UserId { get; set; }=string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class RefreshTokenRequest
    {
        public string UserId { get; set; }
        public string RefreshToken { get; set; }
    }


}
