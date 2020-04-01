using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cir.Repository
{
    internal class ParameterReplacer : ExpressionVisitor
    {

        private readonly ParameterExpression _parameter;

        protected override Expression VisitParameter(ParameterExpression node)
            => base.VisitParameter(_parameter);

        internal ParameterReplacer(ParameterExpression parameter)
        {
            _parameter = parameter;
        }
    }

    public class AndSpecification : Specification
    {
        private readonly ISpecification left;
        private readonly ISpecification right;

        public AndSpecification(ISpecification left, ISpecification right)
        {
            this.right = right ?? throw new ArgumentNullException("right");
            this.left = left ?? throw new ArgumentNullException("left");
        }

        public override Expression<Func<JObject, bool>> ToExpression()
        {
            Expression<Func<JObject, bool>> leftExpression = left.ToExpression();
            Expression<Func<JObject, bool>> rightExpression = right.ToExpression();

            var paramExpr = Expression.Parameter(typeof(JObject));
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<JObject, bool>>(exprBody, paramExpr);

            return finalExpr;

        }

        public override string ToString()
        {
            var parts = new[]
            {
                left.ToString(),
                right.ToString()
            }
            .OrderBy(x => x)
            .ToList();

            return $"AND({parts[0]}, {parts[1]})";
        }
    }
}
