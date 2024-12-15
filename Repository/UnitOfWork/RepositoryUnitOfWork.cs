using Domain.Context;
using Repository.Interfaces;
using Repository.Repositories;
using System;

namespace Repository.UnitOfWork
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        private InventoryManagDbContext _context;
        
      
        public Lazy<ILookupRepository> Lookup { get; set; }
        public Lazy<ILookupDetailRepository> LookupDetail { get; set; }
        public Lazy<IUsersRepository> Users { get; set; }
        public Lazy<IWarehouseRepository> Warehouse { get; set; }
        public Lazy<IWarehouseItemRepositry> WarehouseItem { get; set; }

  

        public RepositoryUnitOfWork(InventoryManagDbContext context)
        {
            _context = context;
            //Lazy<IEnvironmentRepository> Environment 
         
            Lookup = new Lazy<ILookupRepository>(() => new LookupRepository(_context));
            LookupDetail = new Lazy<ILookupDetailRepository>(() => new LookupDetailRepository(_context));
            Users = new Lazy<IUsersRepository>(() => new UsersRepository(_context));
            Warehouse = new Lazy<IWarehouseRepository>(() => new WarehouseRepository(_context));
            WarehouseItem = new Lazy<IWarehouseItemRepositry>(() => new WarehouseItemRepositry(_context));
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
