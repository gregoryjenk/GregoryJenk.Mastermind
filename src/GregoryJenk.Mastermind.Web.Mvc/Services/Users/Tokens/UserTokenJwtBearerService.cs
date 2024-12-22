using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Message.ViewModels.Users.Tokens;
using GregoryJenk.Mastermind.Web.Mvc.Options.Authentication.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GregoryJenk.Mastermind.Web.Mvc.Services.Users.Tokens
{
    public class UserTokenJwtBearerService : IUserTokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOptions<JwtAuthenticationOption> _jwtAuthenticationOption;

        public UserTokenJwtBearerService(IHttpContextAccessor httpContextAccessor, IOptions<JwtAuthenticationOption> jwtAuthenticationOption)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtAuthenticationOption = jwtAuthenticationOption;
        }

        public UserTokenViewModel Create(UserViewModel userViewModel)
        {
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, userViewModel.Name),
                new Claim(ClaimTypes.Email, userViewModel.Email),
                new Claim("Scheme", userViewModel.Scheme),
                new Claim("ExternalId", userViewModel.ExternalId),
                new Claim("Image", userViewModel.Image)
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                audience: _jwtAuthenticationOption.Value.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(2),
                issuer: "GregoryJenk.Mastermind.Web.Mvc",
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAuthenticationOption.Value.IssuerSigningKey)), SecurityAlgorithms.HmacSha256)
            );

            CookieOptions cookieOptions = new CookieOptions()
            {
                Expires = jwtSecurityToken.ValidTo
            };

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            _httpContextAccessor.HttpContext.Response.Cookies.Append("GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc.JwtToken.Scheme", "Bearer", cookieOptions);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc.JwtToken.Value", token, cookieOptions);

            return new UserTokenViewModel()
            {
                Scheme = "Bearer",
                Value = token
            };
        }

        public void Delete()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc.JwtToken.Scheme");
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc.JwtToken.Value");
        }

        public UserTokenViewModel Read()
        {
            return new UserTokenViewModel()
            {
                Scheme = ReadScheme(),
                Value = ReadValue()
            };
        }

        private string ReadScheme()
        {
            return _httpContextAccessor.HttpContext.Request.Cookies
                .SingleOrDefault(x => x.Key == "GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc.JwtToken.Scheme").Value;
        }

        private string ReadValue()
        {
            return _httpContextAccessor.HttpContext.Request.Cookies
                .SingleOrDefault(x => x.Key == "GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc.JwtToken.Value").Value;
        }
    }
}