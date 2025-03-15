using UnityEngine;

namespace MFramework.Extensions.UnityComponent
{
    public static class RectTransformExtensions
    {
        /// <summary>
        /// 设置矩形边距：左右两边同时增减相同的边距，上下两边同时增减相同的边距，保持中心位置不变
        /// </summary>
        /// <param name="source"></param>
        /// <param name="reduceSize">变化边距</param>
        public static void SetPaddingSize(this RectTransform source, Vector2Int reduceSize)
        {
            source.SetHorizontalWidth(reduceSize.x);
            source.SetVerticalHeight(reduceSize.y);
        }

        /// <summary>
        /// 设置水平宽度：左右两边同时增减相同的宽度，保持中心位置不变
        /// </summary>
        /// <param name="source"></param>
        /// <param name="reduce">变化量</param>
        public static void SetHorizontalWidth(this RectTransform source, float reduce)
        {
            var sizeDelta = source.sizeDelta;
            var anchoredPosition = source.anchoredPosition;

            // 计算宽度变化量
            var widthChange = reduce / 2;
            sizeDelta.x -= reduce;
            // 调整位置以保持中心不变
            anchoredPosition.x += widthChange;
            source.sizeDelta = sizeDelta;
            source.anchoredPosition = anchoredPosition;
        }


        /// <summary>
        /// 设置垂直高度：上下两边同时增减相同的高度，保持中心位置不变
        /// </summary>
        /// <param name="source"></param>
        /// <param name="reduce">变化量</param>
        public static void SetVerticalHeight(this RectTransform source, float reduce)
        {
            var sizeDelta = source.sizeDelta;
            var anchoredPosition = source.anchoredPosition;
            // 计算高度变化量
            var heightChange = reduce / 2;
            sizeDelta.y -= reduce;
            // 调整位置以保持中心不变
            anchoredPosition.y += heightChange;
            source.sizeDelta = sizeDelta;
            source.anchoredPosition = anchoredPosition;
        }


        public static void SetAnchor(this RectTransform source, AnchorPresets anchorPreset, int offsetX = 0,
            int offsetY = 0)
        {
            source.anchoredPosition = new Vector3(offsetX, offsetY, 0);

            switch (anchorPreset)
            {
                case (AnchorPresets.TopLeft):
                {
                    source.anchorMin = new Vector2(0, 1);
                    source.anchorMax = new Vector2(0, 1);
                    source.SetPivot(PivotPresets.TopLeft);
                    break;
                }
                case (AnchorPresets.TopCenter):
                {
                    source.anchorMin = new Vector2(0.5f, 1);
                    source.anchorMax = new Vector2(0.5f, 1);
                    source.SetPivot(PivotPresets.TopCenter);
                    break;
                }
                case (AnchorPresets.TopRight):
                {
                    source.anchorMin = new Vector2(1, 1);
                    source.anchorMax = new Vector2(1, 1);
                    source.SetPivot(PivotPresets.TopRight);
                    break;
                }

                case (AnchorPresets.MiddleLeft):
                {
                    source.anchorMin = new Vector2(0, 0.5f);
                    source.anchorMax = new Vector2(0, 0.5f);
                    source.SetPivot(PivotPresets.MiddleLeft);
                    break;
                }
                case (AnchorPresets.MiddleCenter):
                {
                    source.anchorMin = new Vector2(0.5f, 0.5f);
                    source.anchorMax = new Vector2(0.5f, 0.5f);
                    source.SetPivot(PivotPresets.MiddleCenter);
                    break;
                }
                case (AnchorPresets.MiddleRight):
                {
                    source.anchorMin = new Vector2(1, 0.5f);
                    source.anchorMax = new Vector2(1, 0.5f);
                    source.SetPivot(PivotPresets.MiddleRight);
                    break;
                }

                case (AnchorPresets.BottomLeft):
                {
                    source.anchorMin = new Vector2(0, 0);
                    source.anchorMax = new Vector2(0, 0);
                    source.SetPivot(PivotPresets.BottomLeft);
                    break;
                }
                case (AnchorPresets.BottomCenter):
                {
                    source.anchorMin = new Vector2(0.5f, 0);
                    source.anchorMax = new Vector2(0.5f, 0);
                    source.SetPivot(PivotPresets.BottomCenter);
                    break;
                }
                case (AnchorPresets.BottomRight):
                {
                    source.anchorMin = new Vector2(1, 0);
                    source.anchorMax = new Vector2(1, 0);
                    source.SetPivot(PivotPresets.BottomRight);
                    break;
                }

                case (AnchorPresets.HorStretchTop):
                {
                    source.anchorMin = new Vector2(0, 1);
                    source.anchorMax = new Vector2(1, 1);
                    break;
                }
                case (AnchorPresets.HorStretchMiddle):
                {
                    source.anchorMin = new Vector2(0, 0.5f);
                    source.anchorMax = new Vector2(1, 0.5f);
                    break;
                }
                case (AnchorPresets.HorStretchBottom):
                {
                    source.anchorMin = new Vector2(0, 0);
                    source.anchorMax = new Vector2(1, 0);
                    break;
                }

                case (AnchorPresets.VertStretchLeft):
                {
                    source.anchorMin = new Vector2(0, 0);
                    source.anchorMax = new Vector2(0, 1);
                    break;
                }
                case (AnchorPresets.VertStretchCenter):
                {
                    source.anchorMin = new Vector2(0.5f, 0);
                    source.anchorMax = new Vector2(0.5f, 1);
                    break;
                }
                case (AnchorPresets.VertStretchRight):
                {
                    source.anchorMin = new Vector2(1, 0);
                    source.anchorMax = new Vector2(1, 1);
                    break;
                }

                case (AnchorPresets.StretchAll):
                {
                    source.anchorMin = new Vector2(0, 0);
                    source.anchorMax = new Vector2(1, 1);
                    source.offsetMax = Vector2.zero;
                    source.offsetMin = Vector2.zero;
                    break;
                }
            }
        }

        public static void SetPivot(this RectTransform source, PivotPresets preset)
        {
            switch (preset)
            {
                case (PivotPresets.TopLeft):
                {
                    source.pivot = new Vector2(0, 1);
                    break;
                }
                case (PivotPresets.TopCenter):
                {
                    source.pivot = new Vector2(0.5f, 1);
                    break;
                }
                case (PivotPresets.TopRight):
                {
                    source.pivot = new Vector2(1, 1);
                    break;
                }

                case (PivotPresets.MiddleLeft):
                {
                    source.pivot = new Vector2(0, 0.5f);
                    break;
                }
                case (PivotPresets.MiddleCenter):
                {
                    source.pivot = new Vector2(0.5f, 0.5f);
                    break;
                }
                case (PivotPresets.MiddleRight):
                {
                    source.pivot = new Vector2(1, 0.5f);
                    break;
                }

                case (PivotPresets.BottomLeft):
                {
                    source.pivot = new Vector2(0, 0);
                    break;
                }
                case (PivotPresets.BottomCenter):
                {
                    source.pivot = new Vector2(0.5f, 0);
                    break;
                }
                case (PivotPresets.BottomRight):
                {
                    source.pivot = new Vector2(1, 0);
                    break;
                }
            }
        }
    }
}