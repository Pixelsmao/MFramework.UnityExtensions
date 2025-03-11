namespace MFramework.Extensions.DataType
{
    /// <summary>
    /// 符号类型
    /// </summary>
    public enum SymbolType
    {
        /// <summary>
        /// 所有特殊符号
        /// </summary>
        SpecificSymbol,

        /// <summary>
        /// 基础特殊符号
        /// </summary>
        BasicSpecificSymbol,

        /// <summary>
        /// 其他特殊符号
        /// </summary>
        OtherSpecificSymbol,

        /// <summary>
        /// 高级特殊符号
        /// </summary>
        AdvancedSpecificSymbol,

        /// <summary>
        /// 图案特殊符号
        /// </summary>
        PatternSpecificSymbol,

        /// <summary>
        /// 所有标点符号
        /// </summary>
        Punctuation,

        /// <summary>
        /// 基础标点符号(包含基础的中英文标点符号)
        /// </summary>
        BasicPunctuation,

        /// <summary>
        /// 高级标点符号(包含高级中英文标点符号)
        /// </summary>
        AdvancedPunctuation,

        /// <summary>
        /// 不常见标点符号
        /// </summary>
        UncommonPunctuation,

        /// <summary>
        /// 英文标点符号
        /// </summary>
        EnglishPunctuation,

        /// <summary>
        /// 中文标点符号
        /// </summary>
        ChinesePunctuation,


        /// <summary>
        /// 特殊标点符号
        /// </summary>
        SpecialPunctuation,

        /// <summary>
        /// 英文特殊标点符号
        /// </summary>
        EnglishSpecialPunctuation,

        /// <summary>
        /// 中文特殊标点符号
        /// </summary>
        ChineseSpecialPunctuation,

        /// <summary>
        /// 所有数字序号
        /// </summary>
        NumericNumericalOrder,

        /// <summary>
        /// 圆形数字序号
        /// </summary>
        CircularNumericNumericalOrder,

        /// <summary>
        /// 括号数字序号
        /// </summary>
        BracketedNumericNumericalOrder,

        /// <summary>
        /// 点状数字序号
        /// </summary>
        DotNumericalOrder,

        /// <summary>
        /// 罗马数字序号
        /// </summary>
        RomanNumericalOrder,

        /// <summary>
        /// 饼状数字序号
        /// </summary>
        PieNumericalOrder,

        /// <summary>
        /// 中文小写数字序号
        /// </summary>
        ChineseLowercaseNumericalOrder,

        /// <summary>
        /// 中文大写数字序号
        /// </summary>
        ChineseUppercaseNumericalOrder,

        /// <summary>
        /// 带括号的小写数字序号
        /// </summary>
        BracketedLowercaseChineseNumericalOrder,

        /// <summary>
        /// 所有数学符号
        /// </summary>
        MathematicalSymbol,

        /// <summary>
        /// 基础数学运算符
        /// </summary>
        BasicMathematicalOperator,

        /// <summary>
        /// 高级数学运算符
        /// </summary>
        AdvancedMathematicalOperator,

        /// <summary>
        /// 数学单位
        /// </summary>
        MathematicalUnit,

        /// <summary>
        /// 所有希腊拉丁符号
        /// </summary>
        GrecoLatinSymbol,

        /// <summary>
        /// 希腊字母
        /// </summary>
        GreekAlphabet,

        /// <summary>
        /// 拉丁字母
        /// </summary>
        LatinAlphabet,

        /// <summary>
        /// 所有拼音注音符号
        /// </summary>
        SpellingPhoneticNotationSymbol,

        /// <summary>
        /// 拼音符号
        /// </summary>
        SpellingSymbol,

        /// <summary>
        /// 注音符号
        /// </summary>
        PhoneticNotationSymbol,

        /// <summary>
        /// Unicode中文字符(仅中文字符，不包含标点符号、空格、序号和偏旁部首)
        /// </summary>
        ChineseCharacter,

        /// <summary>
        /// 中文(包含Unicode中文字符、标点符号、数字序号、空格、偏旁部首和部分生僻字)
        /// </summary>
        Chinese,

        /// <summary>
        /// 中文数字符号
        /// </summary>
        ChineseNumeralsSymbol,

        /// <summary>
        /// 小写中文数字
        /// </summary>
        ChineseLowercaseNumerals,

        /// <summary>
        /// 大写中文数字
        /// </summary>
        ChineseUppercaseNumerals,

        /// <summary>
        /// 生僻字(部分)
        /// </summary>
        ChineseRarelyUsedCharacters,

        /// <summary>
        /// 汉字部首
        /// </summary>
        ChineseCharacterRadicals,

        /// <summary>
        /// 基础汉字部首
        /// </summary>
        ChineseBasicCharacterRadicals,

        /// <summary>
        /// 高级汉字部首
        /// </summary>
        ChineseAdvancedCharacterRadicals,

        /// <summary>
        /// 英文(大小写字母)
        /// </summary>
        English,

        /// <summary>
        /// 英语小写字母
        /// </summary>
        EnglishLowercaseAlphabet,

        /// <summary>
        /// 英语大写字母
        /// </summary>
        EnglishUppercaseAlphabet,

        /// <summary>
        /// 英语音标(包括元音音标和辅音音标)
        /// </summary>
        EnglishPhoneticAlphabet,

        /// <summary>
        /// 英语元音音标
        /// </summary>
        EnglishVowelPhonetic,

        /// <summary>
        /// 英语辅音音标
        /// </summary>
        EnglishAuxiliaryPhonetic,

        /// <summary>
        /// 日语字符
        /// </summary>
        Japanese,

        /// <summary>
        /// 日语平假名
        /// </summary>
        JapaneseHiragana,

        /// <summary>
        /// 日语片假名
        /// </summary>
        JapaneseKatakana,

        /// <summary>
        /// 日语标点符号
        /// </summary>
        JapanesePunctuation,

        /// <summary>
        /// 韩文字符
        /// </summary>
        Korean,

        /// <summary>
        /// 韩文基础字符
        /// </summary>
        KoreanBasicSymbol,

        /// <summary>
        /// 韩文高级字符
        /// </summary>
        KoreanAdvancedSymbol,

        /// <summary>
        /// 俄文字母
        /// </summary>
        RussianAlphabet,

        /// <summary>
        /// 基础俄文字母
        /// </summary>
        RussianBasicAlphabet,

        /// <summary>
        /// 高级俄文字母
        /// </summary>
        RussianAdvancedAlphabet,

        /// <summary>
        /// 制表符
        /// </summary>
        Tabs,

        /// <summary>
        /// 基础制表符
        /// </summary>
        BasicTabs,

        /// <summary>
        /// 常规制表符
        /// </summary>
        ConventionalTabs,

        /// <summary>
        /// 高级制表符
        /// </summary>
        AdvancedTabs
    }
}