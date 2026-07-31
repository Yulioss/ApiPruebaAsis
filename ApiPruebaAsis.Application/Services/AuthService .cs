using ApiPruebaAsis.Application.DTOs;
using ApiPruebaAsis.Application.Interfaces;

namespace ApiPruebaAsis.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(
            IAuthenticationProvider authenticationProvider,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _authenticationProvider = authenticationProvider;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            if (!_authenticationProvider.Validate(request.Username, request.Password))
            {
                throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
            }

            var token = _jwtTokenGenerator.GenerateToken(request.Username);

            return Task.FromResult(token);
        }
    }
}
