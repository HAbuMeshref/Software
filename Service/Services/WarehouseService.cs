using Domain.Models;
using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Interfaces;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly IHttpClientFactory _httpClient;
        public WarehouseService(IRepositoryUnitOfWork repositoryUnitOfWork, IHttpClientFactory httpClient)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _httpClient = httpClient;

        }


        public IResponseResult<Warehouse> Add(Warehouse entity)
        {
            try
            {
                _repositoryUnitOfWork.Warehouse.Value.Add(entity);
                return new ResponseResult<Warehouse>() { Status = ResultStatus.Success, Data = entity };
            }
            catch (Exception ex)
            {
                return new ResponseResult<Warehouse>() { Status = ResultStatus.Failed, Data = null, Errors = new List<string>() { "Exception Message : " + ex.Message } };
            }

        }

        public IResponseResult<IEnumerable<Warehouse>> AddRange(IEnumerable<Warehouse> entities)
        {
            var result = _repositoryUnitOfWork.Warehouse.Value.AddRange(entities);
            return new ResponseResult<IEnumerable<Warehouse>>() { Status = ResultStatus.Success, Data = result };
        }

        public IResponseResult<Warehouse> Get(long id)
        {
            var result = _repositoryUnitOfWork.Warehouse.Value.Get(id);
            return new ResponseResult<Warehouse>() { Status = ResultStatus.Success, Data = result };
        }

        public IResponseResult<IEnumerable<Warehouse>> GetAll()
        {
            using (_repositoryUnitOfWork)
            {
                var result = _repositoryUnitOfWork.Warehouse.Value.GetAll().ToList();
                return new ResponseResult<IEnumerable<Warehouse>>() { Status = ResultStatus.Success, Data = result };
            }
        }

        public IResponseResult<Warehouse> Remove(Warehouse entity)
        {
            _repositoryUnitOfWork.Warehouse.Value.Remove(entity);
            return new ResponseResult<Warehouse>() { Status = ResultStatus.Success, Data = entity };
        }

        public IResponseResult<IEnumerable<Warehouse>> RemoveRange(IEnumerable<Warehouse> entities)
        {
            var result = _repositoryUnitOfWork.Warehouse.Value.RemoveRange(entities);
            return new ResponseResult<IEnumerable<Warehouse>>() { Status = ResultStatus.Success, Data = result };
        }

        public IResponseResult<Warehouse> Update(Warehouse entity)
        {
            _repositoryUnitOfWork.Warehouse.Value.Update(entity);
            return new ResponseResult<Warehouse>() { Status = ResultStatus.Success, Data = entity };
        }

        public IResponseResult<IEnumerable<Warehouse>> UpdateRange(IEnumerable<Warehouse> entities)
        {
            _repositoryUnitOfWork.Warehouse.Value.UpdateRange(entities);
            return new ResponseResult<IEnumerable<Warehouse>>() { Status = ResultStatus.Success, Data = entities };
        }
    }
}
