using System.Text.RegularExpressions;

namespace MFramework.Libraries
{
    public static class RegexLibrary
    {
        /// <summary>
        /// 匹配任意字符
        /// </summary>
        public const string Any = ".";

        /// <summary>
        /// 匹配除换行符以外的任意字符
        /// </summary>
        public const string AnyWithoutLineFeed = @".*";

        /// <summary>
        /// 匹配任意空白字符
        /// </summary>
        public const string AnyBlank = @"\s";

        /// <summary>
        /// 匹配任意数量的空白字符
        /// </summary>
        public const string AnyBlankCount = @"\s+";

        /// <summary>
        /// 匹配任意非空白字符
        /// </summary>
        public const string AnyNonBlank = @"\S";

        /// <summary>
        /// 匹配任意数字字符
        /// </summary>
        public const string AnyNumeric = @"\d";

        /// <summary>
        /// 匹配任意数量数字字符
        /// </summary>
        public const string AnyNumericCount = @"\d+";

        /// <summary>
        /// 匹配任意非数字字符
        /// </summary>
        public const string AnyNonNumeric = @"\D";

        /// <summary>
        /// 匹配任意字母数字
        /// </summary>
        public const string AnyAlphabetNumeric = @"\w";

        /// <summary>
        /// 匹配任意非字母数字
        /// </summary>
        public const string AnyNonAlphabetNumeric = @"\W";

        /// <summary>
        /// 仅字母字符
        /// </summary>
        public const string OnlyAlphabet = @"^[A-Za-z]+$";

        /// <summary>
        /// 任意字母字符
        /// </summary>
        public const string AnyAlphabet = @"[A-Za-z]";

        /// <summary>
        /// 任意大写字母
        /// </summary>
        public const string AnyUpperAlphabet = @"[A-Z]";

        /// <summary>
        /// 任意小写字母
        /// </summary>
        public const string AnyLowerAlphabet = @"[a-z]";


        /// <summary>
        /// 任意字母和数字
        /// </summary>
        public const string AnyAlphabetAndNumeric = @"^[A-Za-z0-9]+$";


        /// <summary>
        /// 任意英文字母、数字和下划线
        /// </summary>
        public const string AnyAlphabetNumericAndUnderscore = @"^\w+$";

        /// <summary>
        /// 全大写字母
        /// </summary>
        public const string AllUpperAlphabet = @"^[A-Z]+$";

        /// <summary>
        /// 全小写字母
        /// </summary>
        public const string AllLowerAlphabet = @"^[a-z]+$";

        /// <summary>
        /// 十六进制字符(单个字符)
        /// </summary>
        public const string HexadecimalCharacter = @"\b[0-9A-Fa-f]+\b";

        /// <summary>
        /// 十六进制字符串
        /// </summary>
        public const string Hexadecimal = @"^[0-9A-Fa-f ]+$";

        /// <summary>
        /// 用连字符连接的单词
        /// </summary>
        public const string HyphenatedWord = @"\b\w+-\w+\b";


        /// <summary>
        /// 特定字符开始
        /// </summary>
        public static string StartWith(string prefix) => $"^{Regex.Escape(prefix)}";


        /// <summary>
        /// 空白字符开始
        /// </summary>
        public const string StartWithBlank = @"^\s";


        /// <summary>
        /// 任意字母开始
        /// </summary>
        public const string StartWithAnyAlphabet = @"^[a-zA-Z]";

        /// <summary>
        /// 特定字符结束
        /// </summary>
        public static string EndWith(string suffix) => $"{Regex.Escape(suffix)}$";

        /// <summary>
        /// 空白字符结束
        /// </summary>
        public const string EndWithBlank = @"\s$";

        /// <summary>
        /// 任意字母结束
        /// </summary>
        public const string EndWithAnyAlphabet = @"[a-zA-Z]$";


        /// <summary>
        /// 特定字符开始和结束
        /// </summary>
        public static string StartEndWith(string prefix, string suffix) =>
            $"^{Regex.Escape(prefix)}.*?{Regex.Escape(suffix)}$";


        /// <summary>
        /// 空白字符开始和结束
        /// </summary>
        public const string StartEndWithBlank = @"^\s+|\s+$";

        /// <summary>
        /// 包含特定字符串
        /// </summary>
        public static string Contain(string contain) => Regex.Escape(contain);


        /// <summary>
        /// 包含多个空格
        /// </summary>
        public const string ContainAnyBlankCount = @"^\s+.*\s+$";

        /// <summary>
        /// 匹配整行
        /// </summary>
        public const string CompleteRow = @"^.*$";


        /// <summary>
        /// N位数字
        /// </summary>
        public static string NNumeric(int count) => @"^\d{" + count + "}$";


        /// <summary>
        /// 至少N位数字
        /// </summary>
        public static string AtLeastNNumbers(int minCount) => @"^\d{" + minCount + ",}$";


        /// <summary>
        /// M-N位数字
        /// </summary>
        public static string AtLeastNNumbers(int minCount, int maxCount) => @"^\d{" + minCount + "," + maxCount + ",}$";


        /// <summary>
        /// 整数
        /// </summary>
        public const string Integer = @"^-?\d+$";

        /// <summary>
        /// 正整数
        /// </summary>
        public const string PositiveInteger = @"[^[0-9]*[1-9][0-9]*$]";

        /// <summary>
        /// 负整数
        /// </summary>
        public const string NegativeInteger = @"^-[0-9]*[1-9][0-9]*$";

        /// <summary>
        /// 非负整数(0+正整数)
        /// </summary>
        public const string NonnegativeInteger = @"[^\d+$]";


        /// <summary>
        /// 非正整数
        /// </summary>
        public const string NonPositiveInteger = @"[^((-\d+)|(0+))$]";

        /// <summary>
        /// 浮点数
        /// </summary>
        public const string FloatingPointNumber = @"^(-?\d+)(\.\d+)?$";

        /// <summary>
        /// 正浮点数
        /// </summary>
        public const string PositiveFloatingPointNumber =
            @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";

        /// <summary>
        /// 负浮点数
        /// </summary>
        public const string NegativeFloatingPointNumber =
            @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";

        /// <summary>
        /// 非负浮点数(0+正浮点数)
        /// </summary>
        public const string NonNegativeFloatingPointNumber = @"[^\d+(\.\d+)?$]";


        /// <summary>
        /// 非正浮点数
        /// </summary>
        public const string NonPositiveFloatingPointNumber = @"^((-\d+(\.\d+)?)|(0+(\.0+)?))$";


        /// <summary>
        /// 全角符号
        /// </summary>
        public const string FullAngleSymbol = @"/[\uFF00-\uFFFF]/";

        /// <summary>
        /// 半角符号
        /// </summary>
        public const string HalfAngleSymbol = @"/[\u0000-\u00FF]/";

        /// <summary>
        /// 域名
        /// </summary>
        public const string DomainName =
            @"[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(/.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+/.?";


        /// <summary>
        /// Email地址
        /// </summary>
        public const string EmailAddress = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";

        /// <summary>
        /// URL格式
        /// </summary>
        public const string URL = @"(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$";

        /// <summary>
        /// URL主机部分
        /// </summary>
        public const string HostURL = @"^(?:https?:\/\/)?(?:[^@\n]+@)?(?:www\.)?([^:\/\n]+)";

        /// <summary>
        /// 主机URL路径部分
        /// </summary>
        public const string HostURLPath = @"(?:https?:\/\/)?(?:www\.)?[^\/]+(\/[^#?]+)";

        /// <summary>
        /// 双字节字符
        /// </summary>
        public const string DoubleByteCharacter = @"[^\x00-\xff]";

        /// <summary>
        /// 空行
        /// </summary>
        public const string EmptyLine = @"\n[\s| ]*\r";

        /// <summary>
        /// 日期格式
        /// </summary>
        public const string DateFormat = @"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$";

        /// <summary>
        /// 帐号是否合法(字母开头，允许5-16字节，允许字母数字下划线)
        /// </summary>
        public const string Account = @"^[a-zA-Z][a-zA-Z0-9_]{4,15}$";

        /// <summary>
        /// 密码(以字母开头，长度在6~16之间，只能包含字母、数字和下划线)
        /// </summary>
        public const string Password = @"^[a-zA-Z][a-zA-Z0-9_]{5,15}$";

        /// <summary>
        /// 强密码(必须包含大小写字母和数字的组合，不能使用特殊字符，长度在8-16之间)
        /// </summary>
        public const string StrongPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,15}$";


        /// <summary>
        /// 手机电话号码
        /// </summary>
        public const string ChinaTelephoneNumber =
            @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$";


        /// <summary>
        /// 座机电话号码
        /// </summary>
        public const string ChinaLandlinePhoneNumber = @"\d{3}-\d{8} |\d{4}-\d{7}";

        /// <summary>
        /// 腾讯QQ账号
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string TencentQQAccount = @"[1-9][0-9]{4,}";

        /// <summary>
        /// 邮政编码
        /// </summary>
        public const string PostalCode = @"[1-9]\d{5}(?!\d)";

        /// <summary>
        /// 身份证号码
        /// </summary>
        public const string ChinaIDCard = @"/(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/";

        /// <summary>
        /// IPv4格式IP地址
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string IPv4Address =
            @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";

        /// <summary>
        /// 子网掩码
        /// </summary>
        public const string SubnetMask =
            @"((?:(?:25[0-5]|2[0-4]\\d|[01]?\\d?\\d)\\.){3}(?:25[0-5]|2[0-4]\\d|[01]?\\d?\\d))";

        /// <summary>
        /// HTML标记语言格式
        /// </summary>
        public const string HtmlMarkingLanguage = @"/<(.*)>.*<\/\1>|<(.*) \/>/";

        /// <summary>
        /// CJK统一表意字符
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string CJKUnifiedIdeographs = @"\p{IsCJKUnifiedIdeographs}";


        #region Summa of symbols

        /// <summary>
        /// 特殊符号
        /// </summary>
        public static string SpecificSymbol => CombineRegex(BasicSpecificSymbol, OtherSpecificSymbol,
            AdvancedSpecificSymbol, PatternSpecificSymbol);

        /// <summary>
        /// 基础特殊符号
        /// </summary>
        public static string BasicSpecificSymbol =>
            @"[△▽○◇□☆▷◁♤♡♢♧▲▼●◆■★▶◀♠♥♦♣☼☽♀☺◐☑√✔☜☝☞㏂☀☾♂☹◑☒×✘☚☟☛㏘▪•‥…▁▂▃▄▅▆▇█∷※░▒▓▏▎▍▌▋▊▉]";

        /// <summary>
        /// 其他特殊符号
        /// </summary>
        public const string OtherSpecificSymbol = @"[♩♪♫♬§〼◎¤۞℗®©♭♯♮‖¶卍卐▬〓℡™㏇☌☍☋☊㉿◮◪◔◕@㈱№♈♉♊♋♌♎♏♐♑♓♒♍]";

        /// <summary>
        /// 高级特殊符号
        /// </summary>
        public const string AdvancedSpecificSymbol = @"[↖↑↗▨▤▧◤㊤◥☴☲☷←㊣→▩▦▥㊧㊥㊨☳☯☱↙↓↘▫◈▣◣㊦◢☶☵☰↕↔⊱⋛⋌⋚⊰¬￢▔†‡]";

        /// <summary>
        /// 图案特殊符号
        /// </summary>
        public const string PatternSpecificSymbol =
            @"[*＊✲❈❉✿❀❃❁☸✖✚✪❤ღ❦❧ி₪✎✍✌✁✄☁☂☃☄♨☇☈☡➷⊹✉☏☢☣☠☮〄➹☩ஐ☎✈〠۩✙✟☤☥☦☧☨☫☬♟♙♜♖♞♘♝♗♛♕♚♔]";

        /// <summary>
        /// 所有标点符号
        /// </summary>
        public static string Punctuation => CombineRegex(BasicPunctuation, AdvancedPunctuation, SpecialPunctuation);

        /// <summary>
        /// 基础标点符号
        /// </summary>
        public const string BasicPunctuation = @"[，。？！：；·…~&@#,.?!:;、……～＆＠＃/]";

        /// <summary>
        /// 高级标点符号
        /// </summary>
        public const string AdvancedPunctuation = @"[“”‘’〝〞 '""＂＇´＇\(\)【】《》＜＞﹝﹞<>\(\)\[\]«»‹›〔〕〈〉\{\}［］「」｛｝〖〗『』]";

        /// <summary>
        /// 不常见标点符号
        /// </summary>
        public const string UncommonPunctuation = @"[︵︷︹︿︽﹁﹃︻︗/|\︶︸︺﹀︾﹂﹄︼︘／｜＼ˊ¨­^¡¦`﹎﹍﹏＿_¯￣﹋﹉﹊ˋ︴¿ˇ　]";

        /// <summary>
        /// 英文标点符号
        /// </summary>
        public const string EnglishPunctuation = @"[,.?!:; ""'＂＇<>()[]{}…]";

        /// <summary>
        /// 中文标点符号
        /// </summary>
        public const string ChinesePunctuation = @"[，。？！：；·……“”‘’〝〞（）【】《》＜＞﹝﹞«»‹›〔〕〈〉［］「」｛｝〖〗『』]";

        /// <summary>
        /// 特殊标点符号
        /// </summary>
        public static string SpecialPunctuation => CombineRegex(EnglishSpecialPunctuation, ChineseSpecialPunctuation);

        /// <summary>
        /// 英文特殊标点符号
        /// </summary>
        public const string EnglishSpecialPunctuation = @"[~&@#$%^*|]";

        /// <summary>
        /// 中文特殊标点符号
        /// </summary>
        public const string ChineseSpecialPunctuation = @"[～＆＠＃￥]";

        /// <summary>
        /// 所有数字序号
        /// </summary>
        public static string NumericNumericalOrder =>
            CombineRegex(CircularNumericNumericalOrder, BracketedNumericNumericalOrder, DotNumericalOrder,
                RomanNumericalOrder, PieNumericalOrder, ChineseLowercaseNumericalOrder, ChineseUppercaseNumeralsOrder,
                BracketedLowercaseChineseNumeralsOrder);

        /// <summary>
        /// 圆形数字序号
        /// </summary>
        public const string CircularNumericNumericalOrder = @"[①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳]";

        /// <summary>
        /// 括号数字序号
        /// </summary>
        public const string BracketedNumericNumericalOrder = @"[⑴⑵⑶⑷⑸⑹⑺⑻⑼⑽⑾⑿⒀⒁⒂⒃⒄⒅⒆⒇]";

        /// <summary>
        /// 点状数字序号
        /// </summary>
        public const string DotNumericalOrder = @"[⒈⒉⒊⒋⒌⒍⒎⒏⒐⒑⒒⒓⒔⒕⒖⒗⒘⒙⒚⒛]";

        /// <summary>
        /// 罗马数字序号
        /// </summary>
        public const string RomanNumericalOrder = @"[ⅠⅡⅢⅣⅤⅥⅦⅧⅨⅩⅪⅫⅰⅱⅲⅳⅴⅵⅶⅷⅸⅹ]";

        /// <summary>
        /// 饼状数字序号
        /// </summary>
        public const string PieNumericalOrder = @"[❶❷❸❹❺❻❼❽❾❿]";

        /// <summary>
        /// 中文小写数字序号
        /// </summary>
        public const string ChineseLowercaseNumericalOrder = @"[〇一二三四五六七八九十]";

        /// <summary>
        /// 中文大写数字序号
        /// </summary>
        public const string ChineseUppercaseNumeralsOrder = @"[零壹贰叁肆伍陆柒捌玖拾]";

        /// <summary>
        /// 带括号的小写数字序号
        /// </summary>
        public const string BracketedLowercaseChineseNumeralsOrder = @"[㈠㈡㈢㈣㈤㈥㈦㈧㈨㈩]";

        /// <summary>
        /// 所有数学符号
        /// </summary>
        public static string MathematicalSymbol =>
            CombineRegex(BasicMathematicalOperator, AdvancedMathematicalOperator, MathematicalUnit);

        /// <summary>
        /// 基础数学运算符
        /// </summary>
        public const string BasicMathematicalOperator = @"[﹢﹣·/=﹤﹥≦≧≮≯≡＋－×÷＝＜＞≤≥≈≒≠﹢﹣±∶∵∴∷㏒㏑∑∏∅]";

        /// <summary>
        /// 高级数学运算符
        /// </summary>
        public const string AdvancedMathematicalOperator = @"[∝∽∈∩∧⊙⌒∥∟∣∂∆∞≌∉∪∨⊕⊿⊥∠∫∬∭%‰％º¹²³ⁿ℅∮∯∰₁₂₃½⅓⅔¼¾°℃℉〒]";

        /// <summary>
        /// 数学单位
        /// </summary>
        public const string MathematicalUnit = @"[㎎㎏μm㎜㎝㎞′¥$€฿￡㎡m³㏄mlmol㏕″￥£￠₠]";

        /// <summary>
        /// 所有希腊拉丁符号
        /// </summary>
        public static string GrecoLatinSymbol => CombineRegex(GreekAlphabet, LatinAlphabet);

        /// <summary>
        /// 希腊字母
        /// </summary>
        public const string GreekAlphabet = @"[ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩαβγδεζηθικλμνξοπρστυφχψω]";

        /// <summary>
        /// 拉丁字母
        /// </summary>
        public const string LatinAlphabet = @"[ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝÞŠŸŒ]";

        /// <summary>
        /// 所有拼音注音符号
        /// </summary>
        public static string SpellingPhoneticNotationSymbol => CombineRegex(SpellingSymbol, PhoneticNotationSymbol);

        /// <summary>
        /// 拼音符号
        /// </summary>
        public const string SpellingSymbol = @"[āáǎàōóǒòēéěèīíǐìūúǔùǖǘǚǜêńňü]";

        /// <summary>
        /// 注音符号
        /// </summary>
        public const string PhoneticNotationSymbol = @"[ㄚㄛㄜㄧㄨㄩㄝㄞㄟㄠㄡㄢㄣㄤㄥㄦㄅㄆㄇㄈㄉㄊㄋㄌㄍㄎㄏㄐㄑㄒㄓㄔㄕㄖㄗㄘㄙ]";

        /// <summary>
        /// Unicode中文字符(仅中文字符，不包含标点符号、空格、序号和偏旁部首)
        /// </summary>
        public const string ChineseCharacter = @"[\u4e00-\u9fff]";

        /// <summary>
        /// 中文(包含Unicode中文字符、标点符号、数字序号、空格、偏旁部首和部分生僻字)
        /// </summary>
        public static string Chinese => CombineRegex(ChineseCharacter, ChineseNumeralsSymbol,
            ChineseRarelyUsedCharacters, ChineseCharacterRadicals, ChinesePunctuation, ChineseSpecialPunctuation);

        /// <summary>
        /// 中文数字符号
        /// </summary>
        public static string ChineseNumeralsSymbol => CombineRegex(ChineseLowercaseNumerals, ChineseUppercaseNumerals);

        /// <summary>
        /// 小写中文数字
        /// </summary>
        public const string ChineseLowercaseNumerals = @"[〇一二三四五六七八九十百千万亿兆吉太拍艾分厘毫微]";

        /// <summary>
        /// 大写中文数字
        /// </summary>
        public const string ChineseUppercaseNumerals = @"[零壹贰叁肆伍陆柒捌玖拾佰仟万亿兆吉太拍艾分厘毫微]";

        /// <summary>
        /// 生僻字(部分)
        /// </summary>
        public const string ChineseRarelyUsedCharacters = @"[玊嘂槑朤囍嬲嫐靐龘鑫淼焱嘦巭勥氼嫑炛恏兲奣烎忈龑]";

        /// <summary>
        /// 汉字部首
        /// </summary>
        public static string ChineseCharacterRadicals =>
            CombineRegex(ChineseBasicCharacterRadicals, ChineseAdvancedCharacterRadicals);

        /// <summary>
        /// 基础汉字部首
        /// </summary>
        public const string ChineseBasicCharacterRadicals =
            @"[一丨丿丶㇏亅乚乛㇀乀ㄋ〇𠃊𠃎𠃍匚凵冂丅丄𠄌𠃋𡿨𠃌卍曱〡〢〣〤〥〦〧〨〩十卐甴弍弎弐卄巜〆〃々の囧]";

        /// <summary>
        /// 高级汉字部首
        /// </summary>
        public const string ChineseAdvancedCharacterRadicals =
            @"[丶冫氵灬阝卩刂忄讠扌亻彳厃⺁𠘨⺆⺄广疒饣钅礻衤辶牜釒飠⺪⻊糹⺝丩丬犭纟廴攵夊皿臼虍勹尢廾歺夬氺丂爫癶耂⺻⺮⺳⺶⺷⺈龵彐⺋罒覀⻗亠宀冖艹⺌丷⺧亇彡]";

        /// <summary>
        /// 英文(大小写字母)
        /// </summary>
        public const string English = @"[A-Za-z]";

        /// <summary>
        /// 英语小写字母
        /// </summary>
        public const string EnglishLowercaseAlphabet = @"[a-z]";

        /// <summary>
        /// 英语大写字母
        /// </summary>
        public const string EnglishUppercaseAlphabet = @"[A-Z]";

        /// <summary>
        /// 英语音标(包括元音音标和辅音音标)
        /// </summary>
        public static string EnglishPhoneticAlphabet = CombineRegex(EnglishVowelPhonetic, EnglishAuxiliaryPhonetic);

        /// <summary>
        /// 英语元音音标
        /// </summary>
        public const string EnglishVowelPhonetic = @"[ɑːɔ:ɜːi:u:ʌɒəɪʊeæeɪaɪɔɪɪəeəʊəəʊaʊ]";

        /// <summary>
        /// 英语辅音音标
        /// </summary>
        public const string EnglishAuxiliaryPhonetic = @"[ptkfθsbdgvðzʃhtstʃjtrʒrdzdʒdrwmnŋl]";

        /// <summary>
        /// 日语字符
        /// </summary>
        public static string Japanese = CombineRegex(JapaneseHiragana, JapaneseKatakana, JapaneseKatakana);

        /// <summary>
        /// 日语平假名
        /// </summary>
        public const string JapaneseHiragana =
            @"[あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわをんがぎぐげござじずぜぞだぢづでどばびぶべぼぱぴぷぺぽぁぃぅぇぉゃゅょっゎゐゑ]";


        /// <summary>
        /// 日语片假名
        /// </summary>
        public const string JapaneseKatakana =
            @"[アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲンガギグゲゴザジズゼゾダヂヅデドバビブベボァィゥェォャュョッヮヰヱヵヶ]";

        /// <summary>
        /// 日语标点符号
        /// </summary>
        public const string JapanesePunctuation = @"[゛゜「」・、。ー]";

        /// <summary>
        /// 韩文字符
        /// </summary>
        public static string Korean => CombineRegex(KoreanBasicSymbol, KoreanAdvancedSymbol);

        /// <summary>
        /// 韩文基础字符
        /// </summary>
        public const string KoreanBasicSymbol = @"[ㅏㅑㅓㅕㅗㅛㅜㅠㅡㅣㅐㅒㅔㅖㅘㅙㅚㅝㅞㅟㅢㄱㄴㄷㄹㅁㅂㅅㅇㅈㅊㅋㅌㅍㅎㄲㄸㅃㅆㅉ]";

        /// <summary>
        /// 韩文高级字符
        /// </summary>
        public const string KoreanAdvancedSymbol = @"[㉠㉡㉢㉣㉤㉥㉦㉧㉨㉩㉪㉫㉬㉭㉮㉯㉰㉱㉲㉳㉴㉵㉶㉷㉸㉹㉺㉻㈀㈁㈂㈃㈄㈅㈆㈇㈈㈉㈊㈋㈌㈍㈎㈏㈐㈑㈒㈓㈔㈕㈖㈗㈘㈙㈚㈛]";

        /// <summary>
        /// 俄文字母
        /// </summary>
        public static string RussianAlphabet => CombineRegex(RussianBasicAlphabet, RussianAdvancedAlphabet);

        /// <summary>
        /// 基础俄文字母
        /// </summary>
        public const string RussianBasicAlphabet = @"[АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ]";

        /// <summary>
        /// 高级俄文字母
        /// </summary>
        public const string RussianAdvancedAlphabet = @"[абвгдеёжзийклмнопрстуфхцчшщъыьэюя]";

        /// <summary>
        /// 制表符
        /// </summary>
        public static string Tabs => CombineRegex(BasicTabs, ConventionalTabs, AdvancedTabs);

        /// <summary>
        /// 基础制表符
        /// </summary>
        public const string BasicTabs = @"[┌┬┐┏┳┓╔╦╗╭─╮├┼┤┣╋┫╠╬╣│╳┃└┴┘┗┻┛╚╩╝╰━╯]";

        /// <summary>
        /// 常规制表符
        /// </summary>
        public const string ConventionalTabs = @"[┍┑┎┒╒╕╓╖╱╲┄┅┕┙┖┚╘╛╙╜╲╱┆┇]";

        /// <summary>
        /// 高级制表符
        /// </summary>
        public const string AdvancedTabs = @"[┝┞┟┠┡┢═╞╟╡╢╪┭┮┯┰┱┲║╤╥╧╨╫┥┦┧┨┩┪┽┾┿╀╁╂┵┶┷┸┹┺╄╅╆╇╈╉┈┉┊┋╃╊]";

        #endregion

        public const string WindowsPath = @"^[a-zA-Z]:\\[^\/:*?""<>|]+(\\[^\/:*?""<>|]+)*$";

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
    }
}