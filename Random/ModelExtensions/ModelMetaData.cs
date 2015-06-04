using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RandomJunk.ModelExtensions
{
    public static class ModelMetaData
    {
        public static void GetModelMetaData<T>(Expression<Func<T, object>> expression)
        {
            string propertyName = null;
            Type containerType = null;

            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression memberExpression = (MemberExpression)expression.Body;
                propertyName = memberExpression.Member is PropertyInfo ? memberExpression.Member.Name : null;
                containerType = memberExpression.Expression.Type;
            }
        }
    }
}
