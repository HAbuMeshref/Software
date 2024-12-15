using System;

namespace Repository.Interfaces
{
    public interface IRepositoryUnitOfWork : IDisposable
    {
        Lazy<ILookupRepository> Lookup { get; set; }
        Lazy<ILookupDetailRepository> LookupDetail { get; set; }
        Lazy<IUsersRepository> Users { get; set; }
        Lazy<IWarehouseRepository> Warehouse { get; set; }
        Lazy<IWarehouseItemRepositry> WarehouseItem { get; set; }
    }
}
