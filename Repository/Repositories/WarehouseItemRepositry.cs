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
    public class WarehouseItemRepositry : Repository<WarehouseItem>, IWarehouseItemRepositry
    {
        private InventoryManagDbContext _context;
        public WarehouseItemRepositry(InventoryManagDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
