using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskPractice.ModelLayer.Entity;
using TaskPractice.Models;
using TaskPractice.RequestResponse.Account;

namespace TaskPractice.OAuth
{
    public class UserService : IUserService
    {
        TaskPracticeDBContext _dbContext;

        private readonly IConfiguration _config;
        public UserService(IConfiguration config, TaskPracticeDBContext db)
        {
            _config = config;
            _dbContext = db;    
        }

        public User AddUser(User user)
        {
             _dbContext.Add(user);

            _dbContext.SaveChanges();
            return user;

        }

        public User Authenticate(LoginRequest user)
        {
            if (user.password == "123456" && user.username == "mertaltintas")
            {
                var mUser = new ModelLayer.Entity.User()
                {
                    id = 123456,
                    password = user.password,
                    username = user.username
                };

                mUser.authToken = BuildJwtToken(mUser);


                return mUser;
            }
            return null;
        }

        private string BuildJwtToken(User mUser)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>(){
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim("userId",mUser.id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

  
    }
}
