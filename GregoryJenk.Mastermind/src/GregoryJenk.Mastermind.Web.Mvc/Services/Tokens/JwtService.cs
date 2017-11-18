using GregoryJenk.Mastermind.Message.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace GregoryJenk.Mastermind.Web.Mvc.Services.Tokens
{
    public class JwtService : ITokenService
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public JwtService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Create(UserViewModel userViewModel, string scheme)
        {
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, userViewModel.Name),
                new Claim(ClaimTypes.Email, userViewModel.Email),
                new Claim("Scheme", scheme),
                new Claim("ExternalId", userViewModel.ExternalId),
                new Claim("Image", userViewModel.Image)
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                //TODO: Configure token properties.
                audience: "http://localhost:50793/",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(2),
                issuer: "GregoryJenk.Mastermind.Web.Mvc",
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("foobarfoobarfoobarfoobar")), SecurityAlgorithms.HmacSha256)
            );

            CookieOptions cookieOptions = new CookieOptions()
            {
                Expires = jwtSecurityToken.ValidTo
            };

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            _httpContextAccessor.HttpContext.Response.Cookies.Append("GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc.JwtToken.Scheme", "Bearer", cookieOptions);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc.JwtToken.Value", token, cookieOptions);
        }

        public void Delete()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc.JwtToken.Scheme");
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc.JwtToken.Value");
        }
    }
}