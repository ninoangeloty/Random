using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace RandomJunk
{
    public static class ModelExtensions
    {
        //public static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        //{
        //    if (expression.Body.GetType() == typeof(UnaryExpression))
        //    {
        //        var operand = expression.Body.GetType().GetProperty("Operand").GetValue(expression.Body);
        //        var memberValue = operand.GetType().GetProperty("Member").GetValue(operand);
        //        return memberValue.GetType().GetProperty("Name").GetValue(memberValue).ToString();
        //    }
        //    else
        //    {
        //        var memberValue = expression.Body.GetType().GetProperty("Member").GetValue(expression.Body);
        //        return memberValue.GetType().GetProperty("Name").GetValue(memberValue).ToString();
        //    }
        //}

        public static string GetPropertyName<T>(this T @this, Expression<Func<T, object>> expression)
        {
            if (expression.Body.GetType() == typeof(UnaryExpression))
            {
                var operand = expression.Body.GetType().GetProperty("Operand").GetValue(expression.Body);
                var memberValue = operand.GetType().GetProperty("Member").GetValue(operand);
                return memberValue.GetType().GetProperty("Name").GetValue(memberValue).ToString();
            }
            else
            {
                var memberValue = expression.Body.GetType().GetProperty("Member").GetValue(expression.Body);
                return memberValue.GetType().GetProperty("Name").GetValue(memberValue).ToString();
            }
        }
    }
}
