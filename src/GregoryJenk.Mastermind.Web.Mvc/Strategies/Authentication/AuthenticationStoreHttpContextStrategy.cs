using GregoryJenk.Mastermind.Service.Strategies.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Strategies.Authentication
{
    public class AuthenticationStoreHttpContextStrategy : IAuthenticationStoreStrategy
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationStoreHttpContextStrategy(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public AuthenticationStoreStrategyItem Get()
        {
            var scheme = Get(AuthenticationStrategyConstant.SchemeKey);
            var token = Get(AuthenticationStrategyConstant.TokenKey);

            return new AuthenticationStoreStrategyItem()
            {
                Scheme = scheme,
                Token = token
            };
        }

        public void Set(AuthenticationTokenStrategyResult authenticationTokenStrategyResult, bool updateClient = false)
        {
            var scheme = authenticationTokenStrategyResult.Scheme;
            var token = authenticationTokenStrategyResult.Token;
            var expired = authenticationTokenStrategyResult.Expired;

            Set(AuthenticationStrategyConstant.SchemeKey, scheme, expired, updateClient);
            Set(AuthenticationStrategyConstant.TokenKey, token, expired, updateClient);
        }

        private string Get(string key)
        {
            if (_httpContextAccessor.HttpContext.Items.ContainsKey(key))
            {
                var item = _httpContextAccessor.HttpContext.Items.Single(item => item.Key as string == key);

                return item.Value as string;
            }
            else
            {
                var cookie = _httpContextAccessor.HttpContext.Request.Cookies.SingleOrDefault(cookie => cookie.Key == key);

                return cookie.Value;
            }
        }

        private void Set(string key, string value, DateTimeOffset expired, bool updateClient)
        {
            if (_httpContextAccessor.HttpContext.Items.ContainsKey(key))
            {
                _httpContextAccessor.HttpContext.Items.Remove(key);
            }

            _httpContextAccessor.HttpContext.Items.Add(key, value);

            if (updateClient)
            {
                var cookieOptions = new CookieOptions()
                {
                    Expires = expired,
                    HttpOnly = false,
                    SameSite = SameSiteMode.Strict,
                    Secure = true
                };

                _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, cookieOptions);
            }
        }
    }
}