using System;
using System.Text;

namespace MFramework.Extensions.DataType

{
    public static class BytesExtensions
    {
        public static int ToInt32(this byte[] bytes)
        {
            ValidateBytes(bytes, 4);
            return BitConverter.ToInt32(bytes, 0);
        }

        public static int ToInt32(this byte[] bytes, int startIndex)
        {
            ValidateBytes(bytes, startIndex, 4);
            return BitConverter.ToInt32(bytes, startIndex);
        }

        public static short ToInt16(this byte[] bytes)
        {
            ValidateBytes(bytes, 2);
            return BitConverter.ToInt16(bytes, 0);
        }

        public static short ToInt16(this byte[] bytes, int startIndex)
        {
            ValidateBytes(bytes, startIndex, 2);
            return BitConverter.ToInt16(bytes, startIndex);
        }

        public static long ToInt64(this byte[] bytes)
        {
            ValidateBytes(bytes, 8);
            return BitConverter.ToInt64(bytes, 0);
        }

        public static long ToInt64(this byte[] bytes, int startIndex)
        {
            ValidateBytes(bytes, startIndex, 8);
            return BitConverter.ToInt64(bytes, startIndex);
        }

        public static float ToFloat(this byte[] bytes)
        {
            ValidateBytes(bytes, 4);
            return BitConverter.ToSingle(bytes, 0);
        }

        public static float ToFloat(this byte[] bytes, int startIndex)
        {
            ValidateBytes(bytes, startIndex, 4);
            return BitConverter.ToSingle(bytes, startIndex);
        }

        public static bool ToBoolean(this byte[] bytes)
        {
            ValidateBytes(bytes, 1);
            return BitConverter.ToBoolean(bytes, 0);
        }

        public static bool ToBoolean(this byte[] bytes, int startIndex)
        {
            ValidateBytes(bytes, startIndex, 1);
            return BitConverter.ToBoolean(bytes, startIndex);
        }

        public static double ToDouble(this byte[] bytes)
        {
            ValidateBytes(bytes, 8);
            return BitConverter.ToDouble(bytes, 0);
        }

        public static double ToDouble(this byte[] bytes, int startIndex)
        {
            ValidateBytes(bytes, startIndex, 8);
            return BitConverter.ToDouble(bytes, startIndex);
        }

        public static ushort ToUInt16(this byte[] bytes)
        {
            ValidateBytes(bytes, 2);
            return BitConverter.ToUInt16(bytes, 0);
        }

        public static ushort ToUInt16(this byte[] bytes, int startIndex)
        {
            ValidateBytes(bytes, startIndex, 2);
            return BitConverter.ToUInt16(bytes, startIndex);
        }

        public static uint ToUInt32(this byte[] bytes)
        {
            ValidateBytes(bytes, 4);
            return BitConverter.ToUInt32(bytes, 0);
        }

        public static uint ToUInt32(this byte[] bytes, int startIndex)
        {
            ValidateBytes(bytes, startIndex, 4);
            return BitConverter.ToUInt32(bytes, startIndex);
        }

        public static ulong ToUInt64(this byte[] bytes)
        {
            ValidateBytes(bytes, 8);
            return BitConverter.ToUInt64(bytes, 0);
        }

        public static ulong ToUInt64(this byte[] bytes, int startIndex)
        {
            ValidateBytes(bytes, startIndex, 8);
            return BitConverter.ToUInt64(bytes, startIndex);
        }

        public static string ToUTF7(this byte[] bytes)
        {
            return Encoding.UTF7.GetString(bytes);
        }

        public static string ToUTF7(this byte[] bytes, int startIndex, int count)
        {
            return Encoding.UTF7.GetString(bytes, startIndex, count);
        }

        public static string ToUTF32(this byte[] bytes)
        {
            return Encoding.UTF32.GetString(bytes);
        }

        public static string ToUTF32(this byte[] bytes, int startIndex, int count)
        {
            return Encoding.UTF32.GetString(bytes, startIndex, count);
        }

        public static string ToUTF16(this byte[] bytes)
        {
            return Encoding.Unicode.GetString(bytes);
        }

        public static string ToUTF16(this byte[] bytes, int startIndex, int count)
        {
            return Encoding.Unicode.GetString(bytes, startIndex, count);
        }

        public static string ToBigEndianUTF16(this byte[] bytes)
        {
            return Encoding.BigEndianUnicode.GetString(bytes);
        }

        public static string ToBigEndianUTF16(this byte[] bytes, int startIndex, int count)
        {
            return Encoding.BigEndianUnicode.GetString(bytes, startIndex, count);
        }

        public static string ToGBK(this byte[] bytes)
        {
            return Encoding.GetEncoding("GBK").GetString(bytes);
        }

        public static string ToGBK(this byte[] bytes, int startIndex, int count)
        {
            return Encoding.GetEncoding("GBK").GetString(bytes, startIndex, count);
        }

        public static string ToUTF8(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static string ToUTF8(this byte[] bytes, int startIndex, int count)
        {
            return Encoding.UTF8.GetString(bytes, startIndex, count);
        }

        /// <summary>
        /// 从字节数组中复制指定长度的子数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] SubArray(this byte[] bytes, int startIndex, int length)
        {
            ValidateBytes(bytes, startIndex, length);
            byte[] result = new byte[length];
            Array.Copy(bytes, startIndex, result, 0, length);
            return result;
        }

        /// <summary>
        /// 比较两个字节数组是否相等
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool AreEqual(this byte[] bytes, byte[] other)
        {
            if (bytes == null || other == null)
                return bytes == other;
            if (bytes.Length != other.Length)
                return false;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] != other[i])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 将字节数组转换为十六进制字符串，方便调试和日志记录
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToHexString(this byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        /// <summary>
        /// 16进制格式字符串转普通文本
        /// </summary>
        /// <param name="hexString">16进制格式字符串</param>
        /// <param name="encode">编码规则</param>
        /// <returns></returns>
        public static string ToStringFromHexString(this string hexString, Encoding encode)
        {
            var bytes = hexString.ToHexadecimalBytes();
            return encode.GetString(bytes);
        }

        /// <summary>
        /// 填充指定字节数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        public static void Fill(this byte[] bytes, byte value, int startIndex, int count)
        {
            ValidateBytes(bytes, startIndex, count);
            for (int i = startIndex; i < startIndex + count; i++)
            {
                bytes[i] = value;
            }
        }

        /// <summary>
        /// 合并多个字节数组为一个
        /// </summary>
        /// <param name="first"></param>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public static byte[] Concat(this byte[] first, params byte[][] arrays)
        {
            int totalLength = first.Length;
            foreach (byte[] array in arrays)
            {
                if (array == null)
                    throw new ArgumentNullException(nameof(arrays));
                totalLength += array.Length;
            }

            byte[] result = new byte[totalLength];
            Buffer.BlockCopy(first, 0, result, 0, first.Length);
            int offset = first.Length;
            foreach (byte[] array in arrays)
            {
                Buffer.BlockCopy(array, 0, result, offset, array.Length);
                offset += array.Length;
            }

            return result;
        }


        /// <summary>
        /// 查找字节数组中的一个子数组的起始位置
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static int IndexOf(this byte[] bytes, byte[] pattern)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (pattern == null)
                throw new ArgumentNullException(nameof(pattern));
            if (pattern.Length == 0)
                return 0;

            for (int i = 0; i < bytes.Length - pattern.Length + 1; i++)
            {
                bool found = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (bytes[i + j] != pattern[j])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    return i;
                }
            }

            return -1;
        }

        private static void ValidateBytes(byte[] bytes, int requiredLength)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length < requiredLength)
                throw new ArgumentException($"The byte array must be at least {requiredLength} bytes long.",
                    nameof(bytes));
        }

        private static void ValidateBytes(byte[] bytes, int startIndex, int requiredLength)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (startIndex < 0 || startIndex >= bytes.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex),
                    "Start index is out of the range of the byte array.");
            if (bytes.Length - startIndex < requiredLength)
                throw new ArgumentException(
                    $"The byte array starting from {startIndex} must be at least {requiredLength} bytes long.",
                    nameof(bytes));
        }
    }
}