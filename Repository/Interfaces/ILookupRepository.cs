using Domain.Models;
using Domain.Models.SearchCriteria;
using System;
using System.Linq;


namespace Repository.Interfaces
{
    public interface ILookupRepository : IRepository<Lookup>
    {
        IQueryable<Lookup> GetByCriteria(SearchLookup search);
    }
}
