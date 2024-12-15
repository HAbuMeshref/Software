using Domain.Models;
using Domain.Models.SearchCriteria;
using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Interfaces;
using Repository.Interfaces;
using Serilog;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LookupDetailService : ILookupDetailService
    {

        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger _logger;

        public LookupDetailService(IRepositoryUnitOfWork repositoryUnitOfWork, IHttpClientFactory httpClient)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _httpClient = httpClient;
            _logger = Log.ForContext<LookupDetailService>();


        }


        public IResponseResult<LookupDetail> Add(LookupDetail entity)
        {
            _repositoryUnitOfWork.LookupDetail.Value.Add(entity);
            return new ResponseResult<LookupDetail>() { Status = ResultStatus.Success, Data = entity };
        }

        public IResponseResult<IEnumerable<LookupDetail>> AddRange(IEnumerable<LookupDetail> entities)
        {
            var result = _repositoryUnitOfWork.LookupDetail.Value.AddRange(entities);
            return new ResponseResult<IEnumerable<LookupDetail>>() { Status = ResultStatus.Success, Data = result };
        }

        public IResponseResult<LookupDetail> Get(long id)
        {
            var result = _repositoryUnitOfWork.LookupDetail.Value.Get(id);
            return new ResponseResult<LookupDetail>() { Status = ResultStatus.Success, Data = result };
        }

        public IResponseResult<IEnumerable<LookupDetail>> GetAll()
        {
            using (_repositoryUnitOfWork)
            {
                var result = _repositoryUnitOfWork.LookupDetail.Value.GetAll().ToList();
                return new ResponseResult<IEnumerable<LookupDetail>>() { Status = ResultStatus.Success, Data = result };
            }
        }

        public IResponseResult<LookupDetail> Remove(LookupDetail entity)
        {
            _repositoryUnitOfWork.LookupDetail.Value.Remove(entity);
            return new ResponseResult<LookupDetail>() { Status = ResultStatus.Success, Data = entity };
        }

        public IResponseResult<IEnumerable<LookupDetail>> RemoveRange(IEnumerable<LookupDetail> entities)
        {
            var result = _repositoryUnitOfWork.LookupDetail.Value.RemoveRange(entities);
            return new ResponseResult<IEnumerable<LookupDetail>>() { Status = ResultStatus.Success, Data = result };
        }

        public IResponseResult<LookupDetail> Update(LookupDetail entity)
        {
            _repositoryUnitOfWork.LookupDetail.Value.Update(entity);
            return new ResponseResult<LookupDetail>() { Status = ResultStatus.Success, Data = entity };
        }

        public IResponseResult<IEnumerable<LookupDetail>> UpdateRange(IEnumerable<LookupDetail> entities)
        {
            _repositoryUnitOfWork.LookupDetail.Value.UpdateRange(entities);
            return new ResponseResult<IEnumerable<LookupDetail>>() { Status = ResultStatus.Success, Data = entities };
        }

        public IResponseResult<IEnumerable<LookupDetail>> GetByCriteria(SearchLookupDetails search)
        {
            List<LookupDetail> result = _repositoryUnitOfWork.LookupDetail.Value.GetByCriteria(search).ToList();

            return new ResponseResult<IEnumerable<LookupDetail>>() { Status = ResultStatus.Success, Data = result };
        }

        public IResponseResult<IEnumerable<SelectItem>> GetBylookupCode(long lookupCode)
        {
            try
            {
                var result = _repositoryUnitOfWork.LookupDetail.Value.Find(x => x.LookupCode == lookupCode)
                             .ToList();
                var results = result.Select(e => new SelectItem
                {
                    Id = e.Id,
                    value = e.DestinationValue,
                    label = e.DestinationName
                }).ToList();
                _logger.Information("Performing a task at {Time}", DateTime.Now);
                return new ResponseResult<IEnumerable<SelectItem>>() { Status = ResultStatus.Success, Data = results };
            }
            catch (Exception ex)
            {
                {
                    return new ResponseResult<IEnumerable<SelectItem>>() { Status = ResultStatus.Failed, Data = null };
                }
            }

        }

    }
}
