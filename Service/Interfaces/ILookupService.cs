using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Models.SearchCriteria;
using InventoryManagement.Domain.Interfaces;
namespace Service.Interfaces
{
    public interface ILookupService : IService<Lookup>
    {

        //IResponseResult<IEnumerable<Lookup>> GetAll(in);
        IResponseResult<IEnumerable<Lookup>> GetByCriteria(SearchLookup search);

    }
}
