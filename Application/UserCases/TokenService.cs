using Domain.Entities;
using Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.UserCases;

public class TokenService:IToken
{
    public async Task<string> GenerateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("email",user.Email),
            new Claim("id",user.Id)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));
        var signCredential = new SigningCredentials(key: key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken
           (
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signCredential
           );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public async Task<string> TokenDecodeIdUser(string token)
    {
        if (token != null)
        {
            var jwtEnconding = token.Substring(7);
            var tokef = new JwtSecurityToken(jwtEnconding);
            string IdUser = tokef.Claims.First(c => c.Type == "id").Value;

            return IdUser;
        }
        throw new Exception("Token invalido");


    }

}
