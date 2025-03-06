using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MFramework.Extensions.UnityComponent
{
    public static class ScrollbarExtensions
    {
        /// <summary>
        /// 不为空、激活并启用、在层次面板中启用
        /// </summary>
        public static bool IsAvailable(this Scrollbar scrollbar)
        {
            return scrollbar != null && scrollbar.isActiveAndEnabled && scrollbar.gameObject.activeInHierarchy;
        }

        /// <summary>
        /// 立即将Scrollbar的Value设置为指定大小
        /// </summary>
        public static void ValueChangeImmediately(this Scrollbar scrollbar, float value)
        {
            if (!scrollbar.IsAvailable()) return;
            scrollbar.value = value;
        }

        /// <summary>
        /// 增加Scrollbar的Value
        /// </summary>
        public static void ValueUpImmediately(this Scrollbar scrollbar, float intervalValue = 0.25F)
        {
            if (!scrollbar.IsAvailable()) return;
            scrollbar.value += intervalValue;
        }

        /// <summary>
        /// 增加Scrollbar的Value
        /// </summary>
        public static void ValueDownImmediately(this Scrollbar scrollbar, float intervalValue = 0.25F)
        {
            if (!scrollbar.IsAvailable()) return;
            scrollbar.value -= intervalValue;
        }

        /// <summary>
        /// Value恢复到起点
        /// </summary>
        public static void ValueChangeToStartImmediately(this Scrollbar scrollbar)
        {
            if (!scrollbar.IsAvailable()) return;
            switch (scrollbar.direction)
            {
                case Scrollbar.Direction.LeftToRight:
                    scrollbar.ValueChangeImmediately(0);
                    break;
                case Scrollbar.Direction.RightToLeft:
                    scrollbar.ValueChangeImmediately(1);
                    break;
                case Scrollbar.Direction.BottomToTop:
                    scrollbar.ValueChangeImmediately(1);
                    break;
                case Scrollbar.Direction.TopToBottom:
                    scrollbar.ValueChangeImmediately(0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Value恢复到终点
        /// </summary>
        public static void ValueChangeToEndImmediately(this Scrollbar scrollbar)
        {
            if (!scrollbar.IsAvailable()) return;
            switch (scrollbar.direction)
            {
                case Scrollbar.Direction.LeftToRight:
                    scrollbar.ValueChangeImmediately(1);
                    break;
                case Scrollbar.Direction.RightToLeft:
                    scrollbar.ValueChangeImmediately(0);
                    break;
                case Scrollbar.Direction.BottomToTop:
                    scrollbar.ValueChangeImmediately(0);
                    break;
                case Scrollbar.Direction.TopToBottom:
                    scrollbar.ValueChangeImmediately(1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void ValueChangeSmoothly(this Scrollbar scrollbar, float value, float duration = 0.5f)
        {
            if (!scrollbar.IsAvailable()) return;
            scrollbar.StartCoroutine(SmoothValueTo(scrollbar, value, duration));
        }


        /// <summary>
        /// 平滑增大Value
        /// </summary>
        public static void ValueUpSmoothly(this Scrollbar scrollbar, float intervalValue = 0.25F,
            float duration = 0.5f)
        {
            if (!scrollbar.IsAvailable()) return;
            scrollbar.ValueChangeSmoothly(scrollbar.value + intervalValue);
        }

        /// <summary>
        /// 平滑减小Value
        /// </summary>
        public static void ValueDownSmoothly(this Scrollbar scrollbar, float intervalValue = 0.25F,
            float duration = 0.5f)
        {
            if (!scrollbar.IsAvailable()) return;
            scrollbar.ValueChangeSmoothly(scrollbar.value - intervalValue);
        }

        /// <summary>
        /// Value平滑变化到起始位置
        /// </summary>
        public static void ValueChangeToStartSmoothly(this Scrollbar scrollbar)
        {
            if (!scrollbar.IsAvailable()) return;
            switch (scrollbar.direction)
            {
                case Scrollbar.Direction.LeftToRight:
                    scrollbar.ValueChangeSmoothly(0);
                    break;
                case Scrollbar.Direction.RightToLeft:
                    scrollbar.ValueChangeSmoothly(1);
                    break;
                case Scrollbar.Direction.BottomToTop:
                    scrollbar.ValueChangeSmoothly(1);
                    break;
                case Scrollbar.Direction.TopToBottom:
                    scrollbar.ValueChangeSmoothly(0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Value平滑变化到终点位置
        /// </summary>
        public static void ValueChangeToEndSmoothly(this Scrollbar scrollbar)
        {
            if (!scrollbar.IsAvailable()) return;
            switch (scrollbar.direction)
            {
                case Scrollbar.Direction.LeftToRight:
                    scrollbar.ValueChangeSmoothly(1);
                    break;
                case Scrollbar.Direction.RightToLeft:
                    scrollbar.ValueChangeSmoothly(0);
                    break;
                case Scrollbar.Direction.BottomToTop:
                    scrollbar.ValueChangeSmoothly(0);
                    break;
                case Scrollbar.Direction.TopToBottom:
                    scrollbar.ValueChangeSmoothly(1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static IEnumerator SmoothValueTo(Scrollbar scrollbar, float targetValue, float duration)
        {
            var timeElapsed = 0.0f;
            var startValue = scrollbar.value;

            while (timeElapsed < duration)
            {
                float newValue = Mathf.Lerp(startValue, targetValue, timeElapsed / duration);
                scrollbar.value = Mathf.Clamp01(newValue);
                yield return null;
                timeElapsed += Time.deltaTime;
            }

            scrollbar.value = Mathf.Clamp01(targetValue);
        }
    }
}