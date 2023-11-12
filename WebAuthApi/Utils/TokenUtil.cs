using Microsoft.IdentityModel.Tokens;
using Service.Model;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IdentityProviderApi.Utils
{
    public class TokenUtil
    {
        public static string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.Get("Jwt:Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //expiration duration
            int tokenExpiry = Convert.ToInt16(AppSettings.Get("Jwt:LifeTime"));
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddMinutes(tokenExpiry);

            var tokenHandler = new JwtSecurityTokenHandler();
            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Role, userInfo.UserType?.Desc),
                new Claim(ClaimTypes.Name, userInfo.UserName),
                new Claim("Id", userInfo.Id.ToString()),
            });
            var token = tokenHandler.CreateJwtSecurityToken(
                issuer: AppSettings.Get("Jwt:Issuer"),
                audience: AppSettings.Get("Jwt:Audience"),
                subject: claimsIdentity,
                notBefore: issuedAt,
                expires: expires,
                signingCredentials: credentials);

            return tokenHandler.WriteToken(token);
        }
    }
}
