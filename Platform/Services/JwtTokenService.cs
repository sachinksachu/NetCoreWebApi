using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetCoreWebApi.Platform.Models.Configurations;
using NetCoreWebApi.Platform.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtTokenService : IJwtTokenService
{
    private readonly JwtConfig _jwtConfig;

    public JwtTokenService(IOptions<JwtConfig> jwtConfig)
    {
        _jwtConfig = jwtConfig.Value;
    }

    public string GenerateToken(string userId, string username)
    {
        var tokenClaims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.NameId, userId),
            new(JwtRegisteredClaimNames.UniqueName, username),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        //if (claims != null)
        //    tokenClaims.AddRange(claims);

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtConfig.IssuerSigningKey));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtConfig.Issuer,
            audience: _jwtConfig.Audience,
            claims: tokenClaims,
            expires: DateTime.UtcNow.AddMinutes(_jwtConfig.ExpiryMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
