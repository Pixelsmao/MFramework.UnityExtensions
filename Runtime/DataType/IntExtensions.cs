using System;

namespace MFramework.Extensions.DataType
{
    public static class IntExtensions
    {
        public static bool IsInRange(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        public static int Clamp(this int value, int min, int max)
        {
            return value < min ? min : (value > max ? max : value);
        }

        public static string ToStringWithLeadingZeros(this int value, int totalLength)
        {
            return value.ToString().PadLeft(totalLength, '0');
        }

        public static T ToEnum<T>(this int value) where T : Enum
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

        public static int Abs(this int value)
        {
            return Math.Abs(value);
        }

        public static string ToTimeString(this int seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            return timeSpan.ToString(@"hh\:mm\:ss");
        }

        public static byte[] ToByteArray(this int value)
        {
            return BitConverter.GetBytes(value);
        }

        public static int Max(this int value, int otherValue)
        {
            return Math.Max(value, otherValue);
        }

        /// <summary>
        /// String convert to int
        /// </summary>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            return int.TryParse(str, out var i) ? i : default;
        }

        /// <summary>
        /// Enum convert to int
        /// </summary>
        /// <returns></returns>
        public static int ToInt(this Enum e)
        {
            return e.GetHashCode();
        }

        public static byte[] ToBytes(this int value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// 将整数转换为货币格式字符串
        /// </summary>
        public static string ToCurrencyString(this int value) => value.ToString("C");

        /// <summary>
        /// 将整数转换为十进制格式字符串
        /// </summary>
        public static string ToDecimalString(this int value) => value.ToString("D");

        /// <summary>
        /// 将整数转换为定点格式字符串
        /// </summary>
        public static string ToFixedPointString(this int value) => value.ToString("F");

        /// <summary>
        /// 将整数转换为数字格式字符串
        /// </summary>
        public static string ToNumberString(this int value) => value.ToString("N");

        /// <summary>
        /// 将整数转换为十六进制格式字符串
        /// </summary>
        public static string ToHexString(this int value) => value.ToString("X");

        /// <summary>
        /// 转换为时钟时间
        /// </summary>
        public static ClockTime ToClockTime(this int value)
        {
            return new ClockTime(value);
        }
    }
}