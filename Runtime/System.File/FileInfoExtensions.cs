using System;
using System.Collections.Generic;
using System.IO;

namespace MFramework.Extensions.WindowsSystem
{
    public static class FileInfoExtensions
    {
        private static readonly HashSet<string> imageExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".bmp", ".tiff", ".gif", ".svg", ".raw", ".webp"
        };

        private static readonly HashSet<string> videoExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".mkv", ".wmv", ".avi", ".mpeg", ".mpg", ".rmvb", ".flv", ".mp4", ".mov"
        };

        private static readonly HashSet<string> unityVideoExtensions =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                ".mkv", ".wmv", ".avi", ".webm", ".mp4", ".mov"
            };

        private static readonly HashSet<string> textExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".txt", ".xml", ".json", ".xlsx", ".xls", ".csv", ".ini", ".config"
        };

        public static string FileNameWithoutExtension(this FileInfo fileInfo) =>
            Path.GetFileNameWithoutExtension(fileInfo.Name);

        public static bool IsImageFile(this FileInfo fileInfo) =>
            imageExtensions.Contains(fileInfo.Extension.ToLower());

        public static bool IsVideoFile(this FileInfo fileInfo) =>
            videoExtensions.Contains(fileInfo.Extension.ToLower());

        public static bool IsUnityVideoFile(this FileInfo fileInfo) =>
            unityVideoExtensions.Contains(fileInfo.Extension.ToLower());

        public static bool IsTextFile(this FileInfo fileInfo) => textExtensions.Contains(fileInfo.Extension.ToLower());
    }
}