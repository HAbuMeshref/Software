using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;
namespace Service.Interfaces
{
    public interface IAuthService : IService<User>

    {
        public string CreateToken(User user);
    }
}
