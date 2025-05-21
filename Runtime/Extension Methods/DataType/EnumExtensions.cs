using System;
using UnityEngine;

namespace MFramework.Extensions
{
    public static partial class EnumExtensions
    {
        public static bool TryParse<T>(this Enum enumType, int enumIndex, out Enum result) where T : Enum
        {
            result = null;
            try
            {
                result = (Enum)Enum.ToObject(typeof(T), enumIndex);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}