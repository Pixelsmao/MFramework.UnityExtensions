using System;
using UnityEngine;

namespace MFramework.Extensions.UnityComponent
{
    public static class TextureExtensions
    {
        /// <summary>
        /// 获取纹理的纵横比
        /// </summary>
        public static float GetAspectRatio(this Texture texture)
        {
            if (texture == null) throw new ArgumentNullException(nameof(texture), "Texture cannot be null.");
            return (float)texture.width / texture.height;
        }

        /// <summary>
        /// 验证是否是横向纹理
        /// </summary>
        public static bool IsHorizontal(this Texture texture)
        {
            if (texture == null) return false;
            return GetAspectRatio(texture) > 1;
        }

        /// <summary>
        /// 验证是否是垂直纹理
        /// </summary>
        public static bool IsVertical(this Texture texture)
        {
            if (texture == null) return false;
            var aspectRatio = GetAspectRatio(texture);
            return aspectRatio < 1;
        }

        /// <summary>
        /// 验证是否是方形纹理
        /// </summary>
        public static bool IsSquare(this Texture texture)
        {
            return texture != null && Mathf.Approximately(GetAspectRatio(texture), 1);
        }
    }
}