using System;
using System.Collections.Generic;

namespace MFramework.Extensions.DataStructure
{
    public static class ListExtensions
    {
        /// <summary>
        /// 该方法通过传递一个包含列表元素的委托，在循环中顺序遍历数组并对每个元素调用指定的操作。
        /// 返回原始列表。
        /// </summary>
        public static List<T> ForEach<T>(this List<T> self, Action<T> action) {
            foreach (var item in self) {
                action(item);
            }

            return self;
        }

        /// <summary>
        /// 该方法通过传递一个包含列表索引和元素的委托，在循环中顺序遍历数组并对每个元素调用指定的操作。
        /// 返回原始列表。
        /// </summary>
        public static List<T> ForEach<T>(this List<T> self, Action<int, T> action) {
            for (int i = 0; i < self.Count; i++) {
                int index = i;
                action(index, self[index]);
            }

            return self;
        }

        /// <summary>
        /// 该方法通过传递一个包含列表元素的委托，在循环中倒序遍历数组并对每个元素调用指定的操作。
        /// 返回原始列表。
        /// </summary>
        public static List<T> ForEachReverse<T>(this List<T> self, Action<T> action) {
            for (int i = self.Count - 1; i >= 0; i--) {
                int index = i;
                action(self[index]);
            }

            return self;
        }

        /// <summary>
        /// 该方法通过传递一个包含列表索引和元素的委托，在循环中倒序遍历数组并对每个元素调用指定的操作。
        /// 返回原始列表。
        /// </summary>
        public static List<T> ForEachReverse<T>(this List<T> self, Action<int, T> action) {
            for (int i = self.Count - 1; i >= 0; i--) {
                int index = i;
                action(index, self[index]);
            }

            return self;
        }

        /// <summary>
        /// 该方法向列表中添加一个新元素，但仅在元素不存在于列表中时执行添加操作。
        /// </summary>
        public static List<T> TryAdd<T>(this List<T> self, T t) {
            if (!self.Contains(t)) {
                self.Add(t);
            }

            return self;
        }

        /// <summary>
        /// 向列表中尝试添加元素，但仅在元素不存在于列表中时执行添加操作，通过使用 HashSet 来优化查找速度。
        /// </summary>
        public static List<T> TryAddOptimized<T>(this List<T> self, T t) {
            HashSet<T> set = new HashSet<T>(self);
            if (set.Add(t)) {
                self.Add(t);
            }

            return self;
        }

        /// <summary>
        /// 移除第一个元素
        /// </summary>
        public static List<T> RemoveFirst<T>(this List<T> self) {
            if (self.Count > 0) {
                self.RemoveAt(0);
            }

            return self;
        }

        /// <summary>
        /// 移除最后一个元素
        /// </summary>
        public static List<T> RemoveLast<T>(this List<T> self) {
            if (self.Count > 0) {
                self.RemoveAt(self.Count - 1);
            }

            return self;
        }

        /// <summary>
        /// 在第一个位置添加元素
        /// </summary>
        public static List<T> AddAtFirst<T>(this List<T> self, T item) {
            self.Insert(0, item);
            return self;
        }

        /// <summary>
        /// 在指定位置添加元素
        /// </summary>
        public static List<T> AddAt<T>(this List<T> self, int index, T item) {
            if (index >= 0 && index <= self.Count) {
                self.Insert(index, item);
            }

            return self;
        }

        /// <summary>
        /// 在指定元素之前添加元素
        /// </summary>
        public static List<T> AddBefore<T>(this List<T> self, T existingItem, T newItem) {
            int index = self.IndexOf(existingItem);
            if (index != -1) {
                self.Insert(index, newItem);
            }

            return self;
        }

        /// <summary>
        /// 在指定元素之后添加元素
        /// </summary>
        public static List<T> AddAfter<T>(this List<T> self, T existingItem, T newItem) {
            int index = self.IndexOf(existingItem);
            if (index != -1) {
                self.Insert(index + 1, newItem);
            }

            return self;
        }

        /// <summary>
        /// 从列表中获取指定范围的子列表。
        /// </summary>
        /// <returns></returns>
        public static List<T> Slice<T>(this List<T> self, int start, int end) {
            int count = Math.Min(end - start, self.Count - start);
            List<T> result = new List<T>(count);
            for (int i = start; i < start + count; i++) {
                result.Add(self[i]);
            }

            return result;
        }

        /// <summary>
        /// 随机打乱列表中的元素顺序。
        /// </summary>
        public static List<T> Shuffle<T>(this List<T> self) {
            Random random = new Random();
            int n = self.Count;
            while (n > 1) {
                n--;
                int k = random.Next(n + 1);
                T value = self[k];
                self[k] = self[n];
                self[n] = value;
            }

            return self;
        }

        /// <summary>
        /// 根据指定的键选择唯一元素。
        /// </summary>
        public static List<T> DistinctBy<T, TKey>(this List<T> self, Func<T, TKey> keySelector) {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            List<T> result = new List<T>();

            foreach (var item in self) {
                TKey key = keySelector(item);
                if (seenKeys.Add(key)) {
                    result.Add(item);
                }
            }

            return result;
        }

        /// <summary>
        /// 将列表拆分为指定大小的块。
        /// </summary>
        public static List<List<T>> Chunk<T>(this List<T> self, int chunkSize) {
            List<List<T>> result = new List<List<T>>();
            for (int i = 0; i < self.Count; i += chunkSize) {
                result.Add(self.GetRange(i, Math.Min(chunkSize, self.Count - i)));
            }

            return result;
        }

        /// <summary>
        /// 将列表中的每个元素映射到新的值。
        /// </summary>
        public static List<TResult> Map<T, TResult>(this List<T> self, Func<T, TResult> mapper) {
            List<TResult> result = new List<TResult>(self.Count);
            foreach (var item in self) {
                result.Add(mapper(item));
            }

            return result;
        }

        /// <summary>
        /// 根据指定条件筛选列表中的元素。
        /// </summary>
        public static List<T> Filter<T>(this List<T> self, Func<T, bool> predicate) {
            List<T> result = new List<T>();
            foreach (var item in self) {
                if (predicate(item)) {
                    result.Add(item);
                }
            }

            return result;
        }

        /// <summary>
        /// 查找元素在列表中的索引，支持自定义比较器。
        /// </summary>
        public static int IndexOf<T>(this List<T> self, T item, IEqualityComparer<T> comparer) {
            for (int i = 0; i < self.Count; i++) {
                if (comparer.Equals(self[i], item)) {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 将列表中的元素循环左移指定数量的位置。
        /// </summary>
        public static List<T> MoveToLeft<T>(this List<T> self, int positions) {
            int n = self.Count;
            positions = positions % n;
            List<T> result = new List<T>(self.Count);
            for (int i = positions; i < positions + n; i++) {
                result.Add(self[i % n]);
            }

            return result;
        }

        /// <summary>
        /// 将列表中的元素循环右移指定数量的位置。
        /// </summary>
        public static List<T> MoveToRight<T>(this List<T> self, int positions) {
            int n = self.Count;
            positions = positions % n;
            List<T> result = new List<T>(self.Count);
            for (int i = n - positions; i < n - positions + n; i++) {
                result.Add(self[i % n]);
            }

            return result;
        }
    }
}