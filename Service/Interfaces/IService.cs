using InventoryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service.Interfaces
{
    public interface IService<Model>
    {
        IResponseResult<Model> Add(Model entity);
        IResponseResult<Model> Get(long id);
        IResponseResult<IEnumerable<Model>> AddRange(IEnumerable<Model> entities);
        IResponseResult<IEnumerable<Model>> GetAll();
        IResponseResult<Model> Remove(Model entity);
        IResponseResult<Model> Update(Model entity); 
        IResponseResult<IEnumerable<Model>> RemoveRange(IEnumerable<Model> entities);
        IResponseResult<IEnumerable<Model>> UpdateRange(IEnumerable<Model> entities);
    }
}
