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
    public class WarehouseItemItemService : IWarehouseItemService
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly IHttpClientFactory _httpClient;
        public WarehouseItemItemService(IRepositoryUnitOfWork repositoryUnitOfWork, IHttpClientFactory httpClient)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _httpClient = httpClient;

        }

        public IResponseResult<WarehouseItem> Add(WarehouseItem entity)
        {
            try
            {
                _repositoryUnitOfWork.WarehouseItem.Value.Add(entity);
                return new ResponseResult<WarehouseItem>() { Status = ResultStatus.Success, Data = entity };
            }
            catch (Exception ex)
            {
                return new ResponseResult<WarehouseItem>() { Status = ResultStatus.Failed, Data = null, Errors = new List<string>() { "Exception Message : " + ex.Message } };
            }
        }

        public IResponseResult<IEnumerable<WarehouseItem>> AddRange(IEnumerable<WarehouseItem> entities)
        {

            try
            {
                var result = _repositoryUnitOfWork.WarehouseItem.Value.AddRange(entities);
                return new ResponseResult<IEnumerable<WarehouseItem>>() { Status = ResultStatus.Success, Data = result };
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<WarehouseItem>>() { Status = ResultStatus.Failed, Data = null, Errors = new List<string>() { "Exception Message : " + ex.Message } };
            }
        }
        public IResponseResult<WarehouseItem> Get(long id)
        {
            try
            {
                var result = _repositoryUnitOfWork.WarehouseItem.Value.Get(id);
                return new ResponseResult<WarehouseItem>() { Status = ResultStatus.Success, Data = result };
            }
            catch (Exception ex)
            {
                return new ResponseResult<WarehouseItem>() { Status = ResultStatus.Failed, Data = null, Errors = new List<string>() { "Exception Message : " + ex.Message } };
            }
        }

        public IResponseResult<IEnumerable<WarehouseItem>> GetAll()
        {
            using (_repositoryUnitOfWork)
            {
                try
                {
                    var result = _repositoryUnitOfWork.WarehouseItem.Value.GetAll().ToList();
                    return new ResponseResult<IEnumerable<WarehouseItem>>() { Status = ResultStatus.Success, Data = result };
                }
                catch (Exception ex)
                {
                    return new ResponseResult<IEnumerable<WarehouseItem>>() { Status = ResultStatus.Failed, Data = null, Errors = new List<string>() { "Exception Message : " + ex.Message } };
                }
            }
        }
        public IResponseResult<WarehouseItem> Remove(WarehouseItem entity)
        {
            _repositoryUnitOfWork.WarehouseItem.Value.Remove(entity);
            return new ResponseResult<WarehouseItem>() { Status = ResultStatus.Success, Data = entity };
        }

        public IResponseResult<IEnumerable<WarehouseItem>> RemoveRange(IEnumerable<WarehouseItem> entities)
        {
            var result = _repositoryUnitOfWork.WarehouseItem.Value.RemoveRange(entities);
            return new ResponseResult<IEnumerable<WarehouseItem>>() { Status = ResultStatus.Success, Data = result };
        }

        public IResponseResult<WarehouseItem> Update(WarehouseItem entity)
        {
            _repositoryUnitOfWork.WarehouseItem.Value.Update(entity);
            return new ResponseResult<WarehouseItem>() { Status = ResultStatus.Success, Data = entity };
        }

        public IResponseResult<IEnumerable<WarehouseItem>> UpdateRange(IEnumerable<WarehouseItem> entities)
        {
            _repositoryUnitOfWork.WarehouseItem.Value.UpdateRange(entities);
            return new ResponseResult<IEnumerable<WarehouseItem>>() { Status = ResultStatus.Success, Data = entities };
        }

        public IResponseResult<IEnumerable<WarehouseItem>> GetByWarehouseId(long warehouseId)
        {
            long totalRecords = 0;
            try
            {
                List<WarehouseItem> result = _repositoryUnitOfWork.WarehouseItem.Value
                    .Find(x => x.WarehouseId == warehouseId).ToList();
                //.ToList().Skip(1).Take(10).ToList();
                return new ResponseResult<IEnumerable<WarehouseItem>>() { Status = ResultStatus.Success, Data = result, TotalRecords = result.Count() };

            }
            catch (Exception ex)
            {

                return new ResponseResult<IEnumerable<WarehouseItem>>() { Status = ResultStatus.Failed, Data = null, TotalRecords = 0 };
            }




        }
    }
}
