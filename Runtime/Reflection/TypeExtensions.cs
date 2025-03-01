using System;
using System.Linq.Expressions;

namespace MFramework.Extensions.Reflection
{
    public static class TypeExtensions
    {
        public static object GetDefaultValue(this Type type)
        {
            var defaultExpression = Expression.Default(type); // 创建默认值表达式
            var lambda = Expression.Lambda<Func<object>>(
                Expression.Convert(defaultExpression, typeof(object))
            );
            return lambda.Compile()(); // 编译并执行
        }
    }
}