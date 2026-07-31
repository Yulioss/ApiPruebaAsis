using ApiPruebaAsis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        LoginResponseDto GenerateToken(string username);
    }
}
