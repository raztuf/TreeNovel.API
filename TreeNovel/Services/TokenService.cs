using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interface;
using TreeNovel.Models;
using LocalModel.Models;
using LocalModel.Services.Interface;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace TreeNovel.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;
        private IUserService _userService;

        public TokenService(IOptions<AppSettings> app, IUserService userService)
        {
            _appSettings = app.Value;
            _userService = userService;
        }

        public UserToken Authenticate(string mail, string password)
        {
            User user;
            if (_userService.CheckUser(new User { Mail = mail, Password = password }) == true)
            {
                user = _userService.GetByMail(mail);
            }
            else return null;

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserToken
            {
                Id = user.Id,
                Username = user.Username,
                Mail = user.Mail,
                IsActive = user.IsActive,
                IsAdmin = user.IsAdmin,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
