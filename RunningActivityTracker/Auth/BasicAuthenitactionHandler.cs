﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RunningActivityTracker.Entities;
using RunningActivityTracker.Services;

namespace RunningActivityTracker.Auth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // skip authentication if endpoint has [AllowAnonymous] or [AuthorizeWithTokenAttribute] attribute
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null || endpoint?.Metadata?.GetMetadata<AuthorizeWithTokenAttribute>() != null)
                return AuthenticateResult.NoResult();

            //implement your authentication logic here
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            var autorizationHeader = Request.Headers.Authorization.ToString();

            string userInfoEncoded = new string(autorizationHeader.Skip(6).ToArray()); // Remove the "Basic " start of the header value

            string userInfoDecoded = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(userInfoEncoded));

            string userName = userInfoDecoded.Split(":")[0];
            string password = userInfoDecoded.Split(":")[1];
            var user = _userService.GetAll().Where(user => user.Username == userName && user.Password == password).FirstOrDefault();
            

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            // add user roles as claims here
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }

        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Headers["WWW-Authenticate"] = "Basic realm=\"\", charset=\"UTF-8\"";
            return base.HandleChallengeAsync(properties);
        }
    }
}
