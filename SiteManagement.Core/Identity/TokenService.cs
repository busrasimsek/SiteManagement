using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SiteManagement.Core.Response.TokenResponse;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SiteManagement.Core.Identity
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //public Token GenerateToken(string userName, string role)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_configuration["Token:SecurityKey"]);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //        new Claim(ClaimTypes.Name, userName),
        //        new Claim(ClaimTypes.Role, role)
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(1), // Token'ın geçerlilik süresini buradan ayarlayabilirsiniz
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}


        public Token GenerateToken(int second, string username, string role)
        {
            Token token = new();

            //Security Key'in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
    {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };
            //Oluşturulacak token ayarlarını veriyoruz.
            token.Expiration = DateTime.Now.AddDays(second);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                NotBefore = DateTime.Now.AddMinutes(1),
                Subject = new ClaimsIdentity(claims),
                Expires = token.Expiration,
                Issuer = _configuration["Token:Issuer"],
                Audience = _configuration["Token:Audience"],
                SigningCredentials = signingCredentials,

            };
            //JwtSecurityToken securityToken = new(
            //    audience: _configuration["Token:Audience"],
            //    issuer: _configuration["Token:Issuer"],
            //    expires: token.Expiration,
            //    notBefore: DateTime.Now,
            //    signingCredentials: signingCredentials,
            //    claims: new List<Claim> {
            //        new (ClaimTypes.Name, username),
            //        new (ClaimTypes.Role, role)}
            //    );

            //Token oluşturucu sınıfından bir örnek alalım.
            JwtSecurityTokenHandler tokenHandler = new();
            var jwtToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            token.AccessToken = tokenHandler.WriteToken(jwtToken);

            //string refreshToken = CreateRefreshToken();

            //token.RefreshToken = CreateRefreshToken();
            return token;
        }


    }
}
