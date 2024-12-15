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
    public class LookupRepository : Repository<Lookup>, ILookupRepository
    {
        private InventoryManagDbContext _context;
        public LookupRepository(InventoryManagDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Lookup> GetByCriteria(SearchLookup search)
        {
            var query = _context.Lookups.AsNoTracking();

            if (search.Code.HasValue)
            {
                query = query.Where(item => item.Code == search.Code);
            }

            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(item => item.Name == search.Name);
            }

            return query; 
        }
    }
}
