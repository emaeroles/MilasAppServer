﻿using API.Response;
using Application.DTOs.Auth;
using Application.Enums;
using Application.UseCases.User;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("user")]
        public async Task<IActionResult> AuthUser(
            [FromBody] AuthInput authInput,
            IValidator<AuthInput> validator,
            AuthUserUseCase authUserUseCase,
            IConfiguration _configuration)
        {
            var validResult = await validator.ValidateAsync(authInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await authUserUseCase.Execute(authInput.Username, authInput.Password);

            if (appResult.ResultState == ResultState.Authorized)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var bytekey = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!);
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, authInput.Username),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.String)
                    }),
                    Expires = DateTime.UtcNow.AddMonths(int.Parse(_configuration["JwtSettings:TokenExpiryInMonths"]!)),
                    Issuer = _configuration["JwtSettings:Issuer"],
                    Audience = _configuration["JwtSettings:Audience"],
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(bytekey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescription);
                var tokenString = tokenHandler.WriteToken(token);

                Response.Cookies.Append("token", tokenString, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Path = "/",
                    Expires = DateTime.UtcNow.AddMonths(int.Parse(_configuration["JwtSettings:TokenExpiryInMonths"]!))
                });

                return Ok(new ApiResponse(StatusCodes.Status200OK, appResult.Message, appResult.Data));
            }
            return Unauthorized(new ApiResponse(StatusCodes.Status401Unauthorized, appResult.Message, null));
        }
    }
}
