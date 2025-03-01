using UnityEngine;

namespace MFramework.UtilityLibrary
{
    ///https://www.codeeeee.com/color/rgb.html
    public static class ColorLibrary
    {
        /// <summary>
        /// 红色
        /// </summary>
        [Tooltip("红色")]
        public static Color Red => Color.red;

        /// <summary>
        /// 绿色
        /// </summary>
        [Tooltip("绿色")]
        public static Color Green => Color.green;

        /// <summary>
        /// 蓝色
        /// </summary>
        [Tooltip("蓝色")]
        public static Color Blue => Color.blue;

        /// <summary>
        /// 黄色
        /// </summary>
        [Tooltip("黄色")]
        public static Color Yellow => Color.yellow;

        /// <summary>
        /// 紫色
        /// </summary>
        [Tooltip("紫色")] public static Color Purple = new Color(0.5f, 0f, 0.5f);

        /// <summary>
        /// 青色
        /// </summary>
        [Tooltip("青色")]
        public static Color Cyan => Color.cyan;

        /// <summary>
        /// 白色
        /// </summary>
        [Tooltip("白色")]
        public static Color White => Color.white;

        /// <summary>
        /// 黑色
        /// </summary>
        [Tooltip("黑色")]
        public static Color Black => Color.black;

        /// <summary>
        /// 灰色
        /// </summary>
        [Tooltip("灰色")]
        public static Color Gray => Color.gray;

        /// <summary>
        /// 洋红色
        /// </summary>
        [Tooltip("洋红色")]
        public static Color Magenta => Color.magenta;

        /// <summary>
        /// 橘色
        /// </summary>
        [Tooltip("橘色")]
        public static Color Orange => Color.HSVToRGB(0.05f, 1f, 1f);

        /// <summary>
        /// 棕色
        /// </summary>
        [Tooltip("棕色")]
        public static Color Brown => Color.HSVToRGB(0.05f, 0.5f, 0.5f);

        /// <summary>
        /// 粉红色
        /// </summary>
        [Tooltip("粉红色")]
        public static Color Pink => Color.HSVToRGB(0.1f, 0.4f, 1f);

        /// <summary>
        /// 浅蓝色
        /// </summary>
        [Tooltip("浅蓝色")]
        public static Color LightBlue => new Color(0.1f, 0.5f, 0.7f);

        /// <summary>
        /// 透明色
        /// </summary>
        [Tooltip("透明色")]
        public static Color Transparent => Color.clear;


        /// <summary>
        /// 雪白
        /// </summary>
        [Tooltip("雪白")]
        public static Color Snow => ConvertUnityColor(255, 250, 250);

        /// <summary>
        /// 幽灵白
        /// </summary>
        [Tooltip("幽灵白")]
        public static Color GhostWhite => ConvertUnityColor(248, 248, 255);

        /// <summary>
        /// 烟雾白
        /// </summary>
        [Tooltip("烟雾白")]
        public static Color WhiteSmoke => ConvertUnityColor(245, 245, 245);

        /// <summary>
        /// 亮灰色
        /// </summary>
        [Tooltip("亮灰色")]
        public static Color Gainsboro => ConvertUnityColor(220, 220, 220);

        /// <summary>
        /// 花白
        /// </summary>
        [Tooltip("花白")]
        public static Color FloralWhite => ConvertUnityColor(255, 250, 240);

        /// <summary>
        /// 老花色
        /// </summary>
        [Tooltip("老花色")]
        public static Color OldLace => ConvertUnityColor(253, 245, 230);

        /// <summary>
        /// 亚麻色
        /// </summary>
        [Tooltip("亚麻色")]
        public static Color Linen => ConvertUnityColor(250, 240, 230);

        /// <summary>
        /// 古董白
        /// </summary>
        [Tooltip("古董白")]
        public static Color AntiqueWhite => ConvertUnityColor(250, 235, 215);

        /// <summary>
        /// 木瓜鞭
        /// </summary>
        [Tooltip("木瓜鞭")]
        public static Color PapayaWhip => ConvertUnityColor(255, 239, 213);

        /// <summary>
        /// 杏仁色
        /// </summary>
        [Tooltip("杏仁色")]
        public static Color BlanchedAlmond => ConvertUnityColor(255, 239, 205);

        /// <summary>
        /// 橘黄色
        /// </summary>
        [Tooltip("橘黄色")]
        public static Color Bisque => ConvertUnityColor(255, 228, 196);

        /// <summary>
        /// 桃色
        /// </summary>
        [Tooltip("桃色")]
        public static Color PeachPuff => ConvertUnityColor(255, 218, 185);

        /// <summary>
        /// 纳瓦白
        /// </summary>
        [Tooltip("纳瓦白")]
        public static Color NavajoWhite => ConvertUnityColor(255, 222, 173);

        /// <summary>
        /// 鹿皮鞋色
        /// </summary>
        [Tooltip("鹿皮鞋色")]
        public static Color Moccasin => ConvertUnityColor(255, 228, 181);

        /// <summary>
        /// 米绸色
        /// </summary>
        [Tooltip("米绸色")]
        public static Color Cornsilk => ConvertUnityColor(255, 248, 220);

        /// <summary>
        /// 象牙白
        /// </summary>
        [Tooltip("象牙白")]
        public static Color Ivory => ConvertUnityColor(255, 255, 240);

        /// <summary>
        /// 柠檬绸色
        /// </summary>
        [Tooltip("柠檬绸色")]
        public static Color LemonChiffon => ConvertUnityColor(255, 250, 205);

        /// <summary>
        /// 贝壳粉
        /// </summary>
        [Tooltip("贝壳粉")]
        public static Color Seashell => ConvertUnityColor(255, 245, 238);

        /// <summary>
        /// 蜜瓜绿
        /// </summary>
        [Tooltip("蜜瓜绿")]
        public static Color Honeydew => ConvertUnityColor(240, 255, 240);

        /// <summary>
        /// 天青色
        /// </summary>
        [Tooltip("天青色")]
        public static Color Azure => ConvertUnityColor(240, 255, 255);

        /// <summary>
        /// 艾丽斯蓝
        /// </summary>
        [Tooltip("艾丽斯蓝")]
        public static Color AliceBlue => ConvertUnityColor(240, 248, 255);

        /// <summary>
        /// 薰衣草紫
        /// </summary>
        [Tooltip("薰衣草紫")]
        public static Color Lavender => ConvertUnityColor(230, 230, 250);

        /// <summary>
        /// 淡紫红
        /// </summary>
        [Tooltip("淡紫红")]
        public static Color LavenderBlush => ConvertUnityColor(255, 240, 245);

        /// <summary>
        /// 雾玫瑰色
        /// </summary>
        [Tooltip("雾玫瑰色")]
        public static Color MistyRose => ConvertUnityColor(255, 228, 225);

        /// <summary>
        /// 暗灰色
        /// </summary>
        [Tooltip("暗灰色")]
        public static Color DimGrey => ConvertUnityColor(105, 105, 105);

        /// <summary>
        /// 深石板灰
        /// </summary>
        [Tooltip("深石板灰")]
        public static Color DarkSlateGray => ConvertUnityColor(47, 79, 79);

        /// <summary>
        /// 石板灰
        /// </summary>
        [Tooltip("石板灰")]
        public static Color SlateGrey => ConvertUnityColor(112, 128, 144);

        /// <summary>
        /// 浅石板灰
        /// </summary>
        [Tooltip("浅石板灰")]
        public static Color LightSlateGray => ConvertUnityColor(112, 128, 144);

        /// <summary>
        /// 灰色
        /// </summary>
        [Tooltip("灰色")]
        public static Color Grey => ConvertUnityColor(190, 190, 190);

        /// <summary>
        /// 浅灰色
        /// </summary>
        [Tooltip("浅灰色")]
        public static Color LightGray => ConvertUnityColor(190, 190, 190);

        /// <summary>
        /// 深蓝色
        /// </summary>
        [Tooltip("深蓝色")]
        public static Color MidnightBlue => ConvertUnityColor(25, 25, 112);

        /// <summary>
        /// 海军蓝
        /// </summary>
        [Tooltip("海军蓝")]
        public static Color NavyBlue => ConvertUnityColor(0, 0, 128);

        /// <summary>
        /// 矢车菊蓝
        /// </summary>
        [Tooltip("矢车菊蓝")]
        public static Color CornflowerBlue => ConvertUnityColor(100, 149, 237);

        /// <summary>
        /// 深石板蓝
        /// </summary>
        [Tooltip("暗灰蓝")]
        public static Color DarkSlateBlue => ConvertUnityColor(72, 61, 139);

        /// <summary>
        /// 石板蓝
        /// </summary>
        [Tooltip("石板蓝")]
        public static Color SlateBlue => ConvertUnityColor(106, 90, 205);

        /// <summary>
        /// 间石板蓝
        /// </summary>
        [Tooltip("间石板蓝")]
        public static Color MediumSlateBlue => ConvertUnityColor(123, 104, 238);

        /// <summary>
        /// 浅石板蓝
        /// </summary>
        [Tooltip("浅石板蓝")]
        public static Color LightSlateBlue => ConvertUnityColor(132, 112, 255);

        /// <summary>
        /// 中蓝色
        /// </summary>
        [Tooltip("中蓝色")]
        public static Color MediumBlue => ConvertUnityColor(0, 0, 205);

        /// <summary>
        /// 皇家蓝
        /// </summary>
        [Tooltip("皇家蓝")]
        public static Color RoyalBlue => ConvertUnityColor(65, 105, 225);

        /// <summary>
        /// 闪蓝色(道奇蓝)
        /// </summary>
        [Tooltip("闪蓝色(道奇蓝)")]
        public static Color DodgerBlue => ConvertUnityColor(30, 144, 255);

        /// <summary>
        /// 深空蓝
        /// </summary>
        [Tooltip("深空蓝")]
        public static Color DeepSkyBlue => ConvertUnityColor(0, 191, 235);

        /// <summary>
        /// 天蓝色
        /// </summary>
        [Tooltip("天蓝色")]
        public static Color SkyBlue => ConvertUnityColor(135, 206, 235);

        /// <summary>
        /// 浅天蓝
        /// </summary>
        [Tooltip("浅天蓝")]
        public static Color LightSkyBlue => ConvertUnityColor(135, 206, 250);

        /// <summary>
        /// 铁青色
        /// </summary>
        [Tooltip("铁青色")]
        public static Color SteelBlue => ConvertUnityColor(70, 130, 180);

        /// <summary>
        /// 浅铁青色
        /// </summary>
        [Tooltip("浅铁青色")]
        public static Color LightSteelBlue => ConvertUnityColor(176, 196, 222);

        /// <summary>
        /// 粉蓝色
        /// </summary>
        [Tooltip("粉蓝色")]
        public static Color PowderBlue => ConvertUnityColor(176, 224, 230);

        /// <summary>
        /// 浅宝石绿
        /// </summary>
        [Tooltip("浅宝石绿")]
        public static Color PaleTurquoise => ConvertUnityColor(175, 238, 238);

        /// <summary>
        /// 暗宝石绿
        /// </summary>
        [Tooltip("暗宝石绿")]
        public static Color DarkTurquoise => ConvertUnityColor(0, 206, 209);

        /// <summary>
        /// 间宝石绿
        /// </summary>
        [Tooltip("间宝石绿")]
        public static Color MediumTurquoise => ConvertUnityColor(72, 209, 204);

        /// <summary>
        /// 宝石绿
        /// </summary>
        [Tooltip("宝石绿")]
        public static Color Turquoise => ConvertUnityColor(72, 209, 204);

        /// <summary>
        /// 淡青色
        /// </summary>
        [Tooltip("淡青色")]
        public static Color LightCyan => ConvertUnityColor(224, 255, 255);

        /// <summary>
        /// 军绿色
        /// </summary>
        [Tooltip("军绿色")]
        public static Color CadetBlue => ConvertUnityColor(95, 158, 160);

        /// <summary>
        /// 间绿色
        /// </summary>
        [Tooltip("间绿色")]
        public static Color MediumAquamarine => ConvertUnityColor(102, 205, 170);

        /// <summary>
        /// 海宝石蓝
        /// </summary>
        [Tooltip("海宝石蓝")]
        public static Color Aquamarine => ConvertUnityColor(127, 255, 212);

        /// <summary>
        /// 深绿色
        /// </summary>
        [Tooltip("深绿色")]
        public static Color DarkGreen => ConvertUnityColor(0, 100, 0);

        /// <summary>
        /// 深橄榄绿
        /// </summary>
        [Tooltip("深橄榄绿")]
        public static Color DarkOliveGreen => ConvertUnityColor(85, 107, 47);

        /// <summary>
        /// 深海绿
        /// </summary>
        [Tooltip("深海绿")]
        public static Color DarkSeaGreen => ConvertUnityColor(143, 188, 143);

        /// <summary>
        /// 海绿色
        /// </summary>
        [Tooltip("海绿色")]
        public static Color SeaGreen => ConvertUnityColor(46, 139, 87);

        /// <summary>
        /// 间海绿
        /// </summary>
        [Tooltip("间海绿")]
        public static Color MediumSeaGreen => ConvertUnityColor(60, 179, 113);

        /// <summary>
        /// 浅海绿
        /// </summary>
        [Tooltip("浅海绿")]
        public static Color LightSeaGreen => ConvertUnityColor(32, 178, 170);

        /// <summary>
        /// 浅绿色
        /// </summary>
        [Tooltip("浅绿色")]
        public static Color PaleGreen => ConvertUnityColor(152, 251, 152);

        /// <summary>
        /// 春绿色
        /// </summary>
        [Tooltip("春绿色")]
        public static Color SpringGreen => ConvertUnityColor(0, 255, 127);

        /// <summary>
        /// 草坪绿
        /// </summary>
        [Tooltip("草坪绿")]
        public static Color LawnGreen => ConvertUnityColor(124, 252, 0);

        /// <summary>
        /// 黄绿色
        /// </summary>
        [Tooltip("黄绿色")]
        public static Color Chartreuse => ConvertUnityColor(127, 255, 0);

        /// <summary>
        /// 地中海春绿
        /// </summary>
        [Tooltip("地中海春绿")]
        public static Color MedSpringGreen => ConvertUnityColor(0, 250, 154);

        public static Color GrayPercentage(float percentage, float alpha = 1) =>
            new Color(percentage, percentage, percentage, alpha);

        private static Color ConvertUnityColor(int r, int g, int b, float alpha = 1) =>
            new Color(r / 255f, g / 255f, b / 255f, alpha);
    }
}