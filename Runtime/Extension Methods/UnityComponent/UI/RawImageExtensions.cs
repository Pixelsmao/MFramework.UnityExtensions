using System;
using UnityEngine;
using UnityEngine.UI;

namespace MFramework.Extensions.UnityComponent
{
    public static class RawImageExtensions
    {
        /// <summary>
        /// 根据给定的最大尺寸范围，自适应调整 RawImage 的尺寸
        /// </summary>
        public static void SetAdaptiveSize(this RawImage rawImage, Vector2 maxSize)
        {
            if (rawImage == null || rawImage.rectTransform == null)
                throw new ArgumentNullException(nameof(rawImage), "RawImage or its RectTransform cannot be null.");

            if (rawImage.texture == null)
            {
                rawImage.rectTransform.sizeDelta = maxSize;
                Debug.LogWarning($"{nameof(rawImage)} 的Texture为空，自适应尺寸设置为最大尺寸：{maxSize}");
                return;
            }

            var texture = rawImage.texture;
            var aspectRatio = texture.GetAspectRatio();

            if (Mathf.Approximately(aspectRatio, 1)) // 方形纹理
            {
                var minSize = Mathf.Min(maxSize.x, maxSize.y);
                rawImage.rectTransform.sizeDelta = new Vector2(minSize, minSize);
            }
            else if (aspectRatio > 1) // 横向纹理
            {
                // 先按宽度适配
                var width = maxSize.x;
                var height = maxSize.x / aspectRatio;

                // 如果高度超出最大高度，则按高度适配
                if (height > maxSize.y)
                {
                    height = maxSize.y;
                    width = maxSize.y * aspectRatio;
                }

                rawImage.rectTransform.sizeDelta = new Vector2(width, height);
            }
            else // 纵向纹理
            {
                // 先按高度适配
                var height = maxSize.y;
                var width = maxSize.y * aspectRatio;

                // 如果宽度超出最大宽度，则按宽度适配
                if (width > maxSize.x)
                {
                    width = maxSize.x;
                    height = maxSize.x / aspectRatio;
                }

                rawImage.rectTransform.sizeDelta = new Vector2(width, height);
            }
        }
    }
}