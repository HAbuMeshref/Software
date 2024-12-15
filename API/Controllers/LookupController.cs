using Domain.Models;
using Domain.Models.SearchCriteria;
using InventoryManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    //[Authorize]

    public class LookupController : ControllerBase
    {
        private IServiceUnitOfWork _serviceUnitOfWork;
        private readonly IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;
        public LookupController(IServiceUnitOfWork serviceUnitOfWork, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public IResponseResult<IEnumerable<Lookup>> GetAll()
        {
            return _serviceUnitOfWork.Lookup.Value.GetAll();
        }

        [HttpGet("{id}")]
        public IResponseResult<Lookup> Get(long id)
        {
            return _serviceUnitOfWork.Lookup.Value.Get(id);
        }

        [HttpPost]
        public IResponseResult<Lookup> Add(Lookup Lookup)
        {
            return _serviceUnitOfWork.Lookup.Value.Add(Lookup);
        }

        [HttpPut]
        public IResponseResult<Lookup> Update(Lookup Lookup)
        {
            return _serviceUnitOfWork.Lookup.Value.Update(Lookup);
        }

        [HttpDelete("{id}")]
        public IResponseResult<Lookup> Delete(int id)
        {
            return _serviceUnitOfWork.Lookup.Value.Remove(new Lookup() { Id = id });
        }

        [HttpPost("InsertBulk")]
        public IResponseResult<IEnumerable<Lookup>> AddRange(List<Lookup> items)
        {
            return _serviceUnitOfWork.Lookup.Value.AddRange(items);
        }

        [HttpPost("GetByCriteria")]
        public IResponseResult<IEnumerable<Lookup>> GetByCriteria(SearchLookup search)
        {
            return _serviceUnitOfWork.Lookup.Value.GetByCriteria(search);
        }

    }
}
