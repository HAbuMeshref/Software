using Domain.Common;
using Domain.Models;
using Domain.Models.SearchCriteria;
using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly IHttpClientFactory _httpClient;
        private readonly SymmetricSecurityKey key;

        public UsersService(IRepositoryUnitOfWork repositoryUnitOfWork, IHttpClientFactory httpClient, IConfiguration config)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _httpClient = httpClient;

            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SharedSettings.Secret));


        }
        public IResponseResult<User> Add(User entity)
        {
            // var users = HashPassword(entity);
            //entity.Password = string.Join(",", users.HashPassword) ;
            //entity.ConfirmPassword = string.Join(",",users.PasswordSalt);

            try
            {
                _repositoryUnitOfWork.Users.Value.Add(entity);
                return new ResponseResult<User>() { Status = ResultStatus.Success, Data = entity };
            }

            catch (Exception ex)
            {
                return new ResponseResult<User>() { Status = ResultStatus.Failed, Data = null, Errors = new List<string>() { "Exception Message : " + ex.Message } };
            }
        }

        public IResponseResult<IEnumerable<User>> AddRange(IEnumerable<User> entities)
        {
            var result = _repositoryUnitOfWork.Users.Value.AddRange(entities);
            return new ResponseResult<IEnumerable<User>>() { Status = ResultStatus.Success, Data = result };
        }

        public IResponseResult<User> Get(long id)
        {
            try
            {
                var result = _repositoryUnitOfWork.Users.Value.Get(id);
                return new ResponseResult<User>() { Status = ResultStatus.Success, Data = result };
            }
            catch (Exception ex)
            {
                return new ResponseResult<User>() { Status = ResultStatus.Failed, Data = null, Errors = new List<string>() { "Exception Message : " + ex.Message } };
            }
        }

        public IResponseResult<IEnumerable<User>> GetAll()
        {
            using (_repositoryUnitOfWork)
            {
                try
                {


                    var result = _repositoryUnitOfWork.Users.Value.GetAll().ToList();
                    return new ResponseResult<IEnumerable<User>>() { Status = ResultStatus.Success, Data = result };
                }
                catch (Exception ex)
                {
                    return new ResponseResult<IEnumerable<User>>() { Status = ResultStatus.Failed, Data = null, Errors = new List<string>() { "Exception Message : " + ex.Message } };
                }
            }
        }

        public IResponseResult<User> Remove(User entity)
        {
            try
            {
                _repositoryUnitOfWork.Users.Value.Remove(entity);
                return new ResponseResult<User>() { Status = ResultStatus.Success, Data = entity };
            }
            catch (Exception ex)
            {
                return new ResponseResult<User>() { Status = ResultStatus.Failed, Data = null, Errors = new List<string>() { "Exception Message : " + ex.Message } };
            }
        }

        public IResponseResult<IEnumerable<User>> RemoveRange(IEnumerable<User> entities)
        {
            try
            {
                var result = _repositoryUnitOfWork.Users.Value.RemoveRange(entities);
                return new ResponseResult<IEnumerable<User>>() { Status = ResultStatus.Success, Data = result };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<User>>() { Status = ResultStatus.Failed, Data = null, Errors = new List<string>() { "Exception Message : " + ex.Message } };
            }
        }

        public IResponseResult<User> Update(User entity)
        {
            try
            {
                _repositoryUnitOfWork.Users.Value.Update(entity);
                return new ResponseResult<User>() { Status = ResultStatus.Success, Data = entity };
            }
            catch (Exception ex)
            {
                return new ResponseResult<User>() { Status = ResultStatus.Failed, Data = null, Errors = new List<string>() { "Exception Message : " + ex.Message } };
            }
        }

        public IResponseResult<IEnumerable<User>> UpdateRange(IEnumerable<User> entities)
        {
            try
            {
                _repositoryUnitOfWork.Users.Value.UpdateRange(entities);
                return new ResponseResult<IEnumerable<User>>() { Status = ResultStatus.Success, Data = entities };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<User>>() { Status = ResultStatus.Failed, Data = null, Errors = new List<string>() { "Exception Message : " + ex.Message } };
            }
        }
        // Not used 
        public UserDto HashPassword(User item)
        {
            if (item.Password == item.ConfirmPassword)
            {
                using var hmac = new HMACSHA512();
                var user = new UserDto
                {
                    Email = item.Email,
                    Nmae = item.Name,
                    HashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(item.Password)),
                    PasswordSalt = hmac.Key
                };
                return user;
            }
            else
            {
                return null;
            }
        }

        public User Login(Login login)
        {
            try
            {
                var user = _repositoryUnitOfWork.Users.Value.GetByEmail(login.Email);
                return user;
            }
            catch (Exception ex)
            {
                return null
            }
            //var splitPassword = user.Password.Split(",");
            //byte[] byteArray = splitPassword.Select(s => byte.Parse(s)).ToArray();
            //using var hmac = new HMACSHA512(byteArray);
            //var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
            //for (int i = 0; i < computeHash.Length; i++)
            //{
            //      if (computeHash[i] != byteArray[i]) { return null; }
            //}
            //   return new ResponseResult<IEnumerable<User>>() { Status = ResultStatus.Success, Data = user };

        }

        public string CreateToken(User user)
        {
            //secret = SharedSettings.Secret;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name,user.Name.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email)
       };
            var crads = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var TokenDescrption = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = crads,
            };
            var TokenHandler = new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(TokenDescrption);
            return TokenHandler.WriteToken(token);
        }

        public string GenerateJwtToken(User user)
        {
            if (user == null)
                return null;

            var jwtExpireDays = SharedSettings.JwtExpireDays;
            var secret = SharedSettings.Secret;
            //var jwtExpireDays = _configuration.GetSection("SharedSettings").GetValue<int>("JwtExpireDays");
            //  var secret = _configuration.GetSection("SharedSettings").GetValue<string>("Secret");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            string token = string.Empty;
            if (tokenHandler.CanReadToken(user.Name))
            {
                var qwerty = tokenHandler.ReadToken(user.Name);
                var tokenDesc = new SecurityTokenDescriptor();
                token = tokenHandler.WriteToken(qwerty);
            }
            //string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            try
            {
                var tokens = tokenHandler.ReadJwtToken(token); // 'jwtToken' is the token string
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating token: {ex.Message}");
            }
            return token;
        }
    }
}
