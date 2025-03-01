using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFramework.Extensions.DataStructure
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// 该方法允许对数组中的每个元素顺序执行指定的操作。
        /// 通过传递一个包含数组索引和元素的委托，该方法在循环中遍历数组并对每个元素调用指定的操作。
        /// 该方法返回原始数组。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        /// <param name="action">对每个元素执行的操作</param>
        public static T[] ForEach<T>(this T[] self, Action<int, T> action) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            for (int i = 0; i < self.Length; i++) {
                action(i, self[i]);
            }

            return self;
        }

        /// <summary>
        /// 该方法使用 Parallel.For 实现并行执行，允许对数组中的每个元素并行执行指定的操作。
        /// 通过传递一个包含数组索引和元素的委托，该方法在并行循环中遍历数组，并对每个元素调用指定的操作。
        /// 隐患和注意事项：
        /// 1.不适用于涉及 Unity API 或其他不支持多线程操作的上下文。
        /// 2.潜在的并发性问题，需要确保传入的委托对元素的操作是线程安全的。
        /// </summary>
        /// <param name="array">要操作的数组</param>
        /// <param name="action">对每个元素并行执行的操作</param>
        public static void ForEachParallel<T>(this T[] array, Action<int, T> action) {
            if (array == null) {
                throw new ArgumentNullException(nameof(array));
            }

            Parallel.For(0, array.Length, i => { action(i, array[i]); });
        }

        /// <summary>
        /// 该方法允许对数组中的每个元素进行逆序执行指定的操作。
        /// 通过传递一个包含数组元素的委托，该方法在逆序循环中遍历数组，并对每个元素调用指定的操作。
        /// 该方法返回原始数组。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        /// <param name="action">对每个元素执行的操作</param>
        public static T[] ForEachReverse<T>(this T[] self, Action<T> action) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            for (int i = self.Length - 1; i >= 0; i--) {
                action(self[i]);
            }

            return self;
        }

        /// <summary>
        /// 该方法允许对数组中的每个元素进行逆序（从最后一个元素到第一个元素）执行指定的操作。
        /// 通过传递一个包含数组索引和元素的委托，该方法在逆序循环中遍历数组，并对每个元素调用指定的操作。
        /// 该方法返回原始数组。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        /// <param name="action">对每个元素执行的操作</param>
        public static T[] ForEachReverse<T>(this T[] self, Action<int, T> action) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            for (int i = self.Length - 1; i >= 0; i--) {
                action(i, self[i]);
            }

            return self;
        }

        /// <summary>
        /// 该方法用于在数组的末尾添加一个元素。
        /// 通过创建一个新的数组，将原始数组的元素复制到新数组中，并在新数组的末尾添加新元素 `t`。
        /// 返回新的数组。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        /// <param name="t">要添加的元素</param>
        public static T[] Add<T>(this T[] self, T t) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            T[] newArray = new T[self.Length + 1];
            Array.Copy(self, newArray, self.Length);
            newArray[self.Length] = t;
            return newArray;
        }

        /// <summary>
        /// 从数组中移除指定索引处的元素。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        /// <param name="index">要移除元素的索引</param>
        public static T[] RemoveAt<T>(this T[] self, int index) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            if (index < 0 || index >= self.Length) {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            T[] newArray = new T[self.Length - 1];
            Array.Copy(self, 0, newArray, 0, index);
            Array.Copy(self, index + 1, newArray, index, self.Length - index - 1);

            return newArray;
        }

        /// <summary>
        /// 根据起始索引和长度从数组中移除指定范围的元素。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        /// <param name="startIndex">起始索引</param>
        /// <param name="length">要移除的元素数量</param>
        public static T[] RemoveRange<T>(this T[] self, int startIndex, int length) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            if (startIndex < 0 || startIndex >= self.Length || length < 0 || startIndex + length > self.Length) {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index or length is out of range.");
            }

            T[] newArray = new T[self.Length - length];
            Array.Copy(self, 0, newArray, 0, startIndex);
            Array.Copy(self, startIndex + length, newArray, startIndex, self.Length - startIndex - length);

            return newArray;
        }

        /// <summary>
        /// 从数组中移除第一个元素。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        public static T[] RemoveFirst<T>(this T[] self) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            T[] newArray = new T[self.Length - 1];
            Array.Copy(self, 1, newArray, 0, self.Length - 1);

            return newArray;
        }

        /// <summary>
        /// 从数组中移除最后一个元素。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        public static T[] RemoveLast<T>(this T[] self) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            T[] newArray = new T[self.Length - 1];
            Array.Copy(self, newArray, self.Length - 1);

            return newArray;
        }

        /// <summary>
        /// 从数组中移除所有出现的指定项。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        /// <param name="itemToRemove">要移除的项</param>
        public static T[] Remove<T>(this T[] self, T itemToRemove) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            int newIndex = 0;
            T[] newArray = new T[self.Length];

            for (int i = 0; i < self.Length; i++) {
                if (!EqualityComparer<T>.Default.Equals(self[i], itemToRemove)) {
                    newArray[newIndex] = self[i];
                    newIndex++;
                }
            }

            Array.Resize(ref newArray, newIndex);
            return newArray;
        }

        /// <summary>
        /// 在数组的开头插入一个元素。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        /// <param name="elementToInsert">要插入的元素</param>
        public static T[] AddAtFirst<T>(this T[] self, T elementToInsert) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            T[] newArray = new T[self.Length + 1];
            newArray[0] = elementToInsert;
            Array.Copy(self, 0, newArray, 1, self.Length);

            return newArray;
        }

        /// <summary>
        /// 在数组的末尾插入一个元素。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        /// <param name="elementToInsert">要插入的元素</param>
        public static T[] AddAtLast<T>(this T[] self, T elementToInsert) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            T[] newArray = new T[self.Length + 1];
            Array.Copy(self, newArray, self.Length);
            newArray[self.Length] = elementToInsert;

            return newArray;
        }

        /// <summary>
        /// 在数组的指定索引处插入元素。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        /// <param name="index">插入元素的位置</param>
        /// <param name="elementToInsert">要插入的元素</param>
        public static T[] AddAt<T>(this T[] self, int index, T elementToInsert) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            if (index < 0 || index > self.Length) {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            T[] newArray = new T[self.Length + 1];
            Array.Copy(self, 0, newArray, 0, index);
            newArray[index] = elementToInsert;
            Array.Copy(self, index, newArray, index + 1, self.Length - index);

            return newArray;
        }

        /// <summary>
        /// 在数组的指定索引处插入另一个数组的元素。
        /// </summary>
        /// <param name="self">要操作的数组</param>
        /// <param name="index">插入元素的位置</param>
        /// <param name="elementsToInsert">要插入的数组</param>
        public static T[] AddArrayAt<T>(this T[] self, int index, T[] elementsToInsert) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            if (index < 0 || index > self.Length) {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            T[] newArray = new T[self.Length + elementsToInsert.Length];
            Array.Copy(self, 0, newArray, 0, index);
            Array.Copy(elementsToInsert, 0, newArray, index, elementsToInsert.Length);
            Array.Copy(self, index, newArray, index + elementsToInsert.Length, self.Length - index);

            return newArray;
        }

        /// <summary>
        /// 查找符合指定条件的第一个元素。
        /// </summary>
        public static T Find<T>(this T[] self, Predicate<T> match) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            foreach (var item in self) {
                if (match(item)) {
                    return item;
                }
            }

            return default(T);
        }

        /// <summary>
        /// 查找符合指定条件的所有元素。
        /// </summary>
        public static T[] FindAll<T>(this T[] self, Predicate<T> match) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            var results = new List<T>();
            foreach (var item in self) {
                if (match(item)) {
                    results.Add(item);
                }
            }

            return results.ToArray();
        }

        /// <summary>
        /// 检查数组中是否包含指定元素。
        /// </summary>
        public static bool Contains<T>(this T[] self, T item) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            return Array.Exists(self, x => EqualityComparer<T>.Default.Equals(x, item));
        }

        /// <summary>
        /// 获取指定元素在数组中的索引。
        /// </summary>
        public static int IndexOf<T>(this T[] self, T item) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            return Array.IndexOf(self, item);
        }

        /// <summary>
        /// 获取指定元素在数组中的最后一个索引。
        /// </summary>
        public static int LastIndexOf<T>(this T[] self, T item) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            return Array.LastIndexOf(self, item);
        }

        /// <summary>
        /// 获取数组中不重复的元素。
        /// </summary>
        public static T[] Distinct<T>(this T[] self) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            return self.Distinct().ToArray();
        }

        /// <summary>
        /// 随机打乱数组元素顺序。
        /// </summary>
        public static T[] Shuffle<T>(this T[] self) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            Random rng = new Random();
            for (int i = self.Length - 1; i > 0; i--) {
                int swapIndex = rng.Next(i + 1);
                (self[swapIndex], self[i]) = (self[i], self[swapIndex]);
            }

            return self;
        }

        /// <summary>
        /// 获取数组的一个子数组。
        /// </summary>
        public static T[] Slice<T>(this T[] self, int startIndex, int length) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            if (startIndex < 0 || length < 0 || startIndex + length > self.Length) {
                throw new ArgumentOutOfRangeException();
            }

            T[] slice = new T[length];
            Array.Copy(self, startIndex, slice, 0, length);
            return slice;
        }
    }
}