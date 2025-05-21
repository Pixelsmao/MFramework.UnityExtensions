using UnityEngine;

namespace MFramework.Extensions.UnityComponent
{
    public static class RectTransformExtensions
    {
        /// <summary>
        /// 设置矩形边距：左右两边同时增减相同的边距，上下两边同时增减相同的边距，保持中心位置不变
        /// </summary>
        /// <param name="self"></param>
        /// <param name="reduceSize">变化边距</param>
        public static void SetPaddingSize(this RectTransform self, Vector2Int reduceSize)
        {
            self.SetHorizontalWidth(reduceSize.x);
            self.SetVerticalHeight(reduceSize.y);
        }

        /// <summary>
        /// 设置水平宽度：左右两边同时增减相同的宽度，保持中心位置不变
        /// </summary>
        /// <param name="self"></param>
        /// <param name="reduce">变化量</param>
        public static void SetHorizontalWidth(this RectTransform self, float reduce)
        {
            var sizeDelta = self.sizeDelta;
            var anchoredPosition = self.anchoredPosition;

            // 计算宽度变化量
            var widthChange = reduce / 2;
            sizeDelta.x -= reduce;
            // 调整位置以保持中心不变
            anchoredPosition.x += widthChange;
            self.sizeDelta = sizeDelta;
            self.anchoredPosition = anchoredPosition;
        }


        /// <summary>
        /// 设置垂直高度：上下两边同时增减相同的高度，保持中心位置不变
        /// </summary>
        /// <param name="self"></param>
        /// <param name="reduce">变化量</param>
        public static void SetVerticalHeight(this RectTransform self, float reduce)
        {
            var sizeDelta = self.sizeDelta;
            var anchoredPosition = self.anchoredPosition;
            // 计算高度变化量
            var heightChange = reduce / 2;
            sizeDelta.y -= reduce;
            // 调整位置以保持中心不变
            anchoredPosition.y += heightChange;
            self.sizeDelta = sizeDelta;
            self.anchoredPosition = anchoredPosition;
        }

        /// <summary>
        /// 相对于父对象随机化位置
        /// </summary>
        public static void RandomizedAnchoredPosition(this RectTransform self)
        {
            self.SetAnchor(AnchorPresets.MiddleCenter);
            self.anchoredPosition = Vector2.zero;
            var parentSize = self.parent.ToRectTransform().rect.size;
            var randomX = Random.Range(-parentSize.x / 2, parentSize.x / 2);
            var randomY = Random.Range(-parentSize.y / 2, parentSize.y / 2);
            self.anchoredPosition = new Vector2(randomX, randomY);
        }

        /// <summary>
        /// 相对RectTransform随机化位置：随机化位置基于目标RectTransform的随机位置
        /// </summary>
        public static void RandomizedAnchoredPosition(this RectTransform self, RectTransform targetRectTransform)
        {
            self.position = targetRectTransform.position;
            var position = self.position;
            var parentSize = targetRectTransform.rect.size;
            var randomX = Random.Range(-parentSize.x / 2, parentSize.x / 2);
            var randomY = Random.Range(-parentSize.y / 2, parentSize.y / 2);
            self.anchoredPosition = new Vector2(position.x + randomX, position.y + randomY);
        }

        public static void SetAnchor(this RectTransform self, AnchorPresets anchorPreset, int offsetX = 0,
            int offsetY = 0)
        {
            self.anchoredPosition = new Vector3(offsetX, offsetY, 0);

            switch (anchorPreset)
            {
                case (AnchorPresets.TopLeft):
                {
                    self.anchorMin = new Vector2(0, 1);
                    self.anchorMax = new Vector2(0, 1);
                    self.SetPivot(PivotPresets.TopLeft);
                    break;
                }
                case (AnchorPresets.TopCenter):
                {
                    self.anchorMin = new Vector2(0.5f, 1);
                    self.anchorMax = new Vector2(0.5f, 1);
                    self.SetPivot(PivotPresets.TopCenter);
                    break;
                }
                case (AnchorPresets.TopRight):
                {
                    self.anchorMin = new Vector2(1, 1);
                    self.anchorMax = new Vector2(1, 1);
                    self.SetPivot(PivotPresets.TopRight);
                    break;
                }

                case (AnchorPresets.MiddleLeft):
                {
                    self.anchorMin = new Vector2(0, 0.5f);
                    self.anchorMax = new Vector2(0, 0.5f);
                    self.SetPivot(PivotPresets.MiddleLeft);
                    break;
                }
                case (AnchorPresets.MiddleCenter):
                {
                    self.anchorMin = new Vector2(0.5f, 0.5f);
                    self.anchorMax = new Vector2(0.5f, 0.5f);
                    self.SetPivot(PivotPresets.MiddleCenter);
                    break;
                }
                case (AnchorPresets.MiddleRight):
                {
                    self.anchorMin = new Vector2(1, 0.5f);
                    self.anchorMax = new Vector2(1, 0.5f);
                    self.SetPivot(PivotPresets.MiddleRight);
                    break;
                }

                case (AnchorPresets.BottomLeft):
                {
                    self.anchorMin = new Vector2(0, 0);
                    self.anchorMax = new Vector2(0, 0);
                    self.SetPivot(PivotPresets.BottomLeft);
                    break;
                }
                case (AnchorPresets.BottomCenter):
                {
                    self.anchorMin = new Vector2(0.5f, 0);
                    self.anchorMax = new Vector2(0.5f, 0);
                    self.SetPivot(PivotPresets.BottomCenter);
                    break;
                }
                case (AnchorPresets.BottomRight):
                {
                    self.anchorMin = new Vector2(1, 0);
                    self.anchorMax = new Vector2(1, 0);
                    self.SetPivot(PivotPresets.BottomRight);
                    break;
                }

                case (AnchorPresets.HorStretchTop):
                {
                    self.anchorMin = new Vector2(0, 1);
                    self.anchorMax = new Vector2(1, 1);
                    break;
                }
                case (AnchorPresets.HorStretchMiddle):
                {
                    self.anchorMin = new Vector2(0, 0.5f);
                    self.anchorMax = new Vector2(1, 0.5f);
                    break;
                }
                case (AnchorPresets.HorStretchBottom):
                {
                    self.anchorMin = new Vector2(0, 0);
                    self.anchorMax = new Vector2(1, 0);
                    break;
                }

                case (AnchorPresets.VertStretchLeft):
                {
                    self.anchorMin = new Vector2(0, 0);
                    self.anchorMax = new Vector2(0, 1);
                    break;
                }
                case (AnchorPresets.VertStretchCenter):
                {
                    self.anchorMin = new Vector2(0.5f, 0);
                    self.anchorMax = new Vector2(0.5f, 1);
                    break;
                }
                case (AnchorPresets.VertStretchRight):
                {
                    self.anchorMin = new Vector2(1, 0);
                    self.anchorMax = new Vector2(1, 1);
                    break;
                }

                case (AnchorPresets.StretchAll):
                {
                    self.anchorMin = new Vector2(0, 0);
                    self.anchorMax = new Vector2(1, 1);
                    self.offsetMax = Vector2.zero;
                    self.offsetMin = Vector2.zero;
                    break;
                }
            }
        }

        public static void SetPivot(this RectTransform self, PivotPresets preset)
        {
            switch (preset)
            {
                case (PivotPresets.TopLeft):
                {
                    self.pivot = new Vector2(0, 1);
                    break;
                }
                case (PivotPresets.TopCenter):
                {
                    self.pivot = new Vector2(0.5f, 1);
                    break;
                }
                case (PivotPresets.TopRight):
                {
                    self.pivot = new Vector2(1, 1);
                    break;
                }

                case (PivotPresets.MiddleLeft):
                {
                    self.pivot = new Vector2(0, 0.5f);
                    break;
                }
                case (PivotPresets.MiddleCenter):
                {
                    self.pivot = new Vector2(0.5f, 0.5f);
                    break;
                }
                case (PivotPresets.MiddleRight):
                {
                    self.pivot = new Vector2(1, 0.5f);
                    break;
                }

                case (PivotPresets.BottomLeft):
                {
                    self.pivot = new Vector2(0, 0);
                    break;
                }
                case (PivotPresets.BottomCenter):
                {
                    self.pivot = new Vector2(0.5f, 0);
                    break;
                }
                case (PivotPresets.BottomRight):
                {
                    self.pivot = new Vector2(1, 0);
                    break;
                }
            }
        }
    }
}