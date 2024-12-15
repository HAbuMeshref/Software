using Domain.Common;
using Domain.Models;
using InventoryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUsersService : IService<User>
    {
        User Login(Login login);
        //User HashPassword(User item);
        public string CreateToken(User user);
        public string GenerateJwtToken(User user);
        UserDto HashPassword(User item);
    }
}
