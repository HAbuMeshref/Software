using Domain.Models;
using InventoryManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : BaseController
    {

        private IServiceUnitOfWork _serviceUnitOfWork;
        private readonly IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;

        public WarehouseController(IServiceUnitOfWork serviceUnitOfWork, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(serviceUnitOfWork, configuration, httpContextAccessor)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IResponseResult<IEnumerable<Warehouse>> GetAll()
        {
            return _serviceUnitOfWork.Warehouse.Value.GetAll();
        }

        [HttpGet("{id}")]
        public IResponseResult<Warehouse> Get(long id)
        {
            return _serviceUnitOfWork.Warehouse.Value.Get(id);
        }

        [HttpPost]
        public IResponseResult<Warehouse> Add(Warehouse Warehouse)
        {
            return _serviceUnitOfWork.Warehouse.Value.Add(Warehouse);
        }
        [HttpPut]
        public IResponseResult<Warehouse> Update(Warehouse Warehouse)
        {
            return _serviceUnitOfWork.Warehouse.Value.Update(Warehouse);
        }
        [HttpDelete("{id}")]
        public IResponseResult<Warehouse> Delete(int id)
        {
            return _serviceUnitOfWork.Warehouse.Value.Remove(new Warehouse() { Id = id });
        }
    }
}
