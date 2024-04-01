using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Ports;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Jwt;

public class JwtService : IJwtServices
{
    private readonly JwtSettings _jwtSettings;

    public JwtService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }


    // Método para generar un token JWT para un usuario dado.
    public async Task<string> GenerateToken(User user)
    {
        // Definición de las claims (datos) que se incluirán en el token.
        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Identificador único del token
                new Claim("Uid", user.Id.ToString()), // ID del usuario
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName), // Nombre de usuario
            };

        // Creación de la clave de seguridad a partir de la clave secreta proporcionada.
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

        // Creación de las credenciales de firma para el token usando el algoritmo HmacSha256.
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        // Creación del token JWT con los parámetros proporcionados.
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer, // Emisor del token
            audience: _jwtSettings.Audience, // Destinatario del token
            claims: claims, // Datos del token
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes), // Fecha de expiración del token
            signingCredentials: signingCredentials // Credenciales de firma
        );

        // Escritura del token como una cadena.
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return token; // Devuelve el token JWT generado.
    }
}