using System;
using System.Reflection;

namespace MFramework.Extensions.Reflection
{
    public static class PropertyInfoExtensions
    {
        public static bool TryGetValue(this PropertyInfo property, object script, out object value)
        {
            var fieldValue = property.PropertyType.GetDefaultValue();
            try
            {
                fieldValue = property.GetValue(script);
                value = fieldValue;
                return true;
            }
            catch (Exception)
            {
                value = fieldValue;
                return false;
            }
        }
    }
}