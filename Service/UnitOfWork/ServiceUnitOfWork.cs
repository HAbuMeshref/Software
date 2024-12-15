
using Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Repository.Interfaces;
using Repository.UnitOfWork;
using Service.Interfaces;
using Service.Services;
using System;

namespace Service.UnitOfWork
{
    public class ServiceUnitOfWork : IServiceUnitOfWork, IDisposable
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private InventoryManagDbContext _dbContext;
        private HttpClient _client;
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration config;

      

        public Lazy<ILookupService> Lookup { get; set; }
        public Lazy<ILookupDetailService> LookupDetails { get; set; }
        public Lazy<IUsersService> Users { get; set; }
        public Lazy<IWarehouseService> Warehouse { get; set; }
        public Lazy<IWarehouseItemService> WarehouseItem { get; set; }


        public ServiceUnitOfWork(InventoryManagDbContext context, IHttpClientFactory httpClient)
        {
            _repositoryUnitOfWork = new RepositoryUnitOfWork(context);
            _dbContext = context;
            _httpClient = httpClient;


            Lookup = new Lazy<ILookupService>(() => new LookupService(_repositoryUnitOfWork, _httpClient));
            LookupDetails = new Lazy<ILookupDetailService>(() => new LookupDetailService(_repositoryUnitOfWork, _httpClient));
            Users = new Lazy<IUsersService>(() => new UsersService(_repositoryUnitOfWork, _httpClient,  config));
            Warehouse = new Lazy<IWarehouseService>(() => new WarehouseService(_repositoryUnitOfWork, _httpClient));
            WarehouseItem = new Lazy<IWarehouseItemService>(() => new WarehouseItemItemService(_repositoryUnitOfWork, _httpClient));
            //BrMatrixDetail = new Lazy<IBrMatrixDetailService>(() => new BrMatrixDetailService(_repositoryUnitOfWork));
        }

        public void Dispose()
        {
            _repositoryUnitOfWork.Dispose();
        }
    }
}
