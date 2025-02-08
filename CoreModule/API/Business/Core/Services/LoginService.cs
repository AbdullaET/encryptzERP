using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using BusinessLogic.Core.DTOs;
using BusinessLogic.Core.Interface;
using Repository.Core.Interface;

namespace BusinessLogic.Core.Services
{
    public class LoginService:ILoginService
    {
       private readonly ILoginRepository _loginRepository;
        private readonly TokenService _tokenService;
        private static Dictionary<string, string> _refreshTokens = new();
        public LoginService(ILoginRepository logingRepository, TokenService tokenService) {
            _loginRepository = logingRepository;
            _tokenService = tokenService;
        }

       public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            try
            {
                LoginResponse response = new LoginResponse();
                if (string.IsNullOrEmpty(loginRequest.UserId) || string.IsNullOrEmpty(loginRequest.Password))
                {
                    return response;
                }

                var result = await _loginRepository.LoginAsync(loginRequest.UserId, loginRequest.Password);
                if (result.id <= 0)
                {
                    return response;
                }

                if (result.userName == "admin")
                {
                    response.Token = _tokenService.GenerateAccessToken(loginRequest.UserId, "Admin"); // Admin role
                    response.RefreshToken = _tokenService.GenerateRefreshToken();
                    return response;
                }
                else
                {
                    response.Token = _tokenService.GenerateAccessToken(loginRequest.UserId, "User"); // User role
                    response.RefreshToken = _tokenService.GenerateRefreshToken();
                }
                _refreshTokens[loginRequest.UserId] = response.RefreshToken;
                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }

       public async Task<bool> LogoutAsync(int userId)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<LoginResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            try
            {
                LoginResponse loginResponse = new LoginResponse();
                if (_refreshTokens.TryGetValue(request.UserId, out var savedRefreshToken) &&
                savedRefreshToken == request.RefreshToken)
                {
                    loginResponse.Token = _tokenService.GenerateAccessToken(request.UserId, "Admin");
                    loginResponse.RefreshToken = _tokenService.GenerateRefreshToken();

                    // Update refresh token
                    _refreshTokens[request.UserId] = loginResponse.RefreshToken;

                    return Task.FromResult(loginResponse);
                }
                return Task.FromResult(loginResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
