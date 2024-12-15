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
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        private InventoryManagDbContext _context;
        public WarehouseRepository(InventoryManagDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
