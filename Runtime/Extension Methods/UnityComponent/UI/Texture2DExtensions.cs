using UnityEngine;

namespace MFramework.Extensions.UnityComponent
{
    public static class Texture2DExtensions
    {
        /// <summary>
        /// 纹理纵横比
        /// </summary>
        public static float GetAspectRatio(this Texture2D texture2D)
        {
            if (texture2D == null) return 0;
            return (float)texture2D.width / texture2D.height;
        }

        /// <summary>
        /// 验证是否是横向纹理
        /// </summary>
        public static bool VerifyHorizontal(this Texture2D texture2D) => GetAspectRatio(texture2D) > 1;

        /// <summary>
        /// 验证是否是垂直纹理
        /// </summary>
        public static bool VerifyVertical(this Texture2D texture2D)
        {
            var aspectRatio = GetAspectRatio(texture2D);
            return aspectRatio > 0 && aspectRatio < 1;
        }
    }
}