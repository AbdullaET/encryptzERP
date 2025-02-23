using BusinessLogic.Admin.DTOs;
using BusinessLogic.Admin.Interface;
using BusinessLogic.Core.DTOs;
using BusinessLogic.Core.Interface;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace encryptzERP.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ExceptionHandler _exceptionHandler;
        private readonly EmailService _emailService;

        public LoginController(ILoginService loginService, ExceptionHandler exceptionHandler, EmailService emailService)
        {
            _loginService = loginService;
            _exceptionHandler = exceptionHandler;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var result = await _loginService.LoginAsync(loginRequest);
                if (result.Token == null || result.Token == "")
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogError(ex);
                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult> Logout(string userId)
        {
            try
            {
                var result = await _loginService.LogoutAsync(userId);
                if (!result)
                    return NotFound();
                return Ok($"{userId} logged out sccessfully..!");
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogError(ex);
                throw;
            }
        }

        [HttpPost("refresh")]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                LoginResponse loginResponse = new LoginResponse();

                loginResponse = await _loginService.RefreshTokenAsync(request);
                if (loginResponse.Token != null || loginResponse.Token == "")
                    return Unauthorized("Invalid or expired refresh token");

                return Ok(loginResponse);
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogError(ex);
                throw;
            }


        }

        //[HttpPost("send-otp")]
        //public async Task<IActionResult> SendOTP([FromBody] SendOtpRequest request)
        //{
        //    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        //    if (user == null)
        //        return BadRequest("User not found");

        //    // Generate 6-digit OTP
        //    var otp = new Random().Next(100000, 999999).ToString();
        //    var expiry = DateTime.UtcNow.AddMinutes(5);

        //    // Save OTP in DB
        //    var userOtp = new UserOTP
        //    {
        //        UserId = user.Id,
        //        OTP = otp,
        //        Expiry = expiry,
        //        IsUsed = false
        //    };

        //    _context.UserOTP.Add(userOtp);
        //    await _context.SaveChangesAsync();

        //    // Send OTP via Email (or SMS)
        //    await SendEmail(user.Email, otp);

        //    return Ok(new { Message = "OTP sent successfully" });
        //}

        //[HttpPost("verify-otp")]
        //public async Task<IActionResult> VerifyOTP([FromBody] VerifyOtpRequest request)
        //{
        //    var otpRecord = await _context.UserOTP
        //        .Where(o => o.UserId == request.UserId && o.OTP == request.OTP && o.IsUsed == false)
        //        .OrderByDescending(o => o.CreatedAt)
        //        .FirstOrDefaultAsync();

        //    if (otpRecord == null || otpRecord.Expiry < DateTime.UtcNow)
        //        return BadRequest("Invalid or expired OTP");

        //    // Mark OTP as used
        //    otpRecord.IsUsed = true;
        //    await _context.SaveChangesAsync();

        //    // Generate JWT Token
        //    var token = GenerateJwtToken(request.UserId);

        //    return Ok(new { Token = token, Message = "Login successful" });
        //}


    }
}
