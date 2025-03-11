using System;
using System.Collections.Generic;

namespace MFramework.Extensions.UnityComponent
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var item in self)
            {
                action(item);
            }
            return self;
        }
    }
}