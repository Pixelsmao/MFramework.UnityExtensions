using System;
using UnityEngine;

// ReSharper disable InvalidXmlDocComment

namespace MFramework.Extensions
{
    public static class FloatExtension
    {
        /// <summary>
        /// 与目标值是否相等(约等于)
        /// </summary>
        /// <param name="target">目标值</param>
        /// <param name="accuracy">逼近准确度(精度误差)</param>
        public static bool EqualApproximately(this float value, float target, float nearAccuracy)
        {
            return Mathf.Abs(value - target) <= nearAccuracy;
        }

        /// <summary>
        /// 是否大于或约等于目标值
        /// </summary>
        /// <param name="target">目标值</param>
        /// <param name="nearAccuracy">逼近准确度(精度误差)</param>
        public static bool EqualApproximatelyOrGreater(this float value, float target, float nearAccuracy)
        {
            return value > target || EqualApproximately(value, target, nearAccuracy);
        }

        /// <summary>
        /// 是否小于或约等于目标值
        /// </summary>
        /// <param name="target">目标值</param>
        /// <param name="nearAccuracy">逼近准确度(精度误差)</param>
        public static bool EqualApproximatelyOrLess(this float value, float target, float nearAccuracy)
        {
            return value < target || EqualApproximately(value, target, nearAccuracy);
        }

        /// <summary>
        /// 限制一个值在指定的最小值和最大值之间
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        public static float Clamp(this float value, float min, float max)
        {
            if (value < min) return min;
            return value > max ? max : value;
        }

        /// <summary>
        /// 将一个范围内的值映射到另一个范围内。
        /// </summary>
        /// <param name="fromSource">源起始值</param>
        /// <param name="toSource">源终点值</param>
        /// <param name="fromTarget">目标起始值</param>
        /// <param name="toTarget">目标终点值</param>
        /// <returns></returns>
        public static float Map(this float value, float fromSource, float toSource, float fromTarget, float toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }

        /// <summary>
        /// 四舍五入到指定位数。
        /// </summary>
        /// <param name="decimalPlaces">保留小数点位数</param>
        /// <returns></returns>
        public static float RoundToDecimalPlaces(this float value, int decimalPlaces)
        {
            var power = Mathf.Pow(10, decimalPlaces);
            return Mathf.Round(value * power) / power;
        }

        /// <summary>
        /// 获在目标范围位置的0-1归一化值，当大于、小于极值时返回极值(0或1)，在范围中时不返回极值(0或1)
        /// </summary>
        /// <param name="minValue">范围最大值</param>
        /// <param name="maxValue">范围最小值</param>
        public static float Normalize(this float value, float minValue, float maxValue)
        {
            if (maxValue <= minValue) throw new ArgumentException("Max value must be greater than min value.");
            if (value > maxValue) return 1;
            if (value < minValue) return 1;
            return (value - minValue) / (maxValue - minValue);
        }

        /// <summary>
        /// 获在目标范围位置的0-1归一化值，当满足大于、小于或接近极值(最大值和最小值)的误差范围时返回归一化极值(0或1)。
        /// </summary>
        /// <param name="minValue">范围最大值</param>
        /// <param name="maxValue">范围最小值</param>
        /// <param name="nearAccuracy">逼近准确度(精度误差)</param>
        public static float NormalizeExtremum(this float value, float minValue, float maxValue, float nearAccuracy)
        {
            if (maxValue <= minValue) throw new ArgumentException("Max value must be greater than min value.");
            if (value.EqualApproximatelyOrGreater(maxValue, nearAccuracy)) return 1;
            if (value.EqualApproximatelyOrLess(minValue, nearAccuracy)) return 0;
            return (value - minValue) / (maxValue - minValue);
        }

        /// <summary>
        /// 转换为时钟时间
        /// </summary>
        public static ClockTime ToClockTime(this float value)
        {
            return new ClockTime(value);
        }
    }
}