using Domain.Models;
using InventoryManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseItemItemController : BaseController
    {
        private IServiceUnitOfWork _serviceUnitOfWork;
        private readonly IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;

        public WarehouseItemItemController(IServiceUnitOfWork serviceUnitOfWork, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(serviceUnitOfWork, configuration, httpContextAccessor)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IResponseResult<IEnumerable<WarehouseItem>> GetAll()
        {
            return _serviceUnitOfWork.WarehouseItem.Value.GetAll();
        }

        [HttpGet("{id}")]
        public IResponseResult<WarehouseItem> Get(long id)
        {
            return _serviceUnitOfWork.WarehouseItem.Value.Get(id);
        }

        [HttpPost]
        public IResponseResult<WarehouseItem> Add(WarehouseItem WarehouseItem)
        {
            return _serviceUnitOfWork.WarehouseItem.Value.Add(WarehouseItem);
        }
        [HttpPut]
        public IResponseResult<WarehouseItem> Update(WarehouseItem WarehouseItem)
        {
            return _serviceUnitOfWork.WarehouseItem.Value.Update(WarehouseItem);
        }
        [HttpDelete("{id}")]
        public IResponseResult<WarehouseItem> Delete(int id)
        {
            return _serviceUnitOfWork.WarehouseItem.Value.Remove(new WarehouseItem() { Id = id });
        }

        [HttpGet("GetByWarehouseId")]
        public IResponseResult<IEnumerable<WarehouseItem>> GetByWarehouseId(long warehouseId)
        {
            return _serviceUnitOfWork.WarehouseItem.Value.GetByWarehouseId(warehouseId);

        }
    }
}