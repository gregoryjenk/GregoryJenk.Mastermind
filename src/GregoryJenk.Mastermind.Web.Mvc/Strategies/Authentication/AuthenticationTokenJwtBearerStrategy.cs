using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Service.Strategies.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GregoryJenk.Mastermind.Web.Mvc.Strategies.Authentication
{
    public class AuthenticationTokenJwtBearerStrategy : IAuthenticationTokenStrategy
    {
        private readonly string _issuerSigningKey;
        private readonly string _validAudience;

        public AuthenticationTokenJwtBearerStrategy(IOptions<AuthenticationTokenJwtBearerStrategyOption> authenticationTokenJwtBearerStrategyOption)
        {
            _issuerSigningKey = authenticationTokenJwtBearerStrategyOption.Value.IssuerSigningKey;
            _validAudience = authenticationTokenJwtBearerStrategyOption.Value.ValidAudience;
        }

        public AuthenticationTokenStrategyResult Create(UserViewModel userViewModel)
        {
            var id = userViewModel.Id.ToString();
            var created = userViewModel.Created.ToString();
            var updated = userViewModel.Updated.ToString();
            var deleted = userViewModel.Deleted.ToString();
            var version = userViewModel.Version.ToString();

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Sid, id),
                new Claim("Created", created),
                new Claim("Updated", updated),
                new Claim("Deleted", deleted),
                new Claim(ClaimTypes.Version, version),
                new Claim(ClaimTypes.Name, userViewModel.Name),
                new Claim(ClaimTypes.Email, userViewModel.Email),
                new Claim("Scheme", userViewModel.Scheme),
                new Claim("Image", userViewModel.Image),
                new Claim("ExternalId", userViewModel.ExternalId)
            };

            var expires = DateTime.UtcNow.AddDays(30);

            var issuerSigningKeyBytes = Encoding.UTF8.GetBytes(_issuerSigningKey);

            var symmetricSecurityKey = new SymmetricSecurityKey(issuerSigningKeyBytes);

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken("GregoryJenk.Mastermind.Web.Mvc", _validAudience, claims, DateTime.UtcNow, expires, signingCredentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new AuthenticationTokenStrategyResult()
            {
                Scheme = AuthenticationStrategyConstant.BearerScheme,
                Token = token,
                Expired = jwtSecurityToken.ValidTo
            };
        }
    }
}