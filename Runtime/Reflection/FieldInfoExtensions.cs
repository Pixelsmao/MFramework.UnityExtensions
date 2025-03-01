using System;
using System.Reflection;

namespace MFramework.Extensions.Reflection
{
    public static class FieldInfoExtensions
    {
        public static bool TryGetValue(this FieldInfo field, object script, out object value)
        {
            var fieldValue = field.FieldType.GetDefaultValue();
            try
            {
                fieldValue = field.GetValue(script);
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