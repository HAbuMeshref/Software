using Service.UnitOfWork;
using System;

namespace Service.Interfaces
{
    public interface IServiceUnitOfWork
    {
        //ITPServiceUnitOfWork _tPServiceUnitOfWork { get; set; }
   
        Lazy<ILookupService> Lookup { get; set; }
        Lazy<ILookupDetailService> LookupDetails { get; set; }
        Lazy<IUsersService> Users { get; set; }
        Lazy<IWarehouseService> Warehouse { get; set; }
        Lazy<IWarehouseItemService> WarehouseItem { get; set; }


    }
}
