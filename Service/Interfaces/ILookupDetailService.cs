using Domain.Models;
using Domain.Models.SearchCriteria;
using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public  interface ILookupDetailService :IService<LookupDetail>
    {
        IResponseResult<IEnumerable<LookupDetail>> GetByCriteria(SearchLookupDetails search);
        IResponseResult<IEnumerable<SelectItem>> GetBylookupCode(long lookupCode);
    }
}
