using System;
using System.Collections.Generic;
using System.Linq;

namespace MFramework.Extensions.DataStructure
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// 使用传递的委托对字典中的每个键值对执行指定的操作，并返回原始字典。
        /// </summary>
        public static Dictionary<K, V> ForEach<K, V>(this Dictionary<K, V> self, Action<K, V> action) {
            using (var dicE = self.GetEnumerator()) {
                while (dicE.MoveNext()) {
                    action(dicE.Current.Key, dicE.Current.Value);
                }
            }

            return self;
        }

        /// <summary>
        /// 顺序遍历字典并使用包含索引和元素的委托执行指定操作
        /// </summary>
        public static Dictionary<TKey, TValue> ForEachWithIndex<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            Action<int, TValue> action) {
            int index = 0;
            foreach (var value in dictionary.Values) {
                action(index++, value);
            }

            return dictionary;
        }

        /// <summary>
        /// 倒序遍历字典并使用委托执行指定操作
        /// </summary>
        public static Dictionary<TKey, TValue>
            ForEachReverse<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Action<TValue> action) {
            var values = new List<TValue>(dictionary.Values);
            values.Reverse();

            foreach (var value in values) {
                action(value);
            }

            return dictionary;
        }

        /// <summary>
        /// 倒序遍历字典并使用包含索引和元素的委托执行指定操作
        /// </summary>
        public static Dictionary<TKey, TValue> ForEachWithIndexReverse<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            Action<int, TValue> action) {
            var values = new List<TValue>(dictionary.Values);
            values.Reverse();

            int index = 0;
            foreach (var value in values) {
                action(index++, value);
            }

            return dictionary;
        }

        /// <summary>
        /// 移除第一个元素
        /// </summary>
        public static Dictionary<TKey, TValue> RemoveFirst<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) {
            if (dictionary.Count > 0) {
                TKey firstKey = dictionary.Keys.First();
                dictionary.Remove(firstKey);
            }

            return dictionary;
        }

        /// <summary>
        /// 移除最后一个元素
        /// </summary>
        public static void RemoveLast<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) {
            if (dictionary.Count > 0) {
                TKey lastKey = dictionary.Keys.Last();
                dictionary.Remove(lastKey);
            }
        }

        /// <summary>
        /// 在第一个位置添加元素
        /// </summary>
        public static Dictionary<TKey, TValue> AddFirst<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            TKey key, TValue value) {
            Dictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue> { { key, value } };

            foreach (var kvp in dictionary) {
                newDictionary.Add(kvp.Key, kvp.Value);
            }

            dictionary.Clear();
            foreach (var kvp in newDictionary) {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }

        /// <summary>
        /// 在指定位置添加元素
        /// </summary>
        public static Dictionary<TKey, TValue> AddAt<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, int index,
            TKey key,
            TValue value) {
            if (index < 0 || index > dictionary.Count) {
                throw new ArgumentOutOfRangeException(nameof(index), "索引超出范围");
            }

            var list = new List<KeyValuePair<TKey, TValue>>(dictionary);

            list.Insert(index, new KeyValuePair<TKey, TValue>(key, value));

            dictionary.Clear();
            foreach (var kvp in list) {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }

        /// <summary>
        /// 在指定元素之前添加元素
        /// </summary>
        public static void AddBefore<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey existingKey,
            TKey newKey, TValue value) {
            int index = 0;
            foreach (var kvp in dictionary) {
                if (EqualityComparer<TKey>.Default.Equals(kvp.Key, existingKey)) {
                    break;
                }

                index++;
            }

            AddAt(dictionary, index, newKey, value);
        }

        /// <summary>
        /// 在指定元素之后添加元素
        /// </summary>
        public static void AddAfter<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey existingKey,
            TKey newKey, TValue value) {
            int index = 0;
            foreach (var kvp in dictionary) {
                if (EqualityComparer<TKey>.Default.Equals(kvp.Key, existingKey)) {
                    index++;
                    break;
                }

                index++;
            }

            AddAt(dictionary, index, newKey, value);
        }

        /// <summary>
        /// 从字典中获取指定范围的子字典
        /// </summary>
        public static Dictionary<TKey, TValue> GetRange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            int startIndex, int count) {
            if (startIndex < 0 || startIndex >= dictionary.Count || count < 0) {
                throw new ArgumentOutOfRangeException();
            }

            var subDictionary = new Dictionary<TKey, TValue>();

            int index = 0;
            foreach (var kvp in dictionary) {
                if (index >= startIndex && index < startIndex + count) {
                    subDictionary.Add(kvp.Key, kvp.Value);
                }

                index++;

                if (index == startIndex + count) {
                    break;
                }
            }

            return subDictionary;
        }

        /// <summary>
        /// 随机打乱字典
        /// </summary>
        public static void Shuffle<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) {
            var list = new List<KeyValuePair<TKey, TValue>>(dictionary);

            int n = list.Count;
            while (n > 1) {
                n--;
                int k = UnityEngine.Random.Range(0, n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            dictionary.Clear();
            foreach (var kvp in list) {
                dictionary.Add(kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// 将字典拆分为指定大小的块
        /// </summary>
        public static List<Dictionary<TKey, TValue>> Split<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            int chunkSize) {
            if (chunkSize <= 0) {
                throw new ArgumentException("块大小必须大于零。");
            }

            var chunks = new List<Dictionary<TKey, TValue>>();

            var chunk = new Dictionary<TKey, TValue>();
            foreach (var kvp in dictionary) {
                chunk.Add(kvp.Key, kvp.Value);

                if (chunk.Count == chunkSize) {
                    chunks.Add(chunk);
                    chunk = new Dictionary<TKey, TValue>();
                }
            }

            if (chunk.Count > 0) {
                chunks.Add(chunk);
            }

            return chunks;
        }


        /// <summary>
        /// 将目标字典中的键值对添加到当前字典中，如果键已存在，可以选择是否覆盖现有值。返回修改后的当前字典。
        /// </summary>
        public static Dictionary<K, V> AddRange<K, V>(this Dictionary<K, V> self, Dictionary<K, V> target,
            bool isOverride = false) {
            using (var dicE = target.GetEnumerator()) {
                while (dicE.MoveNext()) {
                    var current = dicE.Current;
                    if (self.ContainsKey(current.Key)) {
                        if (isOverride) {
                            self[current.Key] = current.Value;
                            continue;
                        }
                    }

                    self.Add(current.Key, current.Value);
                }
            }

            return self;
        }

        /// <summary>
        /// 根据指定条件筛选字典中的元素
        /// </summary>
        public static Dictionary<TKey, TValue> Where<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            Func<KeyValuePair<TKey, TValue>, bool> predicate) {
            var result = new Dictionary<TKey, TValue>();

            foreach (var kvp in dictionary) {
                if (predicate(kvp)) {
                    result.Add(kvp.Key, kvp.Value);
                }
            }

            return result;
        }

        /// <summary>
        /// 查找元素在字典中的索引，支持自定义比较器
        /// </summary>
        /// <returns></returns>
        public static int FindIndex<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue value,
            IEqualityComparer<TValue> comparer = null) {
            comparer ??= EqualityComparer<TValue>.Default;

            int index = 0;
            foreach (var kvp in dictionary) {
                if (comparer.Equals(kvp.Value, value)) {
                    return index;
                }

                index++;
            }

            return -1;
        }

        /// <summary>
        /// 将字典中的元素循环左移指定数量的位置
        /// </summary>
        public static void MoveToLeft<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, int positions) {
            if (dictionary.Count < 2) {
                return;
            }

            var list = new List<KeyValuePair<TKey, TValue>>(dictionary);
            positions %= list.Count;

            var rotated = list.GetRange(positions, list.Count - positions);
            rotated.AddRange(list.GetRange(0, positions));

            dictionary.Clear();
            foreach (var kvp in rotated) {
                dictionary.Add(kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// 将字典中的元素循环右移指定数量的位置
        /// </summary>
        public static void MoveToRight<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, int positions) {
            if (dictionary.Count < 2) {
                return;
            }

            var list = new List<KeyValuePair<TKey, TValue>>(dictionary);
            positions %= list.Count;

            var rotated = list.GetRange(list.Count - positions, positions);
            rotated.AddRange(list.GetRange(0, list.Count - positions));

            dictionary.Clear();
            foreach (var kvp in rotated) {
                dictionary.Add(kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// 如果字典中不包含指定的键，则添加键值对；否则，不执行任何操作。返回修改后的当前字典。
        /// </summary>
        public static Dictionary<K, V> TryAdd<K, V>(this Dictionary<K, V> self, K k, V v) {
            if (!self.ContainsKey(k)) {
                self.Add(k, v);
            }

            return self;
        }

        /// <summary>
        /// 根据键获取值，如果键不存在，则添加值。
        /// </summary>
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key,
            TValue defaultValue) {
            if (dictionary.TryGetValue(key, out TValue value))
                return value;

            dictionary[key] = defaultValue;
            return defaultValue;
        }

        /// <summary>
        /// 安全地添加项，仅当键不存在时才执行添加操作。
        /// </summary>
        public static Dictionary<TKey, TValue> AddSafe<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key,
            TValue value) {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            return dictionary;
        }
    }
}