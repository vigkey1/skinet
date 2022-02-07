using Core.Entity;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    class SpecificationEvaluator<TEenity> where TEenity : BaseEntity
    {
        public static IQueryable<TEenity> GetQuery(IQueryable<TEenity> inputQuery, Ispecification<TEenity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);           
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }


            if (spec.OrderByDecending != null)
            {
                query = query.OrderByDescending(spec.OrderByDecending);
            }

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Include.Aggregate(query, (current, include) => current.Include(include));

            return query;
        
        }


    }
}
