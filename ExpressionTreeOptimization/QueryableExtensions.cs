using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeOptimization
{
    public static class QueryableExtensions
    {
        private static readonly ExpressionVisitor Visitor = new SwapNotForEqualsFalse();

        public static IQueryable<T> Optimize<T>(this IQueryable<T> query)
        {
            var optimizedExpression = Visitor.Visit(query.Expression);
            var optimizedQuery = query.Provider.CreateQuery<T>(optimizedExpression);
            return optimizedQuery;
        }
    }
}