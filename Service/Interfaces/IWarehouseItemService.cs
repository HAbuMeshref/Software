using Domain.Models;
using InventoryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IWarehouseItemService  : IService<WarehouseItem>
    {
        IResponseResult<IEnumerable<WarehouseItem>> GetByWarehouseId(long warehouseId);
    }
}
