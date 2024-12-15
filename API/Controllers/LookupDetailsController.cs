using Domain.Models;
using Domain.Models.SearchCriteria;
using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupDetailsController : BaseController
    {
        private IServiceUnitOfWork _serviceUnitOfWork;
        private readonly IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;


        public LookupDetailsController(IServiceUnitOfWork serviceUnitOfWork, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(serviceUnitOfWork, configuration, httpContextAccessor)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IResponseResult<IEnumerable<LookupDetail>> GetAll()
        {
            return _serviceUnitOfWork.LookupDetails.Value.GetAll();
        }

        [HttpGet("{id}")]
        public IResponseResult<LookupDetail> Get(long id)
        {
            return _serviceUnitOfWork.LookupDetails.Value.Get(id);
        }

        [HttpPost]
        public IResponseResult<LookupDetail> Add(LookupDetail Lookup)
        {
            return _serviceUnitOfWork.LookupDetails.Value.Add(Lookup);
        }

        [HttpPut]
        public IResponseResult<LookupDetail> Update(LookupDetail Lookup)
        {
            return _serviceUnitOfWork.LookupDetails.Value.Update(Lookup);
        }

        [HttpDelete("{id}")]
        public IResponseResult<LookupDetail> Delete(int id)
        {
            return _serviceUnitOfWork.LookupDetails.Value.Remove(new LookupDetail() { Id = id });
        }

        [HttpPost("InsertBulk")]
        public IResponseResult<IEnumerable<LookupDetail>> AddRange(List<LookupDetail> items)
        {
            return _serviceUnitOfWork.LookupDetails.Value.AddRange(items);
        }

        [HttpPost("GetByCriteria")]
        public IResponseResult<IEnumerable<LookupDetail>> GetByCriteria(SearchLookupDetails search)
        {
            return _serviceUnitOfWork.LookupDetails.Value.GetByCriteria(search);
        }

        [HttpGet("GetBylookupCode")]
        public IResponseResult<IEnumerable<SelectItem>> GetBylookupCode(long lookupCode)
        {
            return _serviceUnitOfWork.LookupDetails.Value.GetBylookupCode(lookupCode);
        }




    }
}
