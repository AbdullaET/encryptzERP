using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using encrypzERP.BL.Services;

[ApiController]
[Route("[controller]")]
public class OtpController : ControllerBase
{
    private readonly emailService _emailService;

    public OtpController(emailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> SendOtp(string email)
    {
        // Generate a 6-digit OTP
        string otp = GenerateOTP(6);

        // Send OTP via email
        string subject = "Your OTP Code";
        string message = $"Your OTP is: {otp}";

        await _emailService.SendOtpEmailAsync(email, subject, message);

        // Optionally, store the OTP in session or database for later verification

        return Ok(new { Message = "OTP sent successfully", OTP = otp });
    }

    private string GenerateOTP(int length)
    {
        var random = new Random();
        string otp = string.Empty;

        for (int i = 0; i < length; i++)
        {
            otp += random.Next(0, 10); // Generates a digit from 0 to 9
        }

        return otp;
    }
}
