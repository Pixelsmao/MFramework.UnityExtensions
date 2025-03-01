using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace MFramework.Extensions.WindowsSystem
{
    public static class DirectoryInfoExtensions
    {
        /// <summary>
        /// 获取指定格式的文件：使用此方法必须使用FileExtension中的Filter常量作为文件筛选器参数。
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <param name="fileFilter">文件筛选器</param>
        /// <param name="searchOption">搜索选项</param>
        /// <returns></returns>
        public static FileInfo[] GetSpecifiedFiles(this DirectoryInfo directoryInfo, string fileFilter,
            SearchOption searchOption)
        {
            var expression = fileFilter.Split('\0')[1]
                .Split(';')
                .Select(ext => ext.TrimStart('*'))
                .ToArray();
            // 使用 DirectoryInfo.EnumerateFiles 并过滤扩展名
            var files = directoryInfo.EnumerateFiles("*", searchOption)
                .Where(f => expression.Contains(f.Extension.ToLower()))
                .ToArray();

            return files;
        }
    }
}