using System.Security.Claims;
using System.Text;
using CadastroDeUsuarios.Domain.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace CadastroDeUsuarios.Application.Auth
{
    public class TokenService
    {
        public string GenerateToken(Usuario UserCadastro)
        {
            var key = Encoding.ASCII.GetBytes(Settings.Key);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                      new Claim("UserCadastroId", UserCadastro.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenHandler.WriteToken(token);

        }
    }
}
