using Domain.Context;
using Domain.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UsersRepository :Repository<User> ,IUsersRepository
    {
        private InventoryManagDbContext _context;
        public UsersRepository(InventoryManagDbContext context) : base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }


    }
}
