using System.Linq.Expressions;

namespace ExpressionTreeOptimization {
    public class SwapNotForEqualsFalse : ExpressionVisitor
    {
        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Not)
            {
                return Expression.MakeBinary(ExpressionType.Equal, node.Operand, Expression.Constant(false));
            }
            return base.VisitUnary(node);
        }
    }
}