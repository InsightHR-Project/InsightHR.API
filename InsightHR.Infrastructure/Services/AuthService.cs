using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Shared.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        public async Task<ApiResponse<string>> Register(RegisterDto user)
        {
            await _authRepository.Register(user);
            return ApiResponse<string>.Ok("User registered successfully.", "Registration completed");
        }

        public async Task<ApiResponse<AuthResponseDto>> Login(LoginDto login)
        {
            var user = await _authRepository.Login(login.Email.Trim());

            if (user == null)
                return ApiResponse<AuthResponseDto>.Fail("Invalid credentials", 401);

            // 🔹 Debug: Check password hash manually
            string storedHash = (string)user.password_hash;
            bool validPassword = BCrypt.Net.BCrypt.Verify(login.Password, storedHash);

            Console.WriteLine($"DEBUG: Login attempt for {login.Email}");
            Console.WriteLine($"DEBUG: Entered password: {login.Password}");
            Console.WriteLine($"DEBUG: Stored hash: {storedHash}");
            Console.WriteLine($"DEBUG: Password valid? {validPassword}");

            if (!validPassword)
                return ApiResponse<AuthResponseDto>.Fail("Invalid credentials", 401);

            string token = GenerateJwtToken(user);

            var response = new AuthResponseDto
            {
                FirstName = user.first_name,
                Email = user.email,
                Role = user.role_name,
                Token = token,
            };

            return ApiResponse<AuthResponseDto>.Ok(response, "Login successful");
        }




        private string GenerateJwtToken(dynamic user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                    new Claim(ClaimTypes.Email, user.email),
                    new Claim(ClaimTypes.Name, user.first_name),
                    new Claim(ClaimTypes.Role, user.role_name)
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
