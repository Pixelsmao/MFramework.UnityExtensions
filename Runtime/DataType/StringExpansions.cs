using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MFramework.Libraries;
using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global

namespace MFramework.Extensions.DataType
{
    public static class StringExpansions
    {
        #region Type Conversion

        /// <summary>
        /// 字符型转换为整型：指定字符无法转换为整型时返回值为-1
        /// </summary>
        public static int ToInt(this string self) => int.TryParse(self, out var int32) ? int32 : -1;

        /// <summary>
        /// 将字符转换为UTF7字节数组
        /// </summary>
        public static byte[] ToUTF7Bytes(this string self) => Encoding.UTF7.GetBytes(self);

        /// <summary>
        /// 将字符转换为UTF7格式
        /// </summary>
        public static string ToUTF7(this string self) => BitConverter.ToString(ToUTF7Bytes(self));

        /// <summary>
        /// 将字符转换为UTF8字节数组
        /// </summary>
        public static byte[] ToUTF8Bytes(this string self) => Encoding.UTF8.GetBytes(self);

        /// <summary>
        /// 将字符转换为UTF8格式
        /// </summary>
        public static string ToUTF8(this string self) => BitConverter.ToString(ToUTF8Bytes(self));

        /// <summary>
        /// 将字符转换为UTF32字节数组
        /// </summary>
        public static byte[] ToUTF32Bytes(this string self) => Encoding.UTF32.GetBytes(self);

        /// <summary>
        /// 将字符转换为UTF32格式
        /// </summary>
        public static string ToUTF32(this string self) => BitConverter.ToString(ToUTF32Bytes(self));

        /// <summary>
        /// 将字符转换为Unicode字节数组
        /// </summary>
        public static byte[] ToUnicodeBytes(this string self) => Encoding.Unicode.GetBytes(self);

        /// <summary>
        /// 将字符转换为Unicode格式
        /// </summary>
        public static string ToUnicode(this string self) => BitConverter.ToString(ToUnicodeBytes(self));

        /// <summary>
        /// 将字符转换为BigEndianUnicode字节数组
        /// </summary>
        public static byte[] ToBigEndianUnicodeBytes(this string self) => Encoding.BigEndianUnicode.GetBytes(self);

        /// <summary>
        /// 将字符转换为BigEndianUnicode格式
        /// </summary>
        public static string ToBigEndianUnicode(this string self) =>
            BitConverter.ToString(ToBigEndianUnicodeBytes(self));

        /// <summary>
        /// 将字符转换为GBK字节数组
        /// </summary>
        public static byte[] ToGBKBytes(this string self) => Encoding.GetEncoding("GBK").GetBytes(self);

        /// <summary>
        /// 将字符转换为GBK格式
        /// </summary>
        public static string ToGBK(this string self) => BitConverter.ToString(ToGBKBytes(self));

        /// <summary>
        /// 转换为十六进制字节数组，不是十六进制字符串时返回null
        /// </summary>
        public static byte[] ToHexadecimalBytes(this string self)
        {
            if (!self.IsHexadecimal()) return null;
            var chars = self.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var bytes = new byte[chars.Length];
            //逐个字符变为16进制字节数据
            for (int i = 0; i < chars.Length; i++)
            {
                bytes[i] = Convert.ToByte(chars[i], 16);
            }

            return bytes;
        }

        /// <summary>
        /// 转换为时钟时间
        /// </summary>
        public static ClockTime ToClockTime(this string value)
        {
            return new ClockTime(value);
        }

        /// <summary>
        /// 将字符转换为Type类型
        /// </summary>
        public static Type ToType(this string typeName)
        {
            typeName ??= string.Empty;
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var type = assembly.GetType(typeName);
                if (type != null) return type;
            }

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.Name.Equals(typeName, StringComparison.OrdinalIgnoreCase))
                    {
                        return type;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 将Windows路径格式中'\'替换为'/'，适用于基于Linux、Unix系统的路径格式
        /// </summary>
        public static string ToUnixPlatformPath(this string self)
        {
            return self.Replace("\\", "/");
        }

        /// <summary>
        /// 将适用于Linux、Unix的路径格式中'\'替换为'/'，转换为Windows默认路径格式
        /// </summary>
        public static string ToWindowsPlatformPath(this string self)
        {
            return self.Replace("/", "\\");
        }

        #endregion

        #region Extraction Operation

        /// <summary>
        /// 提取字符
        /// </summary>
        public static string ExtractCharacters(this string self, SymbolType symbolType)
        {
            switch (symbolType)
            {
                case SymbolType.SpecificSymbol:
                    return MatchRegex(self, RegexLibrary.SpecificSymbol);
                case SymbolType.BasicSpecificSymbol:
                    return MatchRegex(self, RegexLibrary.BasicSpecificSymbol);
                case SymbolType.OtherSpecificSymbol:
                    return MatchRegex(self, RegexLibrary.OtherSpecificSymbol);
                case SymbolType.AdvancedSpecificSymbol:
                    return MatchRegex(self, RegexLibrary.AdvancedSpecificSymbol);
                case SymbolType.PatternSpecificSymbol:
                    return MatchRegex(self, RegexLibrary.PatternSpecificSymbol);
                case SymbolType.Punctuation:
                    return MatchRegex(self, RegexLibrary.Punctuation);
                case SymbolType.BasicPunctuation:
                    return MatchRegex(self, RegexLibrary.BasicPunctuation);
                case SymbolType.AdvancedPunctuation:
                    return MatchRegex(self, RegexLibrary.AdvancedPunctuation);
                case SymbolType.UncommonPunctuation:
                    return MatchRegex(self, RegexLibrary.UncommonPunctuation);
                case SymbolType.EnglishPunctuation:
                    return MatchRegex(self, RegexLibrary.EnglishPunctuation);
                case SymbolType.ChinesePunctuation:
                    return MatchRegex(self, RegexLibrary.ChinesePunctuation);
                case SymbolType.SpecialPunctuation:
                    return MatchRegex(self, RegexLibrary.SpecialPunctuation);
                case SymbolType.EnglishSpecialPunctuation:
                    return MatchRegex(self, RegexLibrary.EnglishSpecialPunctuation);
                case SymbolType.ChineseSpecialPunctuation:
                    return MatchRegex(self, RegexLibrary.ChineseSpecialPunctuation);
                case SymbolType.NumericNumericalOrder:
                    return MatchRegex(self, RegexLibrary.NumericNumericalOrder);
                case SymbolType.CircularNumericNumericalOrder:
                    return MatchRegex(self, RegexLibrary.CircularNumericNumericalOrder);
                case SymbolType.BracketedNumericNumericalOrder:
                    return MatchRegex(self, RegexLibrary.BracketedNumericNumericalOrder);
                case SymbolType.DotNumericalOrder:
                    return MatchRegex(self, RegexLibrary.DotNumericalOrder);
                case SymbolType.RomanNumericalOrder:
                    return MatchRegex(self, RegexLibrary.RomanNumericalOrder);
                case SymbolType.PieNumericalOrder:
                    return MatchRegex(self, RegexLibrary.PieNumericalOrder);
                case SymbolType.ChineseLowercaseNumericalOrder:
                    return MatchRegex(self, RegexLibrary.ChineseLowercaseNumericalOrder);
                case SymbolType.ChineseUppercaseNumericalOrder:
                    return MatchRegex(self, RegexLibrary.ChineseUppercaseNumeralsOrder);
                case SymbolType.BracketedLowercaseChineseNumericalOrder:
                    return MatchRegex(self, RegexLibrary.BracketedLowercaseChineseNumeralsOrder);
                case SymbolType.MathematicalSymbol:
                    return MatchRegex(self, RegexLibrary.MathematicalSymbol);
                case SymbolType.BasicMathematicalOperator:
                    return MatchRegex(self, RegexLibrary.BasicMathematicalOperator);
                case SymbolType.AdvancedMathematicalOperator:
                    return MatchRegex(self, RegexLibrary.AdvancedMathematicalOperator);
                case SymbolType.MathematicalUnit:
                    return MatchRegex(self, RegexLibrary.MathematicalUnit);
                case SymbolType.GrecoLatinSymbol:
                    return MatchRegex(self, RegexLibrary.GrecoLatinSymbol);
                case SymbolType.GreekAlphabet:
                    return MatchRegex(self, RegexLibrary.GreekAlphabet);
                case SymbolType.LatinAlphabet:
                    return MatchRegex(self, RegexLibrary.LatinAlphabet);
                case SymbolType.SpellingPhoneticNotationSymbol:
                    return MatchRegex(self, RegexLibrary.SpellingPhoneticNotationSymbol);
                case SymbolType.SpellingSymbol:
                    return MatchRegex(self, RegexLibrary.SpellingSymbol);
                case SymbolType.PhoneticNotationSymbol:
                    return MatchRegex(self, RegexLibrary.PhoneticNotationSymbol);
                case SymbolType.ChineseCharacter:
                    return MatchRegex(self, RegexLibrary.ChineseCharacter);
                case SymbolType.Chinese:
                    return MatchRegex(self, RegexLibrary.Chinese);
                case SymbolType.ChineseNumeralsSymbol:
                    return MatchRegex(self, RegexLibrary.RomanNumericalOrder);
                case SymbolType.ChineseLowercaseNumerals:
                    return MatchRegex(self, RegexLibrary.ChineseLowercaseNumerals);
                case SymbolType.ChineseUppercaseNumerals:
                    return MatchRegex(self, RegexLibrary.ChineseUppercaseNumerals);
                case SymbolType.ChineseRarelyUsedCharacters:
                    return MatchRegex(self, RegexLibrary.ChineseRarelyUsedCharacters);
                case SymbolType.ChineseCharacterRadicals:
                    return MatchRegex(self, RegexLibrary.ChineseCharacterRadicals);
                case SymbolType.ChineseBasicCharacterRadicals:
                    return MatchRegex(self, RegexLibrary.ChineseBasicCharacterRadicals);
                case SymbolType.ChineseAdvancedCharacterRadicals:
                    return MatchRegex(self, RegexLibrary.ChineseAdvancedCharacterRadicals);
                case SymbolType.English:
                    return MatchRegex(self, RegexLibrary.English);
                case SymbolType.EnglishLowercaseAlphabet:
                    return MatchRegex(self, RegexLibrary.EnglishLowercaseAlphabet);
                case SymbolType.EnglishUppercaseAlphabet:
                    return MatchRegex(self, RegexLibrary.EnglishUppercaseAlphabet);
                case SymbolType.EnglishPhoneticAlphabet:
                    return MatchRegex(self, RegexLibrary.EnglishPhoneticAlphabet);
                case SymbolType.EnglishVowelPhonetic:
                    return MatchRegex(self, RegexLibrary.EnglishVowelPhonetic);
                case SymbolType.EnglishAuxiliaryPhonetic:
                    return MatchRegex(self, RegexLibrary.EnglishAuxiliaryPhonetic);
                case SymbolType.Japanese:
                    return MatchRegex(self, RegexLibrary.Japanese);
                case SymbolType.JapaneseHiragana:
                    return MatchRegex(self, RegexLibrary.JapaneseHiragana);
                case SymbolType.JapaneseKatakana:
                    return MatchRegex(self, RegexLibrary.JapaneseKatakana);
                case SymbolType.JapanesePunctuation:
                    return MatchRegex(self, RegexLibrary.JapanesePunctuation);
                case SymbolType.Korean:
                    return MatchRegex(self, RegexLibrary.Korean);
                case SymbolType.KoreanBasicSymbol:
                    return MatchRegex(self, RegexLibrary.KoreanBasicSymbol);
                case SymbolType.KoreanAdvancedSymbol:
                    return MatchRegex(self, RegexLibrary.KoreanAdvancedSymbol);
                case SymbolType.RussianAlphabet:
                    return MatchRegex(self, RegexLibrary.RussianAlphabet);
                case SymbolType.RussianBasicAlphabet:
                    return MatchRegex(self, RegexLibrary.RussianBasicAlphabet);
                case SymbolType.RussianAdvancedAlphabet:
                    return MatchRegex(self, RegexLibrary.RussianAdvancedAlphabet);
                case SymbolType.Tabs:
                    return MatchRegex(self, RegexLibrary.Tabs);
                case SymbolType.BasicTabs:
                    return MatchRegex(self, RegexLibrary.BasicTabs);
                case SymbolType.ConventionalTabs:
                    return MatchRegex(self, RegexLibrary.ConventionalTabs);
                case SymbolType.AdvancedTabs:
                    return MatchRegex(self, RegexLibrary.AdvancedTabs);
                default:
                    throw new ArgumentOutOfRangeException(nameof(symbolType), symbolType, null);
            }
        }

        /// <summary>
        /// 提取Unicode中文字符(仅中文字符，不包含标点符号、空格、序号和偏旁部首)
        /// </summary>
        public static string ExtractChineseCharacter(this string self)
        {
            return MatchRegex(self, RegexLibrary.ChineseCharacter);
        }


        /// <summary>
        /// 提取中文(包含Unicode中文字符、标点符号、数字序号、空格、偏旁部首和部分生僻字)
        /// </summary>
        public static string ExtractChinese(this string self)
        {
            return MatchRegex(self, RegexLibrary.Chinese);
        }

        /// <summary>
        /// 提取字母
        /// </summary>
        public static string ExtractAlphabet(this string self) => MatchRegex(self, RegexLibrary.AnyAlphabet);

        /// <summary>
        /// 提取大写字母
        /// </summary>
        public static string ExtractUppercaseAlphabet(this string self) =>
            MatchRegex(self, RegexLibrary.EnglishUppercaseAlphabet);

        /// <summary>
        /// 提取大写字母
        /// </summary>
        public static string ExtractLowercaseAlphabet(this string self) =>
            MatchRegex(self, RegexLibrary.EnglishLowercaseAlphabet);

        /// <summary>
        /// 提取数字
        /// </summary>
        public static string ExtractNumeric(this string self) => MatchRegex(self, RegexLibrary.AnyNumeric);

        /// <summary>
        /// 提取字母和数字
        /// </summary>
        public static string ExtractAlphabetAndNumeric(this string self) =>
            MatchRegex(self, RegexLibrary.AnyAlphabetNumeric);

        #endregion

        #region Bool Judgment

        /// <summary>
        /// 是否为十六进制字符串
        /// </summary>
        public static bool IsHexadecimal(this string self)
        {
            return Regex.IsMatch(self, RegexLibrary.Hexadecimal);
        }

        /// <summary>
        /// 是有效的Window路径
        /// </summary>
        public static bool IsValidWindowsPath(string path)
        {
            return new Regex(RegexLibrary.WindowsPath).IsMatch(path);
        }

        /// <summary>
        /// 是否为标点符号
        /// </summary>
        public static bool IsPunctuation(this char c) => char.IsPunctuation(c);

        /// <summary>
        /// 是否包含中文字符(Unicode)
        /// </summary>
        public static bool ContainsChineseCharacters(this string self) =>
            Regex.IsMatch(self, RegexLibrary.ChineseCharacter);

        /// <summary>
        /// 是否是中文字符(Unicode)
        /// </summary>
        public static bool IsChineseCharacter(this char c) =>
            Regex.IsMatch(c.ToString(), RegexLibrary.ChineseCharacter);

        #endregion

        #region Add Operation

        /// <summary>
        /// 添加缩进
        /// </summary>
        public static string AddIndent(this string self, int indentSize = 2)
        {
            if (string.IsNullOrEmpty(self)) return self;
            StringBuilder builder = new StringBuilder();
            return builder.AppendIndent(indentSize).Append(self).ToString();
        }

        /// <summary>
        /// 在每个字符之间添加空格
        /// </summary>
        public static string AddSpacesBetweenEachCharacter(this string self, int spacing = 1) =>
            string.IsNullOrEmpty(self) ? self : string.Join(new string(' ', spacing), self.ToCharArray());

        #endregion

        #region Text Operation

        /// <summary>
        /// 在首行和句号(中文或英文)后换行并添加首行缩进
        /// </summary>
        /// TODO 若句号后跟空行则无法在准确位置添加
        public static string AutoPeriodWrapIndent(this string self, int indentSize = 2)
        {
            if (string.IsNullOrEmpty(self)) return self;
            var punctuationIndices = Enumerable.Range(0, self.Length)
                .Where(i => self[i] == '。' || self[i] == '.')
                .ToList();

            var builder = new StringBuilder();
            var previousIndex = 0;

            builder.AppendIndent(indentSize);
            foreach (var currentIndex in punctuationIndices)
            {
                // 复制当前索引之前的部分
                builder.Append(self.Substring(previousIndex, currentIndex - previousIndex));

                // 添加句号本身
                builder.Append(self[currentIndex]);

                // 添加换行符
                builder.Append('\n');

                // 添加缩进
                builder.AppendIndent(indentSize);

                // 更新上一个索引为当前索引之后的位置
                previousIndex = currentIndex + 1;
            }

            // 添加最后一个句号之后的内容
            if (previousIndex < self.Length)
            {
                builder.Append(self.Substring(previousIndex));
            }

            return builder.ToString();
        }

        public static StringBuilder AppendIndent(this StringBuilder builder, int indentSize = 2)
        {
            builder.Append("<color=#FFF-FFF00>");
            for (int j = 0; j < indentSize; j++)
            {
                builder.Append("　");
            }

            builder.Append("</color>");
            return builder;
        }

        /// <summary>
        /// 强制换行
        /// </summary>
        public static string ForceWrap(this string self, int maximumCharacterInLine)
        {
            if (string.IsNullOrEmpty(self)) return self;

            var builder = new StringBuilder();
            var previousIndex = 0;
            // 计算当前索引直到到达字符串末尾
            for (var currentIndex = maximumCharacterInLine;
                 currentIndex < self.Length;
                 currentIndex += maximumCharacterInLine)
            {
                // 如果当前位置超过字符串长度，则设置为字符串长度
                if (currentIndex > self.Length)
                    currentIndex = self.Length;

                // 添加从 previousIndex 到 currentIndex 的子字符串
                builder.Append(self.Substring(previousIndex, currentIndex - previousIndex));

                // 添加换行符
                builder.Append("\n");

                // 更新 previousIndex
                previousIndex = currentIndex;
            }

            // 添加最后一部分文本
            if (previousIndex < self.Length)
            {
                builder.Append(self.Substring(previousIndex));
            }

            return builder.ToString();
        }

        #endregion

        #region Remove Operation

        /// <summary>
        /// 删除空白字符(包括空格、制表符、换行符等)
        /// </summary>
        public static string RemoveBlank(this string self)
        {
            return string.IsNullOrEmpty(self) ? self : Regex.Replace(self, RegexLibrary.AnyBlank, "");
        }

        /// <summary>
        /// 删除空格字符
        /// </summary>
        public static string RemoveSpace(this string self)
        {
            return string.IsNullOrEmpty(self) ? self : self.Replace(" ", "");
        }

        /// <summary>
        /// 删除数字
        /// </summary>
        public static string RemoveNumeric(this string self)
        {
            return string.IsNullOrEmpty(self) ? self : Regex.Replace(self, RegexLibrary.AnyNumeric, "");
        }

        /// <summary>
        /// 删除字母(忽略大小写)
        /// </summary>
        public static string RemoveAlphabet(this string self)
        {
            return string.IsNullOrEmpty(self) ? self : Regex.Replace(self, RegexLibrary.AnyAlphabet, "");
        }

        /// <summary>
        /// 删除大写字母
        /// </summary>
        public static string RemoveUppercaseAlphabet(this string self)
        {
            return string.IsNullOrEmpty(self) ? self : Regex.Replace(self, RegexLibrary.AnyUpperAlphabet, "");
        }

        /// <summary>
        /// 删除小写字母
        /// </summary>
        public static string RemoveLowercaseAlphabet(this string self)
        {
            return string.IsNullOrEmpty(self) ? self : Regex.Replace(self, RegexLibrary.AnyLowerAlphabet, "");
        }

        /// <summary>
        /// 删除字母和数字
        /// </summary>
        public static string RemoveAlphabetNumeric(this string self)
        {
            return string.IsNullOrEmpty(self) ? self : Regex.Replace(self, RegexLibrary.AnyAlphabetNumeric, "");
        }

        /// <summary>
        /// 删除标点符号
        /// </summary>
        public static string RemovePunctuation(this string self)
        {
            return string.IsNullOrEmpty(self) ? self : Regex.Replace(self, RegexLibrary.Punctuation, "");
        }

        #endregion

        private static string CombineRegex(string regex1, string regex2, string regex3 = "", string regex4 = "",
            string regex5 = "", string regex6 = "", string regex7 = "", string regex8 = "")
        {
            return
                $"[{ExtractRegex(regex1)}{ExtractRegex(regex2)}{ExtractRegex(regex3)}{ExtractRegex(regex4)}{ExtractRegex(regex5)}{ExtractRegex(regex6)}{ExtractRegex(regex7)}{ExtractRegex(regex8)}]";
        }

        private static string ExtractRegex(string sourceRegex)
        {
            if (sourceRegex == "") return string.Empty;
            if (sourceRegex.StartsWith("[") && sourceRegex.EndsWith("]"))
            {
                return sourceRegex.Substring(1, sourceRegex.Length - 2);
            }

            return string.Empty;
        }

        private static string MatchRegex(string sourceString, string pattern)
        {
            Debug.Log(pattern);
            var catchCharacters = new StringBuilder();
            Debug.Log(new Regex(pattern).Matches(sourceString).Count);
            foreach (Match match in new Regex(pattern).Matches(sourceString))
            {
                catchCharacters.Append(match.Value);
            }

            return catchCharacters.ToString();
        }
    }
}