using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SpecificationsEvaluator
    {
        public static IQueryable<T> GetQuery<T>(IQueryable<T> InputQuery, Specifications<T> specifications) where T : class
        {
            var query = InputQuery;
            if (specifications.Critera is not null)
                query = query.Where(specifications.Critera);

            //foreach (var item in specifications.IncludeExpressions)
            //    query = query.Include(item);    

            query = specifications.IncludeExpressions.Aggregate(
                query,
                (CurrentQuery, includeExpression) =>
                                           CurrentQuery.Include(includeExpression));

            if (specifications.OrderBy is not null)
            {
                query = query.OrderBy(specifications.OrderBy);
            }
            else if (specifications.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specifications.OrderByDescending);
            }

            return query;
        }
    }
}
