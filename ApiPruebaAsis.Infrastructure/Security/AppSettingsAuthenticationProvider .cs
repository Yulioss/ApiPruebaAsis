using ApiPruebaAsis.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Infrastructure.Security
{
    public class AppSettingsAuthenticationProvider : IAuthenticationProvider
    {
        private readonly IConfiguration _configuration;

        public AppSettingsAuthenticationProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Validate(string username, string password)
        {
            var auth = _configuration.GetSection("Authentication");

            return username == auth["Username"]
                && password == auth["Password"];
        }

    }
}
