using Domain.Common;
using Domain.Models;
using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.UnitOfWork;
using Services.Serviese;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private IServiceUnitOfWork _serviceUnitOfWork;
        private readonly IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;

        public UsersController(IServiceUnitOfWork serviceUnitOfWork, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(serviceUnitOfWork, configuration, httpContextAccessor)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public IResponseResult<IEnumerable<User>> GetAll()
        {
            return _serviceUnitOfWork.Users.Value.GetAll();
        }

        [HttpGet("{id}")]
        public IResponseResult<User> Get(long id)
        {
            return _serviceUnitOfWork.Users.Value.Get(id);
        }

        [HttpPost]
        public IResponseResult<User> Add(User user)
        {
            return _serviceUnitOfWork.Users.Value.Add(user);
        }
        [HttpPut]
        public IResponseResult<User> Update(User user)
        {
            return _serviceUnitOfWork.Users.Value.Update(user);
        }
        [HttpDelete("{id}")]
        public IResponseResult<User> Delete(int id)
        {
            return _serviceUnitOfWork.Users.Value.Remove(new User() { Id = id });
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login login)
        {
            try
            {
                var user = _serviceUnitOfWork.Users.Value.Login(login);
                if (user == null)
                {
                    return BadRequest("somthing going wrong");
                }
                return Ok(new AuthDto { Token = _serviceUnitOfWork.Users.Value.CreateToken(user) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public IActionResult Register(UserDto userdto)
        //{
        //    try
        //    {
        //        if (_unit.UserService.IsExist(userdto.Email))
        //        {
        //            return BadRequest("TheEmail Is Alrady used");
        //        }
        //        var user = _unit.UserService.HashPassword(userdto);
        //        if (user == null)
        //        {
        //            return BadRequest("Some thing going wrong");
        //        }
        //        _unit.UserService.Add(user);
        //        _unit.Save();
        //        return Ok(user);

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
