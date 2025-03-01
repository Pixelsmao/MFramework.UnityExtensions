using System;
using System.Collections.Generic;
using System.Linq;

namespace MFramework.Extensions.DataStructure
{
    public static class QueueExtensions
    {
        /// <summary>
        /// 一次性将一系列元素添加到队列中。
        /// </summary>
        public static void EnqueueRange<T>(this Queue<T> queue, IEnumerable<T> items) {
            if (queue == null) {
                throw new ArgumentNullException(nameof(queue));
            }

            if (items == null) {
                throw new ArgumentNullException(nameof(items));
            }

            foreach (var item in items) {
                queue.Enqueue(item);
            }
        }

        /// <summary>
        /// 一次性从队列中取出一系列元素。
        /// </summary>
        public static IEnumerable<T> DequeueRange<T>(this Queue<T> queue, int count) {
            if (queue == null) {
                throw new ArgumentNullException(nameof(queue));
            }

            if (count < 0) {
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be negative.");
            }

            var items = new List<T>(count);
            for (int i = 0; i < count && queue.Count > 0; i++) {
                items.Add(queue.Dequeue());
            }

            return items;
        }

        /// <summary>
        /// 一次性查看队列中一系列元素而不移除它们。
        /// </summary>
        public static IEnumerable<T> PeekRange<T>(this Queue<T> queue, int count) {
            if (queue == null) {
                throw new ArgumentNullException(nameof(queue));
            }

            if (count < 0) {
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be negative.");
            }

            return queue.Take(count);
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        public static bool IsEmpty<T>(this Queue<T> queue) {
            if (queue == null) {
                throw new ArgumentNullException(nameof(queue));
            }

            return queue.Count == 0;
        }
    }
}