using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Service.Interfaces;
using InventoryManagement.Domain.Common;
using Domain.Models;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Interfaces;
using Domain.Models.SearchCriteria;
using Repository.Interfaces;

namespace Service.Services
{
    public class LookupService : ILookupService
    {

            private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
            private readonly IHttpClientFactory _httpClient;
            public LookupService(IRepositoryUnitOfWork repositoryUnitOfWork, IHttpClientFactory httpClient)
            {
                _repositoryUnitOfWork = repositoryUnitOfWork;
                _httpClient = httpClient;

            }

        public IResponseResult<Lookup> Add(Lookup entity)
        {
           var result= _repositoryUnitOfWork.Lookup.Value.GetByCriteria(new SearchLookup() { Code = entity.Code });
            if(result.Count() > 0)
            {
                return new ResponseResult<Lookup>() { Status = ResultStatus.Failed, Data = null, Errors= new List<string> { "Code "+ entity.Code + " already exist" } };
            }
            _repositoryUnitOfWork.Lookup.Value.Add(entity);
            return new ResponseResult<Lookup>() { Status = ResultStatus.Success, Data = entity };
        }

        public IResponseResult<IEnumerable<Lookup>> AddRange(IEnumerable<Lookup> entities)
        {
            var result = _repositoryUnitOfWork.Lookup.Value.AddRange(entities);
            return new ResponseResult<IEnumerable<Lookup>>() { Status = ResultStatus.Success, Data = result };
        }

        public IResponseResult<Lookup> Get(long id)
        {
            var result = _repositoryUnitOfWork.Lookup.Value.Get(id);
            return new ResponseResult<Lookup>() { Status = ResultStatus.Success, Data = result };
        }

        public IResponseResult<IEnumerable<Lookup>> GetAll()
        {
            using (_repositoryUnitOfWork)
            {
                var result = _repositoryUnitOfWork.Lookup.Value.GetAll().ToList();
                return new ResponseResult<IEnumerable<Lookup>>() { Status = ResultStatus.Success, Data = result };
            }
        }

        public IResponseResult<Lookup> Remove(Lookup entity)
        {
            _repositoryUnitOfWork.Lookup.Value.Remove(entity);
            return new ResponseResult<Lookup>() { Status = ResultStatus.Success, Data = entity };
        }

        public IResponseResult<IEnumerable<Lookup>> RemoveRange(IEnumerable<Lookup> entities)
        {
            var result = _repositoryUnitOfWork.Lookup.Value.RemoveRange(entities);
            return new ResponseResult<IEnumerable<Lookup>>() { Status = ResultStatus.Success, Data = result };
        }

        public IResponseResult<Lookup> Update(Lookup entity)
        {
            _repositoryUnitOfWork.Lookup.Value.Update(entity);
            return new ResponseResult<Lookup>() { Status = ResultStatus.Success, Data = entity };
        }

        public IResponseResult<IEnumerable<Lookup>> UpdateRange(IEnumerable<Lookup> entities)
        {
            _repositoryUnitOfWork.Lookup.Value.UpdateRange(entities);
            return new ResponseResult<IEnumerable<Lookup>>() { Status = ResultStatus.Success, Data = entities }; 
        }

        public IResponseResult<IEnumerable<Lookup>> GetByCriteria(SearchLookup search)
        {
            List<Lookup> result = _repositoryUnitOfWork.Lookup.Value.GetByCriteria(search).ToList();

            return new ResponseResult<IEnumerable<Lookup>>() { Status = ResultStatus.Success, Data = result };
        }

     
    }
}
