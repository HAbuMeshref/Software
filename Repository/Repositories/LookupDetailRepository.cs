using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using System.Linq;

using Domain.Models;
using Domain.Models.SearchCriteria;
using Repository.Interfaces;
using Domain.Context;

namespace Repository.Repositories
{
    public class LookupDetailRepository : Repository<LookupDetail>, ILookupDetailRepository
    {
        private InventoryManagDbContext _context;
        public LookupDetailRepository(InventoryManagDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<LookupDetail> GetByCriteria(SearchLookupDetails search)
        {
            var query = _context.LookupDetails.AsNoTracking();

            if (search.LookupCode.HasValue)
            {
                query = query.Where(item => item.LookupCode == search.LookupCode);
            }

            if (!string.IsNullOrEmpty(search.SourceValue))
            {
                query = query.Where(item => item.SourceName == search.SourceValue);
            }

            if (!string.IsNullOrEmpty(search.SourceName))
            {
                query = query.Where(item => item.SourceName == search.SourceName);
            }

            if (!string.IsNullOrEmpty(search.DestinationName))
            {
                query = query.Where(item => item.DestinationName == search.DestinationName);
            }


            if (!string.IsNullOrEmpty(search.DestinationValue))
            {
                query = query.Where(item => item.DestinationValue == search.DestinationValue);
            }


            return query;
        }
    }
}
