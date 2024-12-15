using Domain.Models;
using Domain.Models.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ILookupDetailRepository:IRepository<LookupDetail>
    {
        IQueryable<LookupDetail> GetByCriteria(SearchLookupDetails search);
    }
}
