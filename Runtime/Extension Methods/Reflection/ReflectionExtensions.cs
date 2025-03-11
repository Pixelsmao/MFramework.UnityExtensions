using System;
using System.Reflection;

namespace MFramework.Extensions.Reflection
{
    public static class ReflectionExtensions
    {
        public static object GetFieldValue(this object self, string fieldName)
        {
            Type type = self.GetType();
            FieldInfo fieldInfo = type.GetField(fieldName);
            return fieldInfo?.GetValue(self);
        }
        public static object GetPropertyValue(this object self, string propertyName, object[] index = null)
        {
            Type type = self.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName);
            return propertyInfo?.GetValue(self, index);
        }
        public static object ExecuteMethod(this object self, string methodName, params object[] args)
        {
            Type type = self.GetType();
            MethodInfo methodInfo = type.GetMethod(methodName);
            return methodInfo?.Invoke(self, args);
        } 
    }
}